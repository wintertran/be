using be.Models;

namespace be.Repositories.Interface
{
    public interface IInvoiceRepository : IGenericRepository<Invoice>
    {
        Task<IEnumerable<Invoice>> GetInvoicesByOrderIdAsync(string orderId);
    }
}
