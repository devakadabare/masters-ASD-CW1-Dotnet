using API.Data;
using API.Entities;
using API.Enum;
using API.Interface;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class BudgetService: IBudgetService
    {
        private readonly StoreContext _context;

        public BudgetService(StoreContext context)
        {
            _context = context;
        }

        public async Task<List<Budget>> GetBudgets()
        {
            return await _context.Budgets.ToListAsync();
        }

        public async Task<Budget?> GetBudget(int id)
        {
            var budget = await _context.Budgets.FindAsync(id);
            return budget;
        }

        public async Task<Budget> CreateBudget(BudgetDTO budget)
        {
            var newBudget = new Budget
            {
                categoryid = budget.categoryid,
                amount = budget.amount,
                month = budget.month,
                year = budget.year,
                user = await _context.Users.FindAsync(budget.userid),
                status = BudgetStatus.Active
            };

            var result =_context.Budgets.Add(newBudget);
            await _context.SaveChangesAsync();
            return newBudget;
        }

        public async Task<Budget> UpdateBudget(int id, Budget budget)
        {
            var updateBudget = await _context.Budgets.FindAsync(id);

            updateBudget.categoryid = budget.categoryid;
            updateBudget.amount = budget.amount;
            updateBudget.month = budget.month;
            updateBudget.year = budget.year;
            updateBudget.status = budget.status;

            _context.Budgets.Update(updateBudget);
            await _context.SaveChangesAsync();

            return updateBudget;
        }
    }
}