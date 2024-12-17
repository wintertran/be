using be.Data;
using be.Models;
using be.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace be.Repositories.Implement
{
    public class InvoiceRepository : GenericRepository<Invoice>, IInvoiceRepository
    {
        public InvoiceRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<Invoice>> GetInvoicesByOrderIdAsync(string orderId)
        {
            return await _context.Invoices.Where(i => i.OrderId == orderId).ToListAsync();
        }
    }
}
