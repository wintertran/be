using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace be.DTOs
{
    public class OrderDto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public required string Id { get; set; }
        public required string ShippingAddressId { get; set; }
        public required string CartId { get; set; }
        public decimal? TotalAmount { get; set; }
        public string? Status { get; set; }
        public string? PaymentMethod { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? ShippingDate { get; set; }
    }

    public class CreateOrderDto
    {
        public required string ShippingAddressId { get; set; }
        public required string CartId { get; set; }
        public string? PaymentMethod { get; set; }
    }
}
