using be.DTOs;
using be.Models;
using be.Repositories.Interface;

public interface IProductRepository : IGenericRepository<Product>
{
    Task<(List<ProductDto> Products, int TotalCount)> GetProductsWithPagingAsync(int pageNumber, int pageSize);
    Task<(List<ProductDto> Products, int TotalCount, int AvailableCount)> SearchProductsAsync(
       string? keyword,
       int pageNumber,
       int pageSize,
       List<string>? categories,
       List<string>? brands,
       double? priceFrom,
       double? priceTo,
       string sort);
}
