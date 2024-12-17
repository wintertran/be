using System.ComponentModel.DataAnnotations.Schema;

namespace be.DTOs
{
    public class AccountDto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public required string Id { get; set; }
        public required string UserId { get; set; }
        public string? Username { get; set; }

        public string? Password { get; set; }
    }

    public class CreateAccountDto
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
    }

    public class UpdateAccountDto
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
    }
}
