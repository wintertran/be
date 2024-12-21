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
                return NotFound(new { Message = "Cart not found." });
            }

            // Kiểm tra sản phẩm
            var product = await _productRepository.GetByIdAsync(request.ProductId);
            if (product == null)
            {
                return NotFound(new { Message = "Product not found." });
            }

            // Kiểm tra sản phẩm trong giỏ hàng
            var cartProduct = cart.CartProducts.FirstOrDefault(cp => cp.ProductId == request.ProductId);
            if (cartProduct == null)
            {
                return NotFound(new { Message = "Product not found in cart." });
            }

            // Cập nhật số lượng sản phẩm
            cartProduct.Product.CartQuantity += request.QuantityChange;

            // Xóa sản phẩm nếu số lượng <= 0
            if (cartProduct.Product.CartQuantity <= 0)
            {
                cart.CartProducts.Remove(cartProduct);
            }

            // Lưu thay đổi
            await _cartRepository.UpdateAsync(cart);

            return Ok(new { Message = "Cart updated successfully." });
        }



    }
    public class UpdateCartDto
    {
        public required string ProductId { get; set; } // ID sản phẩm
        public int QuantityChange { get; set; }       // Số lượng thay đổi (+/-)
    }
}
