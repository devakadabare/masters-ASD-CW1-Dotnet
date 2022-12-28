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

        public AccountStatus status { get; set; }
    }

    public enum AccountStatus {
        Active = 1,
        Inactive = 2
    }
}