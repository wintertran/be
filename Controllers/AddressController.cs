﻿using be.DTOs;
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
        private readonly ILogger<AddressController> _logger;

        public AddressController(IAddressRepository addressRepository, ILogger<AddressController> logger)
        {
            _addressRepository = addressRepository;
            _logger = logger;
        }

        /// <summary>
        /// Lấy danh sách địa chỉ của người dùng
        /// </summary>
        [HttpGet("get")]
        [Authorize]
        public async Task<IActionResult> GetAddressDetails(string addressId)
        {
            // Lấy UserId từ token
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized(new { Message = "Invalid or missing token." });
            }

            // Lấy Address cùng với thông tin liên quan
            var address = await _addressRepository.GetAddressWithDetailsAsync(addressId);

            if (address == null || address.UserId != userId)
            {
                return NotFound(new { Message = "Address not found or unauthorized." });
            }

            // Trả về dữ liệu chi tiết của địa chỉ
            return Ok(new
            {
                address.Id,
                address.StreetAddress,
                Province = new
                {
                    address.Province?.Id,
                    address.Province?.Name,
                    address.Province?.NameEn
                },
                District = new
                {
                    address.District?.Id,
                    address.District?.Name,
                    address.District?.NameEn
                },
                Ward = new
                {
                    address.Ward?.Id,
                    address.Ward?.Name,
                    address.Ward?.NameEn
                },
                address.IsDefault
            });
        }

        /// <summary>
        /// Thêm địa chỉ mới cho người dùng
        /// </summary>
        [HttpPost("add")]
        [Authorize]
        public async Task<IActionResult> AddAddress([FromBody] CreateAddressDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Lấy UserId từ token
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
            {
                _logger.LogWarning("Unauthorized access attempt to AddAddress.");
                return Unauthorized(new { Message = "Invalid or missing token." });
            }

            // Kiểm tra nếu địa chỉ mặc định thì cập nhật các địa chỉ hiện tại
            if (request.IsDefault == true)
            {
                await _addressRepository.ResetDefaultAddressAsync(userId);
            }

            // Tạo địa chỉ mới
            var address = new Address
            {
                Id = Guid.NewGuid().ToString(),
                UserId = userId,
                StreetAddress = request.StreetAddress,
                ProvinceId = request.ProvinceId,
                DistrictId = request.DistrictId,
                WardId = request.WardId,
                IsDefault = request.IsDefault
            };

            await _addressRepository.AddAsync(address);
            _logger.LogInformation("Address added for UserId: {UserId}, AddressId: {AddressId}", userId, address.Id);

            return Ok(new { Message = "Address added successfully.", AddressId = address.Id });
        }

        /// <summary>
        /// Cập nhật thông tin địa chỉ
        /// </summary>
        [HttpPut("update/{addressId}")]
        [Authorize]
        public async Task<IActionResult> UpdateAddress(string addressId, [FromBody] UpdateAddressDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Lấy UserId từ token
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
            {
                _logger.LogWarning("Unauthorized access attempt to UpdateAddress.");
                return Unauthorized(new { Message = "Invalid or missing token." });
            }

            // Tìm địa chỉ cần cập nhật
            var address = await _addressRepository.GetByIdAsync(addressId);
            if (address == null || address.UserId != userId)
            {
                return NotFound(new { Message = "Address not found or unauthorized." });
            }

            // Cập nhật thông tin địa chỉ
            address.StreetAddress = request.StreetAddress ?? address.StreetAddress;
            address.ProvinceId = request.ProvinceId ?? address.ProvinceId;
            address.DistrictId = request.DistrictId ?? address.DistrictId;
            address.WardId = request.WardId ?? address.WardId;

            // Xử lý địa chỉ mặc định
            if (request.IsDefault == true)
            {
                await _addressRepository.ResetDefaultAddressAsync(userId);
                address.IsDefault = true;
            }

            await _addressRepository.UpdateAsync(address);
            _logger.LogInformation("Address updated for UserId: {UserId}, AddressId: {AddressId}", userId, address.Id);

            return Ok(new { Message = "Address updated successfully." });
        }

        /// <summary>
        /// Xóa địa chỉ
        /// </summary>
        [HttpDelete("delete/{addressId}")]
        [Authorize]
        public async Task<IActionResult> DeleteAddress(string addressId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
            {
                _logger.LogWarning("Unauthorized access attempt to DeleteAddress.");
                return Unauthorized(new { Message = "Invalid or missing token." });
            }

            var address = await _addressRepository.GetByIdAsync(addressId);
            if (address == null || address.UserId != userId)
            {
                return NotFound(new { Message = "Address not found or unauthorized." });
            }

            await _addressRepository.DeleteAsync(address);
            _logger.LogInformation("Address deleted for UserId: {UserId}, AddressId: {AddressId}", userId, addressId);

            return NoContent();
        }
    }
}
