using be.DTOs;
using be.Models;
using be.Repositories.Interface;

public interface IProductRepository : IGenericRepository<Product>
{
    Task<(List<ProductDto> Products, int TotalCount)> GetProductsWithPagingAsync(int pageNumber, int pageSize);
    Task<(List<ProductDto> Products, int TotalCount, int AvailableCount)> SearchProductsAsync(
       string? keyword,
       List<string>? categories,
       List<string>? brands,
       decimal? priceFrom,
       decimal? priceTo,
       string sort);
}
