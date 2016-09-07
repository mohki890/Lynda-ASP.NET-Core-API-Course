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
    public class SalespersonController : Controller
    {
        public SalespersonController(ISalespersonRepository salespersonItems)
        {
            SalespersonItems = salespersonItems;
        }

        public ISalespersonRepository SalespersonItems { get; set; }

        // GET: api/Salesperson
        [HttpGet]
        public IEnumerable<Salesperson> GetAll() => SalespersonItems.GetAll();

        [HttpGet("{id}", Name = "GetSalesperson")]
        public IActionResult GetById(int id)
        {
            var item = SalespersonItems.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Salesperson item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            SalespersonItems.Add(item);
            return CreatedAtRoute("GetSalesperson", new { controller = "Salesperson", id = item.SalespersonId }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Salesperson item)
        {
            if (item == null || item.SalespersonId != id)
            {
                return BadRequest();
            }

            var Salesperson = SalespersonItems.Find(id);
            if (Salesperson == null)
            {
                return NotFound();
            }

            SalespersonItems.Update(item);
            return new NoContentResult();
        }

        [HttpPut]
        public IActionResult Update([FromBody] Salesperson item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            var Salesperson = SalespersonItems.Find(item.SalespersonId);
            if (Salesperson == null)
            {
                return NotFound();
            }

            SalespersonItems.Update(item);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            SalespersonItems.Remove(id);
        }
    }
}