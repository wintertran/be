using be.Data;
using be.Models;
using be.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace be.Repositories.Implement
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context) : base(context) { }
        public async Task<bool> ExistsByIdAsync(string categoryId)
        {
            return await _context.Categories.AnyAsync(c => c.Id == categoryId);
        }
        public async Task<IEnumerable<Category>> GetSubcategoriesAsync(string parentCategoryId)
        {
            return await _context.Categories.Where(c => c.ParentCategoryId == parentCategoryId).ToListAsync();
        }
        public async Task<Category?> GetCategoriesNameAsync(string name)
        {
            return await _context.Categories.FirstOrDefaultAsync(c => c.Name == name);
        }
    }
}
