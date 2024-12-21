using be.Data;
using be.DTOs;
using be.Models;
using be.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

public class BrandRepository : GenericRepository<Brand>, IBrandRepository
{
    private new readonly ApplicationDbContext _context;

    public BrandRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<BrandDto>> GetBrandsWithProductCountAsync()
    {
        return await _context.Brands
            .Include(b => b.Products)
            .Select(b => new BrandDto
            {
                Id = b.Id,
                Name = b.Name,
                ProductCount = b.Products.Count()
            })
            .ToListAsync();
    }
}
