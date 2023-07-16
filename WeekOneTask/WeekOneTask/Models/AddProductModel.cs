using System.ComponentModel.DataAnnotations;

namespace WeekOneTask.Models
{
    public class AddProductModel
    {
        [Required]
        public string Name { get; set; }
        public int Quantity { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}
