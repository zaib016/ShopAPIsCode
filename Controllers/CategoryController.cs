using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopAPIsCode.Data;
using ShopAPIsCode.Models;
using ShopAPIsCode.Models.Entities;

namespace ShopAPIsCode.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ApplicationDbContext dbContext;

        public CategoryController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult GetAllCategory()
        {
            return Ok(dbContext.Categories.ToList());
        }
        [HttpPost]
        public IActionResult AddCategory(CategoryDto categoryDto)
        {
            var categories = new Category()
            {
                CategoryName = categoryDto.CategoryName,
                Description = categoryDto.Description,
            };
            dbContext.Categories.Add(categories);
            dbContext.SaveChanges();

            return Ok(categories);
        }
        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetCategoriesById(int id)
        {
            var category = dbContext.Categories.Find(id);
            if(category is null)
            {
                return NotFound();
            }
            return Ok(category);
        }
        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdateCategory(int id , CategoryDto categoryDto)
        {
            var category = dbContext.Categories.Find(id);
            if (category is null)
            {
                return NotFound();
            }
            category.CategoryName = categoryDto.CategoryName;
            category.Description = categoryDto.Description;

            dbContext.SaveChanges();
            return Ok(category);
        }
        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteCategory(int id)
        {
            var category = dbContext.Categories.Find(id);
            if(category is null)
            {
                return NotFound();
            }
            dbContext.Categories.Remove(category);
            dbContext.SaveChanges();
            return Ok(category);
        }
    }
}
