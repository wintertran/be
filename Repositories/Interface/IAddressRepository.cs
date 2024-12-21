using be.Models;

namespace be.Repositories.Interface
{
    public interface IAddressRepository : IGenericRepository<Address>
    {
        Task<List<Address>> GetAddressesByUserIdAsync(string userId);

    }
}
