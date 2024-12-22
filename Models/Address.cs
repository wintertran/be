using System.ComponentModel.DataAnnotations.Schema;

namespace be.Models
{
    public class Address
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public required string Id { get; set; }
        public required string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User? User { get; set; } // Navigation Property
        public string? StreetAddress { get; set; }
        public string? ProvinceId { get; set; }
        [ForeignKey("ProvinceId")]
        public Province? Province { get; set; }

        public string? DistrictId { get; set; }
        [ForeignKey("DistrictId")]
        public District? District { get; set; }
        public string? WardId { get; set; }
        [ForeignKey("WardId")]
        public Ward? Ward { get; set; }
        public bool? IsDefault { get; set; }
    }
    public class Province
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? NameEn { get; set; }
        public string? FullName { get; set; }
        public string? FullNameEn { get; set; }
        public string? CodeName { get; set; }
        public int AdministrativeUnitsId { get; set; }
        public int AdministrativeRegionId { get; set; }
        public ICollection<District>? Districts { get; set; }
    }

    public class District
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? NameEn { get; set; }
        public string? FullName { get; set; }
        public string? FullNameEn { get; set; }
        public string? CodeName { get; set; }
        public string? ProvinceId { get; set; }
        [ForeignKey("ProvinceId")]
        public Province? Province { get; set; }
        public ICollection<Ward>? Wards { get; set; }
    }

    public class Ward
    {
        public required string Id { get; set; }
        public string? Name { get; set; }
        public string? NameEn { get; set; }
        public string? FullName { get; set; }
        public string? FullNameEn { get; set; }
        public string? CodeName { get; set; }
        public string? DistrictId { get; set; }
        [ForeignKey("DistrictId")]
        public District? District { get; set; }
    }

}
