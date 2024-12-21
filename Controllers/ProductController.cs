using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductRepository _productRepository;

    public ProductController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    [HttpGet("getProductByPaging")]
    public async Task<IActionResult> GetProductsWithPaging([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 20)
    {
        var result = await _productRepository.GetProductsWithPagingAsync(pageNumber, pageSize);
        return Ok(new
        {
            PageNumber = pageNumber,
            PageSize = pageSize,
            TotalCount = result.TotalCount,
            Products = result.Products
        });
    }
    [HttpGet("search")]
    public async Task<IActionResult> SearchProducts(
    [FromQuery] string keyword,
    [FromQuery] List<string> category,
    [FromQuery] List<string> brand,
    [FromQuery] decimal? priceFrom,
    [FromQuery] decimal? priceTo,
    [FromQuery] string sort = "AtoZ")
    {
        var result = await _productRepository.SearchProductsAsync(
            keyword, category, brand, priceFrom, priceTo, sort);

        return Ok(new
        {
            TotalCount = result.TotalCount,
            AvailableCount = result.AvailableCount,
            Products = result.Products
        });
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductById(string id)
    {
        var product = await _productRepository.GetByIdAsync(id);

        if (product == null)
        {
            return NotFound(new { Message = "Product not found." });
        }

        return Ok(new
        {
            product.Id,
            product.Name,
            product.Price,
            product.StockQuantity,
            product.ImageUrl,
            product.Description,
            Category = product.Category?.Name, // Nếu cần hiển thị tên Category
            Ratings = product.Ratings?.Select(r => new
            {
                r.RatingValue,
                r.Review
            })
        });
    }

}
