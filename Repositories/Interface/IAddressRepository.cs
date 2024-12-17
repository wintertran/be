using be.Models;

namespace be.Repositories.Interface
{
    public interface IAddressRepository : IGenericRepository<Address>
    {
        Task<IEnumerable<Address>> GetAddressesByUserIdAsync(string userId);
    }
}
