using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTO;
using API.Entities;

namespace API.Interface
{
    public interface ICategoriesService
    {
        public Task<List<Category>> GetCategories();

        public Task<Category?> GetCategory(int id);

        public Task<Category> CreateCategory(CategoryDTO category);
        
        public Task<Category> UpdateCategory(int id, CategoryUpdateDTO category);
    }
}