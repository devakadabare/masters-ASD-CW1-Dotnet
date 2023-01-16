using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTO
{
    public class UserCreateDTO
    {
        public string userName { get; set; }
        public string passwordHash { get; set; }
        public string firstName { get; set; }
        public string? lastName { get; set; }
        public string email { get; set; }

    }
}