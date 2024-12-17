using System.ComponentModel.DataAnnotations.Schema;

namespace be.DTOs
{
    public class RoleDto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public required string Id { get; set; }
        public required string UserId { get; set; }
        public string? RoleName { get; set; }
    }

    public class CreateRoleDto
    {
        public required string UserId { get; set; }
        public string? RoleName { get; set; }
    }
}
