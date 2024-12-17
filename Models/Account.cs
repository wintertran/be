using System.ComponentModel.DataAnnotations.Schema;

namespace be.Models
{
    public class Account
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public required string Id { get; set; }
        public required string UserId { get; set; }
        public required string Username { get; set; }
        public string? PasswordHash { get; set; } // Mật khẩu đã được băm
        public string? ResetToken { get; set; }
    }
}
