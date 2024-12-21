using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace be.Models
{
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public required string Id { get; set; }
        public required string CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category? Category { get; set; } // Navigation Property
        public required string Name { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public string? ImageUrl { get; set; }
        public string? Sku { get; set; }
        public string? Brand { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool? IsAvailable { get; set; }
        public decimal? StockQuantity { get; set; }
        public decimal? CartQuantity { get; set; }
        public virtual ICollection<CartProduct> CartProducts { get; set; } = new List<CartProduct>();
        public virtual ICollection<Rating>? Ratings { get; set; }
    }
}
