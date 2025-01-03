﻿using be.Data;
using be.DTOs;
using be.Models;
using Microsoft.EntityFrameworkCore;

public class ProductRepository : GenericRepository<Product>, IProductRepository
{
    private readonly ApplicationDbContext _context;

    public ProductRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<(List<ProductDto> Products, int TotalCount)> GetProductsWithPagingAsync(int pageNumber, int pageSize)
    {
        var query = _context.Products
                            .Include(p => p.Category)
                            .Include(p => p.Ratings)
                            .Include(p => p.ProductImages); // Include ProductImages

        var totalCount = await query.CountAsync();

        var products = await query
            .OrderBy(p => p.Name)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .Select(p => new ProductDto
            {
                Id = p.Id,
                CategoryId = p.CategoryId,
                Name = p.Name,
                Price = p.Price,
                Images = p.ProductImages.Select(img => new ImageDto
                {
                    ImageUrl = img.ImageUrl,
                }).ToList(),
                StockQuantity = p.StockQuantity,
                IsAvailable = p.IsAvailable,
                AverageRating = p.Ratings.Any() ? p.Ratings.Average(r => r.RatingValue) : 0,
                Reviews = p.Ratings.Select(r => r.Review).ToList()
            })
            .ToListAsync();

        return (products, totalCount);
    }

    public async Task<(List<ProductDto> Products, int TotalCount, int AvailableCount)> SearchProductsAsync(
        string? keyword,
        int pageNumber,
        int pageSize,
        List<string>? categories,
        List<string>? brands,
        double? priceFrom,
        double? priceTo,
        string sort)
    {
        // Ensure pageNumber and pageSize are valid
        pageNumber = pageNumber < 1 ? 1 : pageNumber;
        pageSize = pageSize < 1 ? 12 : pageSize;

        // Base query
        var query = _context.Products
                            .Include(p => p.Category)
                            .Include(p => p.Ratings)
                            .Include(p => p.ProductImages)
                            .AsQueryable();

        // Filters
        if (!string.IsNullOrEmpty(keyword))
            query = query.Where(p => p.Name.Contains(keyword) || p.Description.Contains(keyword));

        if (categories != null && categories.Any())
            query = query.Where(p => categories.Contains(p.CategoryId));

        if (brands != null && brands.Any())
            query = query.Where(p => brands.Contains(p.BrandId));

        if (priceFrom.HasValue)
            query = query.Where(p => p.Price >= priceFrom.Value);

        if (priceTo.HasValue)
            query = query.Where(p => p.Price <= priceTo.Value);

        // Sorting
        query = sort switch
        {
            "AtoZ" => query.OrderBy(p => p.Name),
            "CheapToExpensive" => query.OrderBy(p => p.Price),
            "ExpensiveToCheap" => query.OrderByDescending(p => p.Price),
            "NewToOld" => query.OrderByDescending(p => p.CreatedAt),
            "OldToNew" => query.OrderBy(p => p.CreatedAt),
            _ => query.OrderBy(p => p.Name), // Default: A → Z
        };

        // Total product count
        var totalCount = await query.CountAsync();

        // Available product count
        var availableCount = await query.CountAsync(p => p.IsAvailable??true);

        // Apply pagination
        var products = await query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .Select(p => new ProductDto
            {
                Id = p.Id,
                CategoryId = p.CategoryId,
                Name = p.Name,
                Price = p.Price,
                Description = p.Description,
                StockQuantity = p.StockQuantity,
                IsAvailable = p.IsAvailable,
                Images = p.ProductImages.Select(img => new ImageDto
                {
                    ImageUrl = img.ImageUrl,
                }).ToList(),
                AverageRating = p.Ratings.Any() ? p.Ratings.Average(r => r.RatingValue) : 0,
                Reviews = p.Ratings.Select(r => r.Review).ToList()
            })
            .ToListAsync();

        return (products, totalCount, availableCount);
    }



    public async Task<Product?> GetByIdAsync(string id)
    {
        return await _context.Products
                             .Include(p => p.Category) // Include Category
                             .Include(p => p.Ratings) // Include Ratings
                             .Include(p => p.ProductImages) // Include ProductImages
                             .FirstOrDefaultAsync(p => p.Id == id);
    }

}

