using be.Data;
using be.Models;
using be.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace be.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ApplicationDbContext _context;

        public AccountRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Lấy tài khoản người dùng theo userId
        public async Task<Account> GetByUserIdAsync(string userId)
        {
            return await _context.Accounts
                .FirstOrDefaultAsync(account => account.UserId == userId);
        }

        // Lấy tài khoản người dùng theo username
        public async Task<Account> GetByUsernameAsync(string username)
        {
            return await _context.Accounts
                .FirstOrDefaultAsync(account => account.Username == username);
        }

        // Thêm tài khoản mới
        public async Task AddAsync(Account account)
        {
            await _context.Accounts.AddAsync(account);
            await _context.SaveChangesAsync();
        }

        // Cập nhật tài khoản
        public async Task UpdateAsync(Account account)
        {
            _context.Accounts.Update(account);
            await _context.SaveChangesAsync();
        }

        // Xóa tài khoản
        public async Task DeleteAsync(string userId)
        {
            var account = await _context.Accounts
                .FirstOrDefaultAsync(account => account.UserId == userId);

            if (account != null)
            {
                _context.Accounts.Remove(account);
                await _context.SaveChangesAsync();
            }
        }
    }
}
