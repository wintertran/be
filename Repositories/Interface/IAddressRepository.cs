using be.Models;

namespace be.Repositories.Interface
{
    public interface IAddressRepository : IGenericRepository<Address>
    {
        Task<List<Address>> GetAddressesByUserIdAsync(string userId);
        Task<Address?> GetAddressWithDetailsAsync(string addressId);
        Task ResetDefaultAddressAsync(string userId);

    }
}
