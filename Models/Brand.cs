using System.ComponentModel.DataAnnotations.Schema;

namespace be.Models
{
    public class Brand
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public required string Id { get; set; }

        public string? ImgUrl { get; set; }
        public required string Name { get; set; } // Tên thương hiệu
        public virtual ICollection<Product>? Products { get; set; } = new List<Product>(); // Danh sách sản phẩm thuộc thương hiệu này
    }
}
