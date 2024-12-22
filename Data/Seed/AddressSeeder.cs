using be.Data;
using be.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.IO;

public static class AddressSeeder
{
    public static void SeedData(ApplicationDbContext context)
    {
        var settings = new JsonSerializerSettings
        {
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new SnakeCaseNamingStrategy()
            }
        };

        // Xóa dữ liệu cũ trước khi seed mới
        context.Wards.RemoveRange(context.Wards);
        context.Districts.RemoveRange(context.Districts);
        context.Provinces.RemoveRange(context.Provinces);
        context.SaveChanges();

        // Seed Provinces
        if (!context.Provinces.Any())
        {
            var provincesJson = File.ReadAllText("Data/Seed/Province.json");
            var provinces = JsonConvert.DeserializeObject<List<Province>>(provincesJson, settings);
            context.Provinces.AddRange(provinces);

        }

        // Seed Districts
        if (!context.Districts.Any())
        {
            var districtsJson = File.ReadAllText("Data/Seed/District.json");
            var districts = JsonConvert.DeserializeObject<List<District>>(districtsJson, settings);

            foreach (var district in districts)
            {
                var province = context.Provinces.FirstOrDefault(p => p.Id == district.ProvinceId);
                if (province != null)
                {
                    district.ProvinceId = province.Id;
                }
            }

            context.Districts.AddRange(districts);
        }

        // Seed Wards
        if (!context.Wards.Any())
        {
            var wardsJson = File.ReadAllText("Data/Seed/Ward.json");
            var wards = JsonConvert.DeserializeObject<List<Ward>>(wardsJson, settings);

            foreach (var ward in wards)
            {
                var district = context.Districts.FirstOrDefault(d => d.Id == ward.DistrictId);
                if (district != null)
                {
                    ward.DistrictId = district.Id;
                }
            }

            context.Wards.AddRange(wards);
        }
        context.SaveChanges();
    }
}
