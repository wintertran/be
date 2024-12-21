using System.ComponentModel.DataAnnotations.Schema;

namespace be.Models
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public required string Id { get; set; }
        public string? Name { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Gender { get; set; } // Consider using an enum for Gender
        public string? DateOfBirth { get; set; }

        public string? ResetToken { get; set; } // Thêm trường này để lưu token

        public virtual Cart? Cart { get; set; }
    }
}
