using HPlusSportsAPI.Contracts;
using HPlusSportsAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace HPlusSportsAPI.Controllers
{
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        public OrderController(IOrderRepository orderItems)
        {
            OrderItems = orderItems;
        }

        public IOrderRepository OrderItems { get; set; }

        // GET: api/Order
        [HttpGet]
        public IEnumerable<Order> GetAll() => OrderItems.GetAll();

        [HttpGet("{id}", Name = "GetOrder")]
        public IActionResult GetById(int id)
        {
            var item = OrderItems.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Order item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            OrderItems.Add(item);
            return CreatedAtRoute("GetOrder", new { controller = "Order", id = item.OrderId }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Order item)
        {
            if (item == null || item.OrderId != id)
            {
                return BadRequest();
            }

            var Order = OrderItems.Find(id);
            if (Order == null)
            {
                return NotFound();
            }

            OrderItems.Update(item);
            return new NoContentResult();
        }

        [HttpPut]
        public IActionResult Update([FromBody] Order item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            var Order = OrderItems.Find(item.OrderId);
            if (Order == null)
            {
                return NotFound();
            }

            OrderItems.Update(item);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            OrderItems.Remove(id);
        }
    }
}