
using API.DTO;
using API.Entities;
using API.Services;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController: ControllerBase
    {
        private readonly CategoriesService _categoryService;
        public CategoriesController(CategoriesService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Category>>> GetCategories()
        {
            return await _categoryService.GetCategories();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Category?>> GetCategory(int id)
        {
            return await _categoryService.GetCategory(id);
        }

        [HttpPost("create")]
        public async Task<ActionResult<Category>> CreateCategory(CategoryDTO category)
        {
            return await _categoryService.CreateCategory(category);
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult<Category>> UpdateCategory(int id, CategoryUpdateDTO category)
        {
            var updateCategory = await _categoryService.GetCategory(id);

            if(updateCategory == null)
                return NotFound();

            return await _categoryService.UpdateCategory(id, category);
        }
    }
}