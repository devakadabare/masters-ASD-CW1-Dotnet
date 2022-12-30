using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using API.Enum;

namespace API.Data
{
    public static class DbInitializer
    {
        public static void Initialize(StoreContext context)
        {
            if(context.Categories.Any())
            {
                return;
            }

            var categories = new List<Category>()
            {
                new Category() { name = "Food", description = "Food and drink", type=CategoryType.Expense, status=CategoryStatus.Active },
                new Category() { name = "Transport", description = "Transportation", type=CategoryType.Expense, status=CategoryStatus.Active },
                new Category() { name = "Entertainment", description = "Entertainment", type=CategoryType.Expense, status=CategoryStatus.Active },
                new Category() { name = "Health", description = "Health", type=CategoryType.Expense, status=CategoryStatus.Active },
                new Category() { name = "Education", description = "Education" , type=CategoryType.Expense, status=CategoryStatus.Active},
                new Category() { name = "Shopping", description = "Shopping", type=CategoryType.Expense, status=CategoryStatus.Active },
                new Category() { name = "Salary", description = "Salary",  type=CategoryType.Income, status=CategoryStatus.Active},
                new Category() { name = "Bonus", description = "Bonus",  type=CategoryType.Income, status=CategoryStatus.Active},
                new Category() { name = "Gift", description = "Gift",   type=CategoryType.Income, status=CategoryStatus.Active},
                new Category() { name = "Other", description = "Other",  type=CategoryType.Income, status=CategoryStatus.Active},
            };

            var accounts = new List<Account>()
            {
                new Account() { name = "Cash", description = "Cash", status=AccountStatus.Active },
                new Account() { name = "Bank", description = "Bank", status=AccountStatus.Active },
                new Account() { name = "Credit Card", description = "Credit Card", status=AccountStatus.Active },
                new Account() { name = "Debit Card", description = "Debit Card", status=AccountStatus.Active },
                new Account() { name = "Other", description = "Other", status=AccountStatus.Active },
            };

            context.Categories.AddRange(categories);
            context.Accounts.AddRange(accounts);

            context.SaveChanges();
        }
    }
}