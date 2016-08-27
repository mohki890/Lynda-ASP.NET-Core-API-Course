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
    public class OrderItemController : Controller
    {
        public OrderItemController(IOrderItemRepository orderItemItems)
        {
            OrderItemItems = orderItemItems;
        }

        public IOrderItemRepository OrderItemItems { get; set; }

        // GET: api/OrderItem
        [HttpGet]
        public IEnumerable<OrderItem> GetAll() => OrderItemItems.GetAll();

        [HttpGet("{id}", Name = "GetOrderItem")]
        public IActionResult GetById(int id)
        {
            var item = OrderItemItems.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] OrderItem item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            OrderItemItems.Add(item);
            return CreatedAtRoute("GetOrderItem", new { controller = "OrderItem", id = item.OrderItemId }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] OrderItem item)
        {
            if (item == null || item.OrderItemId != id)
            {
                return BadRequest();
            }

            var OrderItem = OrderItemItems.Find(id);
            if (OrderItem == null)
            {
                return NotFound();
            }

            OrderItemItems.Update(item);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            OrderItemItems.Remove(id);
        }
    }
}