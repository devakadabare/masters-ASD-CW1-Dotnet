using API.Entities;
using API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class BudgetController: ControllerBase
    {
        private readonly BudgetService _budgetService;

        public BudgetController(BudgetService budgetService)
        {
            _budgetService = budgetService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Budget>>> GetBudgets()
        {
            var result = await _budgetService.GetBudgets();
            return result;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Budget?>> GetBudget(int id)
        {
            var result = await _budgetService.GetBudget(id);
            return result;
        }

        [HttpPost("create")]
        public async Task<ActionResult<Budget>> CreateBudget(BudgetDTO budget)
        {
            if(budget == null)
            {
                return BadRequest();
            }

            //create new budget
            var result = await _budgetService.CreateBudget(budget);

            return Ok();
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult<Budget>> UpdateBudget(int id, Budget budget)
        {
            var updateBudget = await _budgetService.GetBudget(id);

            if(updateBudget == null)
                return NotFound();

            var result = await _budgetService.UpdateBudget(id, budget);

            return result;
        }
        
    }
}