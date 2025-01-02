using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using VNPAY.NET;
using VNPAY.NET.Enums;
using VNPAY.NET.Models;
using System;
using VNPAY.NET.Utilities;
using be.Repositories.Interface;

namespace be.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VnPayPaymentController : ControllerBase
    {
        private readonly IVnpay _vnpay;
        private readonly string _tmnCode;
        private readonly string _hashSecret;
        private readonly string _baseUrl;
        private readonly string _callbackUrl;
        private readonly IOrderRepository _orderRepository;

        public VnPayPaymentController(IVnpay vnpay, IConfiguration configuration, IOrderRepository orderRepository)
        {
            _tmnCode = configuration["Vnpay:TmnCode"];
            _hashSecret = configuration["Vnpay:HashSecret"];
            _baseUrl = configuration["Vnpay:BaseUrl"];
            _callbackUrl = configuration["Vnpay:ReturnUrl"];
            Console.WriteLine($"TmnCode: {_tmnCode}");
            Console.WriteLine($"HashSecret: {_hashSecret}");
            Console.WriteLine($"BaseUrl: {_baseUrl}");
            Console.WriteLine($"CallbackUrl: {_callbackUrl}");
            _vnpay = vnpay;
            _vnpay.Initialize(_tmnCode, _hashSecret, _baseUrl, _callbackUrl);
            _orderRepository = orderRepository;
        }

        [HttpGet("CreatePaymentUrl")]
        public async Task<ActionResult<string>> CreatePaymentUrl(string orderId)
        {
            try
            {
                var order = await _orderRepository.GetByIdAsync(orderId);
                if (order == null)
                {
                    return NotFound("Order not found.");
                }

                var ipAddress = NetworkHelper.GetIpAddress(HttpContext); // Lấy địa chỉ IP của thiết bị thực hiện giao dịch

                var request = new PaymentRequest
                {
                    PaymentId = DateTime.Now.Ticks,
                    Money = order.TotalAmount,
                    Description = order.Id,
                    IpAddress = ipAddress,
                    BankCode = BankCode.ANY,
                    CreatedDate = DateTime.Now,
                    Currency = Currency.VND,
                    Language = DisplayLanguage.Vietnamese
                };

                var paymentUrl = _vnpay.GetPaymentUrl(request);

                return Created(paymentUrl, paymentUrl);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("IpnAction")]
        public async Task<IActionResult> IpnAction()
        {
            if (Request.QueryString.HasValue)
            {
                try
                {
                    var paymentResult = _vnpay.GetPaymentResult(Request.Query);
                    if (paymentResult.IsSuccess)
                    {
                        // Cập nhật trạng thái đơn hàng nếu thanh toán thành công
                        var orderId = paymentResult.PaymentResponse.Description; // Giả sử OrderId được gửi kèm trong PaymentRequest
                        var order = await _orderRepository.GetByIdAsync(orderId);
                        if (order != null)
                        {
                            order.Status = "Paid";
                            await _orderRepository.UpdateAsync(order);
                        }

                        return Ok();
                    }

                    // Thực hiện hành động nếu thanh toán thất bại tại đây. Ví dụ: Hủy đơn hàng.
                    return BadRequest("Thanh toán thất bại");
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }

            return NotFound("Không tìm thấy thông tin thanh toán.");
        }

        [HttpGet("Callback")]
        public async Task<ActionResult<string>> Callback()
        {
            if (Request.QueryString.HasValue)
            {
                try
                {
                    var paymentResult = _vnpay.GetPaymentResult(Request.Query);
                    var resultDescription = $"{paymentResult.PaymentResponse.Description}. {paymentResult.TransactionStatus.Description}.";

                    if (paymentResult.IsSuccess)
                    {
                        // Cập nhật trạng thái đơn hàng nếu thanh toán thành công
                        var orderId = paymentResult.PaymentResponse.Description; // Giả sử OrderId được gửi kèm trong PaymentRequest
                        var order = await _orderRepository.GetByIdAsync(orderId);
                        if (order != null)
                        {
                            order.Status = "Paid";
                            await _orderRepository.UpdateAsync(order);
                        }

                        return Ok(resultDescription);
                    }

                    return BadRequest(resultDescription);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }

            return NotFound("Không tìm thấy thông tin thanh toán.");
        }
    }
}
