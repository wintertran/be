using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace be.Models
{
    public class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public required string Id { get; set; }
        public required string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User? User { get; set; } // Navigation Property
        public required string ShippingAddressId { get; set; }
        [ForeignKey("ShippingAddressId")]
        public virtual Address? Address { get; set; } // Navigation Property
        public string? CartSnapshot { get; set; }
        public virtual Cart? Cart { get; set; } // Navigation Property
        public double TotalAmount { get; set; }
        public string? Status { get; set; } // Enum for order status could be considered
        public string? PaymentMethod { get; set; } // Enum for payment method
        public DateTime? OrderDate { get; set; }
        public DateTime? ShippingDate { get; set; }
    }
}
