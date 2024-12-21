using be.DTOs;
using be.Models;
using be.Repositories.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace be.Controllers
{
    [ApiController]
    [Route("api/address")]
    public class AddressController : ControllerBase
    {
        private readonly IAddressRepository _addressRepository;

        public AddressController(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        /// <summary>
        /// Lấy danh sách địa chỉ của người dùng
        /// </summary>
        [HttpGet("get")]
        [Authorize]
        public async Task<IActionResult> GetAddresses()
        {
            // Lấy UserId từ token
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized(new { Message = "Invalid or missing token." });
            }

            var addresses = await _addressRepository.GetAddressesByUserIdAsync(userId);
            return Ok(addresses.Select(a => new
            {
                a.Id,
                a.StreetAddress,
                a.Province,
                a.District,
                a.Ward,
                a.IsDefault
            }));
        }

        /// <summary>
        /// Thêm địa chỉ mới cho người dùng
        /// </summary>
        [HttpPost("add")]
        [Authorize]
        public async Task<IActionResult> AddAddress([FromBody] CreateAddressDto request)
        {
            // Lấy UserId từ token
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized(new { Message = "Invalid or missing token." });
            }

            // Nếu là địa chỉ mặc định, hủy các địa chỉ mặc định hiện tại
            if (request.IsDefault == true)
            {
                var existingAddresses = await _addressRepository.GetAddressesByUserIdAsync(userId);
                foreach (var addr in existingAddresses)
                {
                    addr.IsDefault = false;
                    await _addressRepository.UpdateAsync(addr);
                }
            }

            var address = new Address
            {
                Id = Guid.NewGuid().ToString(),
                UserId = userId,
                StreetAddress = request.StreetAddress,
                Province = request.Province,
                District = request.District,
                Ward = request.Ward,
                IsDefault = request.IsDefault
            };

            await _addressRepository.AddAsync(address);
            return Ok(new { Message = "Address added successfully.", AddressId = address.Id });
        }

        /// <summary>
        /// Cập nhật thông tin địa chỉ
        /// </summary>
        [HttpPut("update/{addressId}")]
        [Authorize]
        public async Task<IActionResult> UpdateAddress(string addressId, [FromBody] UpdateAddressDto request)
        {
            // Lấy UserId từ token
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized(new { Message = "Invalid or missing token." });
            }

            // Tìm địa chỉ cần cập nhật
            var address = await _addressRepository.GetByIdAsync(addressId);
            if (address == null || address.UserId != userId)
            {
                return NotFound(new { Message = "Address not found or unauthorized." });
            }

            // Cập nhật thông tin
            address.StreetAddress = request.StreetAddress ?? address.StreetAddress;
            address.Province = request.Province ?? address.Province;
            address.District = request.District ?? address.District;
            address.Ward = request.Ward ?? address.Ward;

            // Xử lý địa chỉ mặc định
            if (request.IsDefault == true)
            {
                var existingAddresses = await _addressRepository.GetAddressesByUserIdAsync(userId);
                foreach (var addr in existingAddresses)
                {
                    addr.IsDefault = false;
                    await _addressRepository.UpdateAsync(addr);
                }
                address.IsDefault = true;
            }

            await _addressRepository.UpdateAsync(address);
            return Ok(new { Message = "Address updated successfully." });
        }

        /// <summary>
        /// Xóa địa chỉ
        /// </summary>
        [HttpDelete("delete/{addressId}")]
        [Authorize]
        public async Task<IActionResult> DeleteAddress(string addressId)
        {
            // Lấy UserId từ token
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized(new { Message = "Invalid or missing token." });
            }

            // Tìm địa chỉ cần xóa
            var address = await _addressRepository.GetByIdAsync(addressId);
            if (address == null || address.UserId != userId)
            {
                return NotFound(new { Message = "Address not found or unauthorized." });
            }

            await _addressRepository.DeleteAsync(address);
            return Ok(new { Message = "Address deleted successfully." });
        }
    }

}
