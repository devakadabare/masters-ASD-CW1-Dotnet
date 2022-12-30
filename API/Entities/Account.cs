using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class Account
    {
        public int id { get; set; }

        public string name { get; set; }

        public string? description { get; set; }

        public long balance { get; set; }

        public AccountStatus status { get; set; }

        public ICollection<Transaction>? transactions { get; set; }
    }
    
}