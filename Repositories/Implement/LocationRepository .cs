using be.Data;
using be.Models;
using be.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace be.Repositories.Implement
{
    public class LocationRepository : ILocationRepository
    {
        private readonly ApplicationDbContext _context;

        public LocationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Province>> GetAllProvincesAsync()
        {
            return await _context.Provinces.ToListAsync();
        }

        public async Task<IEnumerable<District>> GetDistrictsByProvinceIdAsync(string provinceId)
        {
            return await _context.Districts.Where(d => d.ProvinceId == provinceId).ToListAsync();
        }

        public async Task<IEnumerable<Ward>> GetWardsByDistrictIdAsync(string districtId)
        {
            return await _context.Wards.Where(w => w.DistrictId == districtId).ToListAsync();
        }
    }
}
