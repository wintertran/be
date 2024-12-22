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
        // Cấu hình Contract Resolver để ánh xạ
        var settings = new JsonSerializerSettings
        {
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new SnakeCaseNamingStrategy()
            }
        };

        // Seed Provinces
        if (context.Provinces.Any())
        {
            context.Provinces.RemoveRange(context.Provinces);
        }
        var provincesJson = File.ReadAllText("Data/Seed/Province.json");
        var provinces = JsonConvert.DeserializeObject<List<Province>>(provincesJson, settings);
        context.Provinces.AddRange(provinces);

        // Seed Districts
        if (context.Districts.Any())
        {
            context.Districts.RemoveRange(context.Districts);
        }
        var districtsJson = File.ReadAllText("Data/Seed/District.json");
        var districts = JsonConvert.DeserializeObject<List<District>>(districtsJson, settings);
        context.Districts.AddRange(districts);

        // Seed Wards
        if (context.Wards.Any())
        {
            context.Wards.RemoveRange(context.Wards);
        }
        var wardsJson = File.ReadAllText("Data/Seed/Ward.json");
        var wards = JsonConvert.DeserializeObject<List<Ward>>(wardsJson, settings);
        context.Wards.AddRange(wards);

        // Save all changes
        context.SaveChanges();
    }
}
