namespace be.DTOs
{
    public class BrandDto
    {
        public string Id { get; set; } // ID của thương hiệu
        public string Name { get; set; } // Tên thương hiệu
        public string ImgUrl { get; set; }
        public int ProductCount { get; set; } // Số lượng sản phẩm thuộc thương hiệu
    }
}