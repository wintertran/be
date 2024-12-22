using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace be.DTOs
{
    public class AddressDto
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public required string Id { get; set; }
        public required string UserId { get; set; }
        public string? StreetAddress { get; set; }
        public string? ProvinceId { get; set; }
        public string? DistrictId { get; set; }
        public string? WardId { get; set; }
        public bool? IsDefault { get; set; }
    }
    public class CreateAddressDto
    {
        [Required]
        [StringLength(255, ErrorMessage = "Street address cannot exceed 255 characters.")]
        public string? StreetAddress { get; set; }

        [Required]
        public string? ProvinceId { get; set; }

        [Required]
        public string? DistrictId { get; set; }

        [Required]
        public string? WardId { get; set; }

        public bool? IsDefault { get; set; }
    }
    public class UpdateAddressDto
    {
        public string? StreetAddress { get; set; }
        public string? ProvinceId { get; set; }
        public string? DistrictId { get; set; }
        public string? WardId { get; set; }
        public bool? IsDefault { get; set; }
    }
}
