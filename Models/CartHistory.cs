using System.ComponentModel.DataAnnotations.Schema;

public class CartHistory
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public required string Id { get; set; }
    public required string UserId { get; set; }
    public string? CartData { get; set; } // Lưu thông tin giỏ hàng dưới dạng JSON
    public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
}
