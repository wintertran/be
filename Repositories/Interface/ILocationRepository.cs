using be.Models;

namespace be.Repositories.Interface
{
    public interface ILocationRepository
    {
        Task<IEnumerable<Province>> GetAllProvincesAsync();
        Task<IEnumerable<District>> GetDistrictsByProvinceIdAsync(string provinceId);
        Task<IEnumerable<Ward>> GetWardsByDistrictIdAsync(string districtId);
    }
}
