using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Enum;
using API.Interface;

namespace API.Entities
{
    public class Transaction: ITransaction
    {
        public int id { get; set; }

        public long amout { get; set; }

        public string? note { get; set; }

        public DateTime date { get; set; }

        public TransactionType type { get; set; }

        public int? categoryId { get; set; } 

        public int accountId { get; set; }

    }

}