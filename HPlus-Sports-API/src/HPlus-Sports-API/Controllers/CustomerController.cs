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

        // GET: api/Customer
        [HttpGet]
        [ResponseCache(Duration = 60)]
        public IEnumerable<Customer> GetAll() => CustomerItems.GetAll();

        [HttpGet("{id}", Name = "GetCustomer")]
        //[ResponseCache(Duration = 60, Location = ResponseCacheLocation.Client)]
        [ResponseCache(CacheProfileName = "PrivateCache")]
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

            var Customer = CustomerItems.Find(id);
            if (Customer == null)
            {
                return NotFound();
            }

            CustomerItems.Update(item);
            return new NoContentResult();
        }

        [HttpPut]
        public IActionResult Update([FromBody] Customer item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            var Customer = CustomerItems.Find(item.CustomerId);
            if (Customer == null)
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