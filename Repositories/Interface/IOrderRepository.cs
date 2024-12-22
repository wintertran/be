using be.Models;

namespace be.Repositories.Interface
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task<Order?> GetOrderWithDetailsAsync(string orderId);
        Task<IEnumerable<Order>> GetOrdersByUserIdAsync(string userId);
    }
}
