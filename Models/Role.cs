using System.ComponentModel.DataAnnotations.Schema;

namespace be.Models
{
    public class Role
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public required string Id { get; set; }
        public required string UserId { get; set; }
        public string? RoleName { get; set; }
    }
}
