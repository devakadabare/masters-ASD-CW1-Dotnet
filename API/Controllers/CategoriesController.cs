using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.DTO;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController: ControllerBase
    {
        private readonly StoreContext _context;
        public CategoriesController(StoreContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Category>>> GetCategories()
        {
            var transactions = await _context.Categories.ToListAsync();
            return Ok(transactions);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            var transaction = await _context.Categories.FindAsync(id);
            return Ok(transaction);
        }

        [HttpPost("create")]
        public async Task<ActionResult<Category>> CreateCategory(CategoryDTO category)
        {
            var newCategory = new Category
            {
                name = category.name,
                type = (Enum.CategoryType)category.type,
                description = category.description,
                status = category.status
            };
            var result = _context.Categories.Add(newCategory);
            await _context.SaveChangesAsync();
            return Ok(result);
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult<Category>> UpdateCategory(int id, CategoryDTO category)
        {
            var updateCategory = await _context.Categories.FindAsync(id);

            if(updateCategory == null)
                return NotFound();

            updateCategory.name = category.name;
            updateCategory.type = (Enum.CategoryType)category.type;
            updateCategory.description = category.description;
            updateCategory.status = category.status;

            _context.Categories.Update(updateCategory);
            await _context.SaveChangesAsync();
            
            return Ok(updateCategory);
        }
    }
}