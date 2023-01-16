using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;

namespace API.DTO
{
    public class LoginDTO
    {
        public string userName { get; set; }

        public string passwordHash { get; set; }

        public static implicit operator LoginDTO(User v)
        {
            throw new NotImplementedException();
        }
    }
}