using be.Data;
using be.Models;
using be.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace be.Repositories.Implement
{
    public class RatingRepository : GenericRepository<Rating>, IRatingRepository
    {
        public RatingRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<Rating>> GetRatingsByProductIdAsync(string productId)
        {
            return await _context.Ratings.Where(r => r.ProductId == productId).ToListAsync();
        }

        public async Task<double?> GetAverageRatingAsync(string productId)
        {
            var ratings = await _context.Ratings
                .Where(r => r.ProductId == productId)
                .Select(r => r.RatingValue)
                .ToListAsync();

            return ratings.Any() ? ratings.Average() : null;
        }
    }
}
