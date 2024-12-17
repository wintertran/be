using be.DTOs;
using be.Models;
using be.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace be.Controllers
{
    [ApiController]
    [Route("api/account")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;
        private readonly string secretKey = Environment.GetEnvironmentVariable("JWT_SECRET_KEY") ?? "WinterSoldier2k3!@#SecureLongKey$%^";
        private readonly string refreshSecretKey = Environment.GetEnvironmentVariable("JWT_REFRESH_SECRET_KEY") ?? "WinterSoldier2k3!@#SecureLongKey$%^";

        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        // Đăng ký tài khoản
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] CreateAccountDto request)
        {
            if (await _accountRepository.UsernameExistsAsync(request.Username))
            {
                return BadRequest(new { Message = "Username already exists." });
            }

            string hashedPassword = HashPassword(request.Password);

            var account = new Account
            {
                Id = Guid.NewGuid().ToString(),
                UserId = Guid.NewGuid().ToString(),
                Username = request.Username,
                PasswordHash = hashedPassword
            };

            await _accountRepository.AddAsync(account);

            return Ok(new { Message = "User registered successfully." });
        }

        // Đăng nhập tài khoản
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UpdateAccountDto request)
        {
            var account = await _accountRepository.GetByUsernameAsync(request.Username);
            if (account == null || account.PasswordHash != HashPassword(request.Password))
            {
                return Unauthorized("Invalid username or password.");
            }

            string accessToken = GenerateToken(account.UserId, secretKey, DateTime.UtcNow.AddHours(1));
            string refreshToken = GenerateToken(account.UserId, refreshSecretKey, DateTime.UtcNow.AddDays(7));

            return Ok(new
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
                TokenType = "Bearer",
                ExpiredAt = DateTime.UtcNow.AddHours(1)
            });
        }

        // Quên mật khẩu
        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] string email)
        {
            var account = await _accountRepository.GetByUsernameAsync(email);
            if (account == null)
            {
                return NotFound("Email not registered.");
            }

            string resetToken = Guid.NewGuid().ToString();
            account.ResetToken = resetToken;
            await _accountRepository.UpdateAsync(account);

            string resetLink = Url.Action(nameof(ResetPassword), "Account", new { token = resetToken }, Request.Scheme);
            SendEmail(email, "Password Reset", $"Click the link to reset your password: {resetLink}");

            return Ok("Reset password email sent.");
        }

        // Reset mật khẩu
        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword(string token, [FromBody] string newPassword)
        {
            var account = await _accountRepository.GetByUserIdAsync(token);
            if (account == null || account.ResetToken != token)
            {
                return BadRequest("Invalid or expired token.");
            }

            account.PasswordHash = HashPassword(newPassword);
            account.ResetToken = null;

            await _accountRepository.UpdateAsync(account);

            return Ok("Password reset successfully.");
        }

        private void SendEmail(string toEmail, string subject, string body)
        {
            string smtpEmail = Environment.GetEnvironmentVariable("SMTP_EMAIL") ?? "your-email@example.com";
            string smtpPassword = Environment.GetEnvironmentVariable("SMTP_PASSWORD") ?? "your-password";

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
            return Convert.ToBase64String(sha256.ComputeHash(Encoding.UTF8.GetBytes(password)));
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

            return new JwtSecurityTokenHandler().WriteToken(new JwtSecurityTokenHandler().CreateToken(tokenDescriptor));
        }
    }
}
