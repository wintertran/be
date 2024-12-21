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
        public CartController(IAccountRepository accountRepository, IUserRepository userRepository)
        {
            _accountRepository = accountRepository;
            _userRepository = userRepository;
        }

        [HttpPost("add")]
        [Authorize]
        public async Task<IActionResult> AddToCart([FromBody] AddToCartDto request)
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
                cart = new Cart
                {
                    Id = Guid.NewGuid().ToString(),
                    UserId = userId,
                    AddedAt = DateTime.UtcNow
                };
                await _cartRepository.AddAsync(cart);
            }

            // Kiểm tra sản phẩm
            var product = await _productRepository.GetByIdAsync(request.ProductId);
            if (product == null)
            {
                return NotFound(new { Message = "Product not found." });
            }

            // Thêm sản phẩm vào giỏ hàng
            var cartProduct = cart.CartProducts.FirstOrDefault(cp => cp.ProductId == request.ProductId);
            if (cartProduct != null)
            {
                cartProduct.Product.CartQuantity += request.Quantity;
            }
            else
            {
                cart.CartProducts.Add(new CartProduct
                {
                    CartId = cart.Id,
                    ProductId = product.Id,
                    cartProduct.Product.CartQuantity = request.Quantity
                });
            }

            await _cartRepository.UpdateAsync(cart);

            return Ok(new { Message = "Product added to cart successfully." });
        }


    }
    public class AddToCartDto
    {
        public required string ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
