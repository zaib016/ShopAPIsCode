using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopAPIsCode.Data;
using ShopAPIsCode.Models;
using ShopAPIsCode.Models.Entities;

namespace ShopAPIsCode.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private ApplicationDbContext dbContext;

        public CustomerController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult GetAllCustomer()
        {
            return Ok(dbContext.Customers.ToList());
        }
        [HttpPost]
        public IActionResult AddCustomer(CustomerDto customerDto)
        {
            var customer = new Customer()
            {
                FirstName = customerDto.FirstName,
                LastName = customerDto.LastName,
                Email = customerDto.Email,
                Phone = customerDto.Phone,
                City = customerDto.City,
                Country = customerDto.Country,
                ZipCode = customerDto.ZipCode,
            };
            dbContext.Customers.Add(customer);
            dbContext.SaveChanges();

            return Ok(customer);
        }
        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetCustomerById(int id)
        {
            var customer = dbContext.Customers.Find(id);
            if(customer is null)
            {
                return NotFound();
            }
            return Ok(customer);
        }
        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdateCustomerData(int id, CustomerDto customerDto)
        {
            var customer = dbContext.Customers.Find(id);
            if (customer is null)
            {
                return NotFound();
            }
            customer.FirstName = customerDto.FirstName;
            customer.LastName = customerDto.LastName;
            customer.Email = customerDto.Email;
            customer.Phone = customerDto.Phone;
            customer.City = customerDto.City;
            customer.Country = customerDto.Country;
            customer.ZipCode = customerDto.ZipCode;

            dbContext.SaveChanges();
            return Ok(customer);
        }
        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteCustomer(int id)
        {
            var customer = dbContext.Customers.Find(id);
            if(customer is null)
            {
                return NotFound();
            }
            dbContext.Customers.Remove(customer);
            dbContext.SaveChanges();
            return Ok(customer);
        }
    }
}
