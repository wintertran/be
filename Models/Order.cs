using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace be.Models
{
    public class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public required string Id { get; set; }
        public required string UserId { get; set; }
        public required string ShippingAddressId { get; set; }
        public required string CartId { get; set; }
        public decimal? TotalAmount { get; set; }
        public string? Status { get; set; } // Enum for order status could be considered
        public string? PaymentMethod { get; set; } // Enum for payment method
        public DateTime? OrderDate { get; set; }
        public DateTime? ShippingDate { get; set; }
    }
}
