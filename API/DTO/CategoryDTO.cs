using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Enum;

namespace API.DTO
{
    public class CategoryDTO
    {
        public string name { get; set; }

        public string? description { get; set; }

        public int? userid { get; set; }

        public CategoryType type { get; set;}
    }
}