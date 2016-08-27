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
    public class CustomerController : Controller
    {
        public CustomerController(ICustomerRepository customerItems)
        {
            CustomerItems = customerItems;
        }

        public ICustomerRepository CustomerItems { get; set; }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Customer> GetAll() => CustomerItems.GetAll();

        [HttpGet("{id}", Name = "GetCustomer")]
        public IActionResult GetById(int id)
        {
            var item = CustomerItems.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Customer item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            CustomerItems.Add(item);
            return CreatedAtRoute("GetCustomer", new { controller = "Customer", id = item.CustomerId }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Customer item)
        {
            if (item == null || item.CustomerId != id)
            {
                return BadRequest();
            }

            var Artist = CustomerItems.Find(id);
            if (Artist == null)
            {
                return NotFound();
            }

            CustomerItems.Update(item);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            CustomerItems.Remove(id);
        }
    }
}