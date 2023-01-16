using System.ComponentModel.DataAnnotations.Schema;
using API.Enum;

namespace API.Entities
{
    public class Budget
    {
        public int id { get; set; }

        public Category category { get; set; }

        [ForeignKey("Category")]
        public int categoryid { get; set; }

        public User user { get; set; }
        
        [ForeignKey("User")]
        public int userid { get; set; }

        public long amount { get; set; }

        public int month { get; set; }

        public int year { get; set; }

        public BudgetStatus status { get; set; }
    }
}