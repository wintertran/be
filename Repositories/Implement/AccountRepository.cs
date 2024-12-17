using be.Data;
using be.Models;
using be.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace be.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ApplicationDbContext _context;

        public AccountRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Kiểm tra Username tồn tại
        public async Task<bool> UsernameExistsAsync(string username)
        {
            return await _context.Accounts.AnyAsync(a => a.Username == username);
        }

        // Thêm tài khoản mới
        public async Task AddAsync(Account account)
        {
            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();
        }

        // Cập nhật tài khoản
        public async Task UpdateAsync(Account account)
        {
            var existingAccount = await _context.Accounts.FindAsync(account.Id);
            if (existingAccount != null)
            {
                // Gán giá trị mới vào tài khoản hiện tại
                existingAccount.Username = account.Username;
                existingAccount.PasswordHash = account.PasswordHash;
                existingAccount.ResetToken = account.ResetToken;

                // Cập nhật vào cơ sở dữ liệu
                _context.Accounts.Update(existingAccount);
                await _context.SaveChangesAsync();
            }
        }

        // Xóa tài khoản
        public async Task DeleteAsync(string userId)
        {
            var account = await _context.Accounts.FirstOrDefaultAsync(a => a.UserId == userId);
            if (account != null)
            {
                _context.Accounts.Remove(account);
                await _context.SaveChangesAsync();
            }
        }

        // Lấy tài khoản theo UserId
        public async Task<Account?> GetByUserIdAsync(string userId)
        {
            return await _context.Accounts.FirstOrDefaultAsync(a => a.UserId == userId);
        }

        // Lấy tài khoản theo Username
        public async Task<Account?> GetByUsernameAsync(string username)
        {
            return await _context.Accounts.FirstOrDefaultAsync(a => a.Username == username);
        }
    }
}
