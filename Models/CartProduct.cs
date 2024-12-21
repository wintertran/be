using System.ComponentModel.DataAnnotations.Schema;

namespace be.Models
{
    public class CartProduct
    {
        public required string CartId { get; set; }
        [ForeignKey("CartId")]
        public virtual Cart Cart { get; set; } = null!;

        public required string ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; } = null!;
        public int Quantity { get; set; }

    }
}