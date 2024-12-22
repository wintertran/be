using be.Data;
using be.Models;
using be.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace be.Repositories.Implement
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        private new readonly ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Order?> GetOrderWithDetailsAsync(string orderId)
        {
            return await _context.Orders
                                 .Include(o => o.Address)
                                 .Include(o => o.Cart)
                                 .ThenInclude(c => c.CartProducts)
                                 .ThenInclude(cp => cp.Product)
                                 .ThenInclude(p => p.ProductImages)
                                 .FirstOrDefaultAsync(o => o.Id == orderId);
        }
        public async Task<IEnumerable<Order>> GetOrdersByUserIdAsync(string userId)
        {
            return await _context.Orders
                .Include(o => o.Address) // Nếu có Address liên kết
                .Where(o => o.UserId == userId)
                .ToListAsync();
        }
    }
}
