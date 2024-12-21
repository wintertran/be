using be.DTOs;
using be.Models;
using be.Repositories.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text.Json;

namespace be.Controllers
{
    [ApiController]
    [Route("api/order")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICartRepository _cartRepository;

        public OrderController(IOrderRepository orderRepository, ICartRepository cartRepository)
        {
            _orderRepository = orderRepository;
            _cartRepository = cartRepository;
        }

        [HttpPost("create")]
        [Authorize]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderDto request)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized(new { Message = "Invalid or missing token." });
            }

            // Lấy giỏ hàng
            var cart = await _cartRepository.GetCartByUserIdAsync(userId);
            if (cart == null || !cart.CartProducts.Any())
            {
                return BadRequest(new { Message = "Cart is empty or not found." });
            }

            string cartSnapshot = JsonSerializer.Serialize(new
            {
                Products = cart.CartProducts.Select(cp => new
                {
                    cp.ProductId,
                    cp.Product.Name,
                    cp.Product.Price,
                    cp.Product.CartQuantity,
                    ImageUrl = cp.Product.ProductImages.FirstOrDefault()?.ImageUrl
                }).ToList(), // Đảm bảo kiểu dữ liệu hợp lệ
                cart.TotalAmount,
                cart.Quantity
            });

            // Tạo đơn hàng mới
            var order = new Order
            {
                Id = Guid.NewGuid().ToString(),
                UserId = userId,
                ShippingAddressId = request.ShippingAddressId,
                TotalAmount = cart.TotalAmount,
                CartSnapshot = cartSnapshot,
                Status = "Pending",
                PaymentMethod = request.PaymentMethod,
                OrderDate = DateTime.UtcNow
            };

            await _orderRepository.AddAsync(order);

            // Xóa giỏ hàng sau khi tạo đơn hàng
            await _cartRepository.DeleteAsync(cart);

            return Ok(new { Message = "Order created successfully.", OrderId = order.Id });
        }


        [HttpGet("get/{orderId}")]
        [Authorize]
        public async Task<IActionResult> GetOrder(string orderId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized(new { Message = "Invalid or missing token." });
            }

            var order = await _orderRepository.GetByIdAsync(orderId);
            if (order == null || order.UserId != userId)
            {
                return NotFound(new { Message = "Order not found or unauthorized." });
            }

            // Deserialize CartSnapshot
            var cartDetails = string.IsNullOrEmpty(order.CartSnapshot)
                ? null
                : JsonSerializer.Deserialize<object>(order.CartSnapshot);

            return Ok(new
            {
                order.Id,
                order.Status,
                order.PaymentMethod,
                order.OrderDate,
                order.ShippingDate,
                TotalAmount = order.TotalAmount,
                Address = new
                {
                    order.Address?.StreetAddress,
                    order.Address?.Province,
                    order.Address?.District,
                    order.Address?.Ward
                },
                CartDetails = cartDetails
            });
        }

        [HttpDelete("delete/{orderId}")]
        [Authorize]
        public async Task<IActionResult> DeleteOrder(string orderId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized(new { Message = "Invalid or missing token." });
            }

            var order = await _orderRepository.GetByIdAsync(orderId);
            if (order == null || order.UserId != userId)
            {
                return NotFound(new { Message = "Order not found or unauthorized." });
            }

            await _orderRepository.DeleteAsync(order);

            return Ok(new { Message = "Order deleted successfully." });
        }
    }

}
