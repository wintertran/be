using be.Models;

namespace be.Repositories.Interface
{
    public interface ICartRepository : IGenericRepository<Cart>
    {
        Task<IEnumerable<Cart>> GetCartItemsByUserIdAsync(string userId);
    }
}
