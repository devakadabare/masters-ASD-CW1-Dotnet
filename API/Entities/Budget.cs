using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class Budget
    {
        public int id { get; set; }

        public int categoryId { get; set; }

        public long amount { get; set; }

        public int month { get; set; }

        public int year { get; set; }

        public BudgetStatus status { get; set; }
    }

    public enum BudgetStatus {
        Active = 1,
        Inactive = 2
    }
}