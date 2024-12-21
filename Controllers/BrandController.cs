using be.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class BrandController : ControllerBase
{
    private readonly IBrandRepository _brandRepository;

    public BrandController(IBrandRepository brandRepository)
    {
        _brandRepository = brandRepository;
    }

    [HttpGet("list")]
    public async Task<IActionResult> GetBrandsWithProductCount()
    {
        var brands = await _brandRepository.GetBrandsWithProductCountAsync();
        return Ok(brands);
    }
}
