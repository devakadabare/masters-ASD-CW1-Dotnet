using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class Category
    {
        public int id { get; set; }

        public string name { get; set; }

        public string? description { get; set; }

        public CategoryType type { get; set;}

        public CategoryStatus status { get; set; }

    }

    public enum CategoryType
    {
        Income = 1,
        Expense = 2
    }

    public enum CategoryStatus {
        Active = 1,
        Inactive = 2
    }
}