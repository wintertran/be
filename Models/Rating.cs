using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace be.Models
{
    public class Rating
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public required string Id { get; set; }
        public required string UserId { get; set; }
        public required string ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product? Product { get; set; } // Navigation Property

        public int? RatingValue { get; set; } // Enum for rating values could be considered
        public string? Review { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
