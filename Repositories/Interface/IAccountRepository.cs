using be.Models;
using System.Threading.Tasks;

namespace be.Repositories.Interface
{
    public interface IAccountRepository
    {
        Task<Account?> GetByUserIdAsync(string userId);
        Task<Account?> GetByUsernameAsync(string username);
        Task<bool> UsernameExistsAsync(string username);
        Task AddAsync(Account account);
        Task UpdateAsync(Account account); // Thêm UpdateAsync
        Task DeleteAsync(string userId);
    }
}
