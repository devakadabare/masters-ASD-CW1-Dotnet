
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    public class Account
    {
        public int id { get; set; }

        public string name { get; set; }

        public string? description { get; set; }

        public long balance { get; set; }

        public User? user { get; set; }

        [ForeignKey("User")]
        public int? userid { get; set; }

        public AccountStatus status { get; set; }

        public ICollection<Transaction>? transactions { get; set; }
    }
    
}