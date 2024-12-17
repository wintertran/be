using be.Models;
using System.Threading.Tasks;

namespace be.Repositories.Interface
{
    public interface IAccountRepository
    {
        Task<Account> GetByUserIdAsync(string userId); // Lấy thông tin tài khoản người dùng theo userId
        Task<Account> GetByUsernameAsync(string username); // Lấy thông tin tài khoản theo username
        Task AddAsync(Account account); // Thêm tài khoản mới
        Task UpdateAsync(Account account); // Cập nhật tài khoản
        Task DeleteAsync(string userId); // Xóa tài khoản
    }
}
