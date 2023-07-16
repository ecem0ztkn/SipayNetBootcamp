using WeekOneTask.Models;

namespace WeekOneTask
{
    public class Data
    {
        public static List<Product> Products = new List<Product> {
            new Product
            {
                Id = 1,
                Name= "Test",
                Quantity = 1,
                Price = 1,
                CreatedDate= DateTime.Now,
                UpdatedDate = DateTime.Now
            },
            new Product
            {
                Id = 2,
                Name= "Test1",
                Quantity = 1,
                Price = 2,
                CreatedDate= DateTime.Now,
                UpdatedDate = DateTime.Now
            },
            new Product
            {
                Id = 3,
                Name= "Test2",
                Quantity = 1,
                Price = 1,
                CreatedDate= DateTime.Now,
                UpdatedDate = DateTime.Now
            }
        };

    }
}
