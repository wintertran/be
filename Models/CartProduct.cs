namespace be.Models
{
    public class CartProduct
    {
        public required string CartId { get; set; }
        public virtual Cart Cart { get; set; } = null!;

        public required string ProductId { get; set; }
        public virtual Product Product { get; set; } = null!;

    }
}