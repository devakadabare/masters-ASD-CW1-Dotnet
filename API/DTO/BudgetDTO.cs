namespace API.Services
{
    public class BudgetDTO
    {
        public int id { get; set; }

        public int categoryid { get; set; }

        public long amount { get; set; }

        public int month { get; set; }

        public int year { get; set; }

        public int userid { get; set; }
    }
}