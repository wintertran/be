using be.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace be.Controllers
{
    [ApiController]
    [Route("api/account")]
    public class AccountController : ControllerBase
    {
        private static Dictionary<string, (string Password, string UserId)> accountStore = new(); // Temporary in-memory account storage
        private static Dictionary<string, UserDto> userStore = new(); // Temporary in-memory user storage
        private readonly string secretKey = Environment.GetEnvironmentVariable("JWT_SECRET_KEY") ?? "WinterSoldier2k3!@#SecureLongKey$%^";
        private readonly string refreshSecretKey = Environment.GetEnvironmentVariable("JWT_REFRESH_SECRET_KEY") ?? "WinterSoldier2k3!@#SecureLongKey$%^";

        [HttpPost("register")]
        public IActionResult Register([FromBody] CreateAccountDto request)
        {
            // Check if the username already exists
            if (accountStore.ContainsKey(request.Username))
            {
                return BadRequest("Username already exists."); // Response when username is taken
            }

            // Hash password for security
            string hashedPassword = HashPassword(request.Password);

            // Generate a new UserId
            string userId = Guid.NewGuid().ToString();

            var newUser = new UserDto
            {
                Id = userId,
                Name = "New User", // Default name, update as necessary
                PhoneNumber = null,
                Email = null,
                Gender = null,
                DateOfBirth = null
            };

            userStore[userId] = newUser;

            accountStore[request.Username] = (hashedPassword, userId);

            return Ok(new { Message = "User registered successfully.", UserId = userId });
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UpdateAccountDto request)
        {
            if (!accountStore.TryGetValue(request.Username, out var accountInfo))
            {
                return Unauthorized("Invalid username or password.");
            }

            // Validate password
            if (accountInfo.Password != HashPassword(request.Password))
            {
                return Unauthorized("Invalid username or password.");
            }

            // Generate access token
            var accessToken = GenerateToken(accountInfo.UserId, secretKey, DateTime.UtcNow.AddHours(1));

            // Generate refresh token
            var refreshToken = GenerateToken(accountInfo.UserId, refreshSecretKey, DateTime.UtcNow.AddDays(7));

            return Ok(new
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
                TokenType = "Bearer",
                ExpiredAt = DateTime.UtcNow.AddHours(1)
            });
        }

        [HttpPost("forgot-password")]
        public IActionResult ForgotPassword([FromBody] string email)
        {
            // Find user by email
            var user = userStore.Values.FirstOrDefault(u => u.Email == email);
            if (user == null)
            {
                return NotFound("Email not registered.");
            }

            // Generate password reset token
            string resetToken = Guid.NewGuid().ToString();
            user.ResetToken = resetToken;
            string resetLink = Url.Action(nameof(ResetPassword), "Account", new { token = resetToken }, Request.Scheme);

            // Send email with the reset link
            SendEmail(email, "Password Reset", $"Click the link to reset your password: {resetLink}");

            return Ok("Reset password email sent.");
        }

        [HttpPost("reset-password")]
        public IActionResult ResetPassword(string token, [FromBody] string newPassword)
        {
            // Find user by reset token
            var user = userStore.Values.FirstOrDefault(u => u.ResetToken == token);
            if (user == null)
            {
                return BadRequest("Invalid or expired token.");
            }

            // Hash the new password and update it in the accountStore
            string hashedPassword = HashPassword(newPassword);
            var account = accountStore.FirstOrDefault(a => a.Value.UserId == user.Id);

            if (account.Equals(default(KeyValuePair<string, (string Password, string UserId)>)))
            {
                return NotFound("User not found.");
            }

            accountStore[account.Key] = (hashedPassword, account.Value.UserId);

            user.ResetToken = null;

            return Ok("Password reset successfully.");
        }

        private void SendEmail(string toEmail, string subject, string body)
        {
            string smtpEmail = Environment.GetEnvironmentVariable("SMTP_EMAIL") ?? "";
            string smtpPassword = Environment.GetEnvironmentVariable("SMTP_PASSWORD") ?? "";

            using var smtpClient = new SmtpClient("smtp.example.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(smtpEmail, smtpPassword),
                EnableSsl = true,
            };

            smtpClient.Send(smtpEmail, toEmail, subject, body);
        }

        private string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(hashedBytes);
        }

        private string GenerateToken(string userId, string key, DateTime expiration)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userId)
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = expiration,
                SigningCredentials = credentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
