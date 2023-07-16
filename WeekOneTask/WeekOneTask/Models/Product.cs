namespace WeekOneTask.Models
{
    public class Product : AddProductModel
    {
        public int Id { get; set; } = new Random().Next(1,99999);
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
