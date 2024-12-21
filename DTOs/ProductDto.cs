using be.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace be.DTOs
{
    public class ProductDto
    {
        public string Id { get; set; } = string.Empty;

        public string CategoryId { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public List<ImageDto> Images { get; set; } = new List<ImageDto>(); // List of images
        public string? Description { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Price must be a positive value")]
        public decimal? Price { get; set; }

        [MaxLength(50, ErrorMessage = "SKU cannot exceed 50 characters")]
        public string? Sku { get; set; }

        // Thêm khóa ngoại cho Brand
        public string? BrandId { get; set; }
        [ForeignKey("BrandId")]
        public virtual Brand? Brand { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public bool? IsAvailable { get; set; }
        public decimal? StockQuantity { get; set; }
        public decimal? CartQuantity { get; set; }
        public double? AverageRating { get; set; } // Thêm Rating trung bình
        public List<string>? Reviews { get; set; } // Danh sách Review
    }

    public class CreateProductDto
    {
        [Required(ErrorMessage = "CategoryId is required")]
        public string CategoryId { get; set; } = string.Empty;

        [Required(ErrorMessage = "Name is required")]
        [MaxLength(100, ErrorMessage = "Name cannot exceed 100 characters")]
        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Price must be a positive value")]
        public decimal? Price { get; set; }

        [MaxLength(50, ErrorMessage = "SKU cannot exceed 50 characters")]
        public string? Sku { get; set; }

        // Thêm khóa ngoại cho Brand
        public string? BrandId { get; set; }
        [ForeignKey("BrandId")]
        public virtual Brand? Brand { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public bool IsAvailable { get; set; } = true;
    }

    public class UpdateProductDto
    {
        [MaxLength(100, ErrorMessage = "Name cannot exceed 100 characters")]
        public string? Name { get; set; }

        public string? Description { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Price must be a positive value")]
        public decimal? Price { get; set; }

        [MaxLength(50, ErrorMessage = "SKU cannot exceed 50 characters")]
        public string? Sku { get; set; }

        // Thêm khóa ngoại cho Brand
        public string? BrandId { get; set; }
        [ForeignKey("BrandId")]
        public virtual Brand? Brand { get; set; }

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public bool? IsAvailable { get; set; }
    }

    public class ImageDto
    {
        public string ImageUrl { get; set; }
    }
}
