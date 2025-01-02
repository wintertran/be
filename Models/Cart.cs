using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace be.Models
{
    public class Cart
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public required string Id { get; set; }
        public required string UserId { get; set; } // Foreign key to User
        [ForeignKey("UserId")]
        public virtual User? User { get; set; } // Navigation property for User
        public int? Quantity { get; set; }
        public DateTime? AddedAt { get; set; }
        public string? Status { get; set; } // Enum for cart status
        public double? TotalAmount { get; set; }
        public bool? IsSavedForLater { get; set; }
        public virtual ICollection<CartProduct> CartProducts { get; set; } = new List<CartProduct>();
    }
}
