namespace DataAccess.Models
{
    public class BoatCategoryModel
    {
        public int Id { get; set; }
        public required string Category { get; set; }
        public float HourlyPrice { get; set; }
        public float BasePrice { get; set; }
    }
}
