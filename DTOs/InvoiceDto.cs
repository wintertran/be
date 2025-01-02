using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace be.DTOs
{
    public class InvoiceDto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public required string Id { get; set; }
        public required string OrderId { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public double? TotalAmount { get; set; }
        public DateTime? DueDate { get; set; }
        public string? PaymentStatus { get; set; }
        public string? PaymentMethod { get; set; }
        public DateTime? CreatedAt { get; set; }
    }

    public class CreateInvoiceDto
    {
        public required string OrderId { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public double? TotalAmount { get; set; }
        public DateTime? DueDate { get; set; }
        public string? PaymentStatus { get; set; }
        public string? PaymentMethod { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
