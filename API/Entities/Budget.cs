using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Enum;

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
}