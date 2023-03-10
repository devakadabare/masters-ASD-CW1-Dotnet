using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Enum;

namespace API.DTO
{
    public class TransactionDTO
    {

        public long amout { get; set; }

        public string? note { get; set; }

        public DateTime date { get; set; }

        public TransactionType type { get; set; }

        public int? categoryId { get; set; } 

        public int accountId { get; set; }

        public int? transferAccountId { get; set; }

    }

    
}