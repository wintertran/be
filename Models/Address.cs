using System.ComponentModel.DataAnnotations.Schema;

namespace be.Models
{
    public class Address
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public required string Id { get; set; }
        public required string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User? User { get; set; } // Navigation Property
        public string? StreetAddress { get; set; }
        public string? Province { get; set; }
        public string? District { get; set; }
        public string? Ward { get; set; }
        public bool? IsDefault { get; set; }
    }
}
