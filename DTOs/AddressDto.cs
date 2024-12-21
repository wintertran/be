using System.ComponentModel.DataAnnotations.Schema;

namespace be.DTOs
{
    public class AddressDto
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public required string Id { get; set; }
        public required string UserId { get; set; }
        public string? StreetAddress { get; set; }
        public string? Province { get; set; }
        public string? District { get; set; }
        public string? Ward { get; set; }
        public bool? IsDefault { get; set; }
    }
    public class CreateAddressDto
    {
        public string? StreetAddress { get; set; }
        public string? Province { get; set; }
        public string? District { get; set; }
        public string? Ward { get; set; }
        public bool? IsDefault { get; set; }
    }
    public class UpdateAddressDto
    {
        public string? StreetAddress { get; set; }
        public string? Province { get; set; }
        public string? District { get; set; }
        public string? Ward { get; set; }
        public bool? IsDefault { get; set; }
    }
}
