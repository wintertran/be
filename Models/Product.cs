﻿using System;
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
        public double? Price { get; set; }
        public string? Sku { get; set; }
        public string? BrandId { get; set; }
        [ForeignKey("BrandId")]
        public virtual Brand? Brand { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool? IsAvailable { get; set; }
        public double? StockQuantity { get; set; }
        public double? CartQuantity { get; set; }
        public virtual ICollection<ProductImage>? ProductImages { get; set; } = new List<ProductImage>();
        public virtual ICollection<CartProduct>? CartProducts { get; set; } = new List<CartProduct>();
        public virtual ICollection<Rating>? Ratings { get; set; }
    }
}
