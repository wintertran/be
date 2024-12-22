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
    public async Task<IActionResult> GetProductsWithPaging([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 12)
    {
        var result = await _productRepository.GetProductsWithPagingAsync(pageNumber, pageSize);
        return Ok(new
        {
            TotalCount = result.TotalCount,
            Products = result.Products,
            Pagination = new
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalPages = (int)Math.Ceiling((double)result.TotalCount / pageSize)
            }
        });
    }
    [HttpGet("search")]
    public async Task<IActionResult> SearchProducts(
    [FromQuery] string? keyword,
    [FromQuery] List<string>? categories,
    [FromQuery] List<string>? brands,
    [FromQuery] decimal? priceFrom,
    [FromQuery] decimal? priceTo,
    [FromQuery] string sort = "AtoZ",
    [FromQuery] int pageNumber = 1,
    [FromQuery] int pageSize = 12)
    {
        // Validate pageNumber and pageSize
        if (pageNumber < 1 || pageSize < 1)
        {
            return BadRequest(new { Message = "Page number and page size must be greater than 0." });
        }

        var result = await _productRepository.SearchProductsAsync(
            keyword, pageNumber, pageSize, categories, brands, priceFrom, priceTo, sort);

        return Ok(new
        {
            TotalCount = result.TotalCount,
            AvailableCount = result.AvailableCount,
            Products = result.Products,
            Pagination = new
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalPages = (int)Math.Ceiling((double)result.TotalCount / pageSize)
            }
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
            Images = product.ProductImages?.Select(img => new
            {
                img.ImageUrl,
            }),
            product.Description,
            Category = product.Category?.Name, // Nếu cần hiển thị tên Category
            AverageRating = product.Ratings.Any() ? product.Ratings.Average(r => r.RatingValue) : 0,
            Ratings = product.Ratings?.Select(r => new
            {
                r.RatingValue,
                r.Review
            })
        });
    }

}
