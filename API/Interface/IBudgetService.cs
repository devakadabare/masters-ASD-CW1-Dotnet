using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using API.Services;

namespace API.Interface
{
    public interface IBudgetService
    {
        public Task<List<Budget>> GetBudgets();

        public Task<Budget?> GetBudget(int id);

        public Task<Budget> CreateBudget(BudgetDTO budget);

        public Task<Budget> UpdateBudget(int id, Budget budget);
    }
}