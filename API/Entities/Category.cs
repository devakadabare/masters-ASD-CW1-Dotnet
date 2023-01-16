using System.ComponentModel.DataAnnotations.Schema;
using API.Enum;

namespace API.Entities
{
    public class Category
    {
        public int id { get; set; }

        public string name { get; set; }

        public string? description { get; set; }

        public User? user { get; set; }
        
        [ForeignKey("User")]
        public int? userid { get; set; }

        public CategoryType type { get; set;}

        public CategoryStatus status { get; set; }

        public ICollection<Transaction>? transactions { get; set; }

    }
}