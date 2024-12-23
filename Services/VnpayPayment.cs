using VNPAY.NET;

namespace be.Services
{
    public class VnpayPayment
    {
        private string _tmnCode;
        private string _hashSecret;
        private string _baseUrl;
        private string _callbackUrl;

        private readonly IVnpay _vnpay;

        public VnpayPayment(IVnpay vnpay, IConfiguration configuration)
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
        }
    }
}
