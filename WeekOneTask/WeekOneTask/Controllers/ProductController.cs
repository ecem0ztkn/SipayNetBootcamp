using Microsoft.AspNetCore.Mvc;
using WeekOneTask.Constants;
using WeekOneTask.Models;
using WeekOneTask.Results;

namespace WeekOneTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var product = Data.Products.FirstOrDefault(x => x.Id == id);
            if (product != null)
            {
                return Ok(new DataResult<Product>
                {
                    Data = product,
                    Message = Messages.SuccessFull
                });
            }

            return NotFound(new DataResult<Product>
            {
                Success = false,
                Message = $"{id}' numaralı id'ye sahip ürün bulunamamıştır"
            });
        }

        [HttpPost]
        public IActionResult Add([FromBody] AddProductModel entity)
        {
            if (ModelState.IsValid)
            {
                Data.Products.Add(new Product
                {
                    Name = entity.Name,
                    Price = entity.Price,
                    Quantity = entity.Quantity,
                    CreatedDate = DateTime.Now
                });
                return Ok(new DataResult<AddProductModel>
                {
                    Data = entity,
                    Message = "İlgili ürün başarıyla kaydedilmiştir."
                });
            }

            return BadRequest(new DataResult<AddProductModel>
            {
                Success = false,
                Message = "Kaydetme işlemi başarısızlıkla sonuçlanmıştır."
            });

        }

        [HttpGet]
        public IActionResult GetList()
        {
            return Ok(new DataResult<List<Product>>
            {
                Data = Data.Products,
                Message = "Ürün nesnesi başarıyla alınmıştır."
            });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = Data.Products.FirstOrDefault(x => x.Id == id);
            if (product != null)
            {
                Data.Products.Remove(product);
                return Ok(new DataResult<Product>
                {
                    Data = product,
                    Message = "Ürün nesnesi başarıyla silinmiştir."
                });
            }

            return NotFound(new DataResult<Product>
            {
                Success = false,
                Message = Messages.Get(id)
            });
        }

        [HttpPut]
        public IActionResult Update([FromBody] UpdateProductModel entity)
        {
            if (ModelState.IsValid)
            {
                var product = Data.Products.FirstOrDefault(x => x.Id == entity.Id);
                if (product != null)
                {
                    //List üzerinde çalıştığımızdan dolayı, ya önce silip, sonra ekleme yaparız. Ya da veriyi çekip; product.Name = entity.Name gibisinden değer ataması yaparız.
                    product.Name = entity.Name;
                    product.Price = entity.Price;
                    product.Quantity = entity.Quantity;
                    product.UpdatedDate = DateTime.Now;

                    return Ok(new DataResult<UpdateProductModel>
                    {
                        Data = entity,
                        Message = "İlgili ürün başarıyla güncellenmiştir."
                    });
                }
            }

            return BadRequest(new DataResult<UpdateProductModel>
            {
                Success = false,
                Message = "Güncelleme işlemi başarısızlıkla sonuçlanmıştır."
            });

        }

        [HttpGet("OrderByName")]
        public IActionResult OrderByName()
        {
            return Ok(new DataResult<List<Product>>
            {
                Data = Data.Products.OrderBy(x => x.Name).ToList(),
                Message = "Ürünler isme göre sıralanmıştır"
            });
        }
    }
}
