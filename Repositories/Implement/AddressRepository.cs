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
    }
}
