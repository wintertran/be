using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace be.DTOs
{
    public class CartDto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public required string Id { get; set; }
        public required string UserId { get; set; }
        public required string ProductId { get; set; }
        public int? Quantity { get; set; }
        public DateTime? AddedAt { get; set; }
        public string? Status { get; set; }
        public double TotalAmount { get; set; }
        public bool? IsSavedForLater { get; set; }
    }
    public class CreateCartDto
    {
        public required string UserId { get; set; }
        public required string ProductId { get; set; }
        public int? Quantity { get; set; }
        public DateTime? AddedAt { get; set; }
        public string? Status { get; set; }
        public double TotalAmount { get; set; }
        public bool? IsSavedForLater { get; set; }
    }
}
