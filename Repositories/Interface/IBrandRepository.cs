using be.DTOs;
using be.Models;

namespace be.Repositories.Interface
{
    public interface IBrandRepository : IGenericRepository<Brand>
    {
        Task<List<BrandDto>> GetBrandsWithProductCountAsync();
    }
}
