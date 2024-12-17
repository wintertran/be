using be.Models;

namespace be.Repositories.Interface
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<bool> ExistsByIdAsync(string categoryId);
        Task<IEnumerable<Category>> GetSubcategoriesAsync(string parentCategoryId);
        Task<Category?> GetCategoriesNameAsync(string name);
    }
}
