using be.Models;
using be.Repositories.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace be.Controllers
{
    public class CartController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;
        private readonly ICartRepository _cartRepository;
        private readonly IUserRepository _userRepository;
        private readonly IProductRepository _productRepository;
        public CartController(
            IAccountRepository accountRepository,
            IUserRepository userRepository,
            ICartRepository cartRepository,
            IProductRepository productRepository)
        {
            _accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _cartRepository = cartRepository ?? throw new ArgumentNullException(nameof(cartRepository));
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        [HttpGet("get")]
        [Authorize]
        public async Task<IActionResult> GetCart()
        {
            // Lấy UserId từ token
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized(new { Message = "Invalid or missing token." });
            }

            // Lấy giỏ hàng của người dùng
            var cart = await _cartRepository.GetCartByUserIdAsync(userId);

            // Nếu không có giỏ hàng, tạo mới giỏ hàng
            if (cart == null)
            {
                cart = new Cart
                {
                    Id = Guid.NewGuid().ToString(),
                    UserId = userId,
                    AddedAt = DateTime.UtcNow,
                    TotalAmount = 0,
                    Quantity = 0
                };
                await _cartRepository.AddAsync(cart); // Lưu vào cơ sở dữ liệu
            }

            var cartDto = new
            {
                cart.Id,
                cart.TotalAmount,
                cart.Quantity,
                Products = cart.CartProducts.Select(cp => new
                {
                    cp.ProductId,
                    cp.Product.Name,
                    cp.Product.Price,
                    cp.Product.ProductImages.FirstOrDefault()?.ImageUrl,
                    CartQuantity = cp.Quantity
                }).ToList()
            };

            return Ok(cartDto);
        }

        [HttpPost("update")]
        [Authorize]
        public async Task<IActionResult> UpdateCart([FromBody] UpdateCartDto request)
        {
            // Lấy UserId từ token
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized(new { Message = "Invalid or missing token." });
            }

            // Kiểm tra giỏ hàng của người dùng
            var cart = await _cartRepository.GetCartByUserIdAsync(userId);
            if (cart == null)
            {
                // Nếu không có giỏ hàng, tạo mới giỏ hàng
                cart = new Cart
                {
                    Id = Guid.NewGuid().ToString(),
                    UserId = userId,
                    AddedAt = DateTime.UtcNow,
                    TotalAmount = 0,
                    Quantity = 0,
                    CartProducts = new List<CartProduct>()
                };
                await _cartRepository.AddAsync(cart);
            }

            // Kiểm tra sản phẩm trong cơ sở dữ liệu
            var product = await _productRepository.GetByIdAsync(request.ProductId);
            if (product == null)
            {
                return NotFound(new { Message = "Product not found." });
            }

            // Kiểm tra sản phẩm trong giỏ hàng
            var cartProduct = cart.CartProducts.FirstOrDefault(cp => cp.ProductId == request.ProductId);

            if (cartProduct == null)
            {
                // Nếu sản phẩm chưa có trong giỏ hàng, thêm mới
                cartProduct = new CartProduct
                {
                    CartId = cart.Id,
                    ProductId = product.Id,
                    Quantity = request.QuantityChange > 0 ? request.QuantityChange : 0 // Chỉ thêm nếu số lượng hợp lệ
                };

                cart.CartProducts.Add(cartProduct);
            }
            else
            {
                // Nếu sản phẩm đã tồn tại, cập nhật số lượng
                cartProduct.Quantity += request.QuantityChange;

                // Xóa sản phẩm nếu số lượng <= 0
                if (cartProduct.Quantity <= 0)
                {
                    cart.CartProducts.Remove(cartProduct);
                }
            }

            // Tính toán lại tổng số lượng và tổng tiền
            cart.Quantity = cart.CartProducts.Sum(cp => cp.Quantity);
            cart.TotalAmount = cart.CartProducts.Sum(cp => cp.Quantity * product.Price ?? 0);

            // Lưu thay đổi
            await _cartRepository.UpdateAsync(cart);

            return Ok(new { Message = "Cart updated successfully." });
        }
        [HttpDelete("reset")]
        [Authorize]
        public async Task<IActionResult> ResetCart()
        {
            // Lấy UserId từ token
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized(new { Message = "Invalid or missing token." });
            }

            // Lấy giỏ hàng của người dùng
            var cart = await _cartRepository.GetCartByUserIdAsync(userId);
            if (cart == null)
            {
                return NotFound(new { Message = "Cart not found." });
            }

            // Xóa giỏ hàng
            await _cartRepository.DeleteAsync(cart);

            return Ok(new { Message = "Cart has been reset successfully." });
        }
    }

        public class UpdateCartDto
    {
        public required string ProductId { get; set; } // ID sản phẩm
        public int QuantityChange { get; set; }       // Số lượng thay đổi (+/-)
    }
}
