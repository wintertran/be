using System.ComponentModel.DataAnnotations.Schema;

namespace be.Models
{
    public class ProductImage
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public required string Id { get; set; }
        public required string ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product? Product { get; set; } // Navigation Property
        public required string ImageUrl { get; set; } // URL of the image
        public DateTime? CreatedAt { get; set; }
    }
}