using System.ComponentModel.DataAnnotations.Schema;

namespace be.DTOs
{
    public class CategoryDto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public required string Id { get; set; }
        public string? ParentCategoryId { get; set; }
        public required string Name { get; set; }
        public bool? IsAvailable { get; set; }
    }

    public class CreateCategoryDto
    {
        public string? ParentCategoryId { get; set; }
        public required string Name { get; set; }
        public bool? IsAvailable { get; set; }
    }

    public class UpdateCategoryDto
    {
        public string? Name { get; set; }
        public bool? IsAvailable { get; set; }
    }
}
