using be.Data;
using be.Models;
using be.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace be.Repositories.Implement
{
    public class AddressRepository : GenericRepository<Address>, IAddressRepository
    {
        private new readonly ApplicationDbContext _context;

        public AddressRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Address>> GetAddressesByUserIdAsync(string userId)
        {
            return await _context.Addresses.Where(a => a.UserId == userId).ToListAsync();
        }
        public async Task<Address?> GetAddressWithDetailsAsync(string addressId)
        {
            return await _context.Addresses
                .Include(a => a.Province)
                .Include(a => a.District)
                .Include(a => a.Ward)
                .FirstOrDefaultAsync(a => a.Id == addressId);
        }
        public async Task ResetDefaultAddressAsync(string userId)
        {
            var defaultAddresses = await _context.Addresses
                .Where(a => a.UserId == userId && a.IsDefault == true)
                .ToListAsync();

            foreach (var address in defaultAddresses)
            {
                address.IsDefault = false;
            }

            if (defaultAddresses.Any())
            {
                await _context.SaveChangesAsync();
            }
        }
    }
}
