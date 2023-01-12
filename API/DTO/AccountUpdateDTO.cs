using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;

namespace API.DTO
{
    public class AccountUpdateDTO
    {
        public string name { get; set; }

        public string? description { get; set; }

        public long balance { get; set; }

        public AccountStatus status { get; set; }
    }
}