using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace be.DTOs
{
    public class RatingDto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public required string Id { get; set; }
        public required string UserId { get; set; }
        public required string ProductId { get; set; }
        public int? RatingValue { get; set; }
        public string? Review { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }

    public class CreateRatingDto
    {
        public required string UserId { get; set; }
        public required string ProductId { get; set; }
        public int? RatingValue { get; set; }
        public string? Review { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
