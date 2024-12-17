using System.ComponentModel.DataAnnotations.Schema;

namespace be.Models
{
    public class Category
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public required string Id { get; set; }
        public string? ParentCategoryId { get; set; }
        public required string Name { get; set; }
        public bool? IsAvailable { get; set; }
        public virtual ICollection<Product>? Products { get; set; }
    }
}
