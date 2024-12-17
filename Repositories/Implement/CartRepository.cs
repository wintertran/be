using be.Data;
using be.Models;
using be.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace be.Repositories.Implement
{
    public class CartRepository : GenericRepository<Cart>, ICartRepository
    {
        public CartRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<Cart>> GetCartItemsByUserIdAsync(string userId)
        {
            return await _context.Carts.Where(c => c.UserId == userId).ToListAsync();
        }
    }
}
