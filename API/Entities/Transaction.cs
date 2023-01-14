using System.ComponentModel.DataAnnotations.Schema;
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

        public Account account { get; set; }

        [ForeignKey("Account")]
        public int accountid { get; set; }

        public Category? category { get; set; }

        [ForeignKey("Category")] 
        public int? categoryid { get; set; }

        public CreditDebitIndicator creditDebitIndicator { get; set; }

        public TransactionStatus status { get; set; }

    }

}