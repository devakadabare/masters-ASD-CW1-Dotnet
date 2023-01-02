using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Enum;

namespace API.Entities
{
    public class Category
    {
        public int id { get; set; }

        public string name { get; set; }

        public string? description { get; set; }

        public CategoryType type { get; set;}

        public CategoryStatus status { get; set; }

        public ICollection<Transaction>? transactions { get; set; }

    }
}