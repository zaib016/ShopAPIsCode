using Microsoft.AspNetCore.Mvc;
using ShopAPIsCode.Data;
using ShopAPIsCode.Models;
using ShopAPIsCode.Models.Entities;

namespace ShopAPIsCode.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private ApplicationDbContext dbContext;

        public ProductController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult GetAllProduct()
        {
            return Ok(dbContext.Products.ToList());
        }
        [HttpPost]
        public IActionResult AddProduct(ProductDto productDto)
        {
            var product = new Product()
            {
                ProductName = productDto.ProductName,
                CategoryId = productDto.CategoryId,
                Price = productDto.Price,
                Stock = productDto.Stock,
            };
            dbContext.Products.Add(product);
            dbContext.SaveChanges();

            return Ok(product);

        }
        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetProductById(int id)
        {
            var product = dbContext.Products.Find(id);
            if(product is null)
            {
                return NotFound();
            }
            return Ok(product);
        }
        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdateProduct(int id, ProductDto productDto)
        {
            var product = dbContext.Products.Find(id);
            if(product is null)
            {
                return NotFound();
            }
            product.ProductName = productDto.ProductName;
            product.CategoryId = productDto.CategoryId;
            product.Price = productDto.Price;
            product.Stock = productDto.Stock;

            dbContext.SaveChanges();
            return Ok(product);
        }
        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = dbContext.Products.Find(id);
            if(product is null)
            {
                return NotFound();
            }
            dbContext.Products.Remove(product);
            dbContext.SaveChanges();

            return Ok(product);
        }
    }
}
