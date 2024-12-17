using be.Models;

namespace be.Repositories.Interface
{
    public interface IRatingRepository : IGenericRepository<Rating>
    {
        Task<IEnumerable<Rating>> GetRatingsByProductIdAsync(string productId);
        Task<double?> GetAverageRatingAsync(string productId);
    }
}
