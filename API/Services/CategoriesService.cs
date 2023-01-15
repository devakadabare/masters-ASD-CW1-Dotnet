using API.Data;
using API.DTO;
using API.Entities;
using API.Interface;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class CategoriesService: ICategoriesService
    {
        private readonly StoreContext _context;
        public CategoriesService(StoreContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> GetCategories()
        {
            var transactions = await _context.Categories.ToListAsync();
            return transactions;
        }

        public async Task<Category?> GetCategory(int id)
        {
            var transaction = await _context.Categories.FindAsync(id);
            return transaction;
        }

        public async Task<Category> CreateCategory(CategoryDTO category)
        {
            var newCategory = new Category
            {
                name = category.name,
                type = (Enum.CategoryType)category.type,
                description = category.description,
                status = Enum.CategoryStatus.Active
            };
            var result = _context.Categories.Add(newCategory);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Category> UpdateCategory(int id, CategoryUpdateDTO category)
        {
            var updateCategory = await _context.Categories.FindAsync(id);

            updateCategory.name = category.name;
            updateCategory.type = (Enum.CategoryType)category.type;
            updateCategory.description = category.description;
            updateCategory.status = Enum.CategoryStatus.Active;

            _context.Categories.Update(updateCategory);
            await _context.SaveChangesAsync();
            
            return updateCategory;
        }
    }
}