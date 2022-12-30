using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Enum;

namespace API.Interface
{
     public interface ITransaction
    {
      
        long amout { get; set; }

        string? note { get; set; }

        DateTime date { get; set; }

        TransactionType type { get; set; }

        int? categoryId { get; set; } 

        int accountId { get; set; }


    }
}