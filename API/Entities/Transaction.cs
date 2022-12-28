using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class Transaction
    {
        public int id { get; set; }

        public long amout { get; set; }

        public string? note { get; set; }

        public DateTime date { get; set; }

        public TransactionType type { get; set; }

        public int? categoryId { get; set; } 

        public int? accountId { get; set; }

        public int? transferAccountId { get; set; }

    }

    public enum TransactionType
    {
        Income = 1,
        Expense = 2, 
        Transfer = 3
    }
}