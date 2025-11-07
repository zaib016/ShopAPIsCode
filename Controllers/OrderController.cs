using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopAPIsCode.Data;
using ShopAPIsCode.Models;
using ShopAPIsCode.Models.Entities;

namespace ShopAPIsCode.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private ApplicationDbContext dbContext;

        public OrderController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult GetOrder()
        {
            return Ok(dbContext.Orders.ToList());
        }
        [HttpPost]
        public IActionResult AddOrder(OrderDto orderDto)
        {
            var orders = new Order()
            {
                CustomerId = orderDto.CustomerId,
                ProductId = orderDto.ProductId,
                ProductName = orderDto.ProductName,
                Quantity = orderDto.Quantity,
                Price = orderDto.Price,
                TotalAmount = orderDto.TotalAmount,
                OrderDate = orderDto.OrderDate,
            };

            dbContext.Orders.Add(orders);
            dbContext.SaveChanges();

            return Ok(orders);
        }
        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetOrderById(int id)
        {
            var order = dbContext.Orders.Find(id);
            if(order is null)
            {
                return NotFound();
            }
            return Ok(order);
        }
        [HttpPut]
        [Route("{id:int}")]
        public IActionResult updateOrder(int id, OrderDto orderDto)
        {
            var order = dbContext.Orders.Find(id);
            if(order is null)
            {
                return NotFound();
            }
            order.CustomerId = orderDto.CustomerId;
            order.ProductId = orderDto.ProductId;
            order.ProductName = orderDto.ProductName;
            order.Quantity = orderDto.Quantity;
            order.Price = orderDto.Price;
            order.TotalAmount = orderDto.TotalAmount;
            order.OrderDate = orderDto.OrderDate;

            dbContext.SaveChanges();
            return Ok(order);
        }
        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteOrder(int id)
        {
            var order = dbContext.Orders.Find(id);
            if(order is null)
            {
                return NotFound();
            }
            dbContext.Orders.Remove(order);
            dbContext.SaveChanges();

            return Ok(order);
        }
    }
}
