using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace be.Models
{
    public class Invoice
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public required string Id { get; set; }
        public required string OrderId { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public decimal? TotalAmount { get; set; }
        public DateTime? DueDate { get; set; }
        public string? PaymentStatus { get; set; } // Enum for payment status
        public string? PaymentMethod { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
