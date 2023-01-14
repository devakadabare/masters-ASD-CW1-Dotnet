using API.Entities;
using API.Enum;

namespace API.Interface
{
     public interface ITransaction
    {
      
        long amout { get; set; }

        string? note { get; set; }

        DateTime date { get; set; }

        TransactionType type { get; set; }

        Account account { get; set; }

        Category? category { get; set; }

    }
}