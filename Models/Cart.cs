using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace be.Models
{
    public class Cart
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public required string Id { get; set; }
        public required string UserId { get; set; }
        public required string ProductId { get; set; }
        public int? Quantity { get; set; }
        public DateTime? AddedAt { get; set; }
        public string? Status { get; set; } // Enum for cart status
        public decimal? TotalAmount { get; set; }
        public bool? IsSavedForLater { get; set; }
    }
}
