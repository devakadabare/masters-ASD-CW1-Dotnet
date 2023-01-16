using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class User
    {
        public int id { get; set; }
        public string userName { get; set; }
        public string passwordHash { get; set; }
        public string firstName { get; set; }
        public string? lastName { get; set; }
        public string email { get; set; }

        public ICollection<Account>? Accounts { get; set; }
        public ICollection<Category>? Categories { get; set; }
        public ICollection<Transaction>? Transactions { get; set; }
        public ICollection<Budget>? Budget { get; set; }

    }
}