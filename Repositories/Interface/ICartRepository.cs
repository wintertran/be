using be.Models;

namespace be.Repositories.Interface
{
    public interface ICartRepository : IGenericRepository<Cart>
    {
        Task<Cart?> GetCartByUserIdAsync(string userId);
        Task AddAsync(Cart cart);
        Task UpdateAsync(Cart cart);

        Task DeleteAsync(Cart cart);
    }
}
