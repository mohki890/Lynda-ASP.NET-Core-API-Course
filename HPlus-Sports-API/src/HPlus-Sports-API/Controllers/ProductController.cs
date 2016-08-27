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
    public class ProductController : Controller
    {
        public ProductController(IProductRepository productItems)
        {
            ProductItems = productItems;
        }

        public IProductRepository ProductItems { get; set; }

        // GET: api/Product
        [HttpGet]
        public IEnumerable<Product> GetAll() => ProductItems.GetAll();

        [HttpGet("{id}", Name = "GetProduct")]
        public IActionResult GetById(string id)
        {
            var item = ProductItems.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Product item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            ProductItems.Add(item);
            return CreatedAtRoute("GetProduct", new { controller = "Product", id = item.ProductId }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] Product item)
        {
            if (item == null || item.ProductId != id)
            {
                return BadRequest();
            }

            var Product = ProductItems.Find(id);
            if (Product == null)
            {
                return NotFound();
            }

            ProductItems.Update(item);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            ProductItems.Remove(id);
        }
    }
}