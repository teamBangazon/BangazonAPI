using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BangazonAPI.Data;
using BangazonAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// * Class: Order Controller
// * Purpose: Provides methods to handle http requests involving instances of the Order class.
// * Author: Team One to What
// * Properties:
// *   Get(): Retrieves a list of all orders from DB
//     Get(int id): Retrieves a list of a single order specified by Id in the url or the request
//     Post: Creates a new instance of the order class and add’s it to the Db
//     CustomerExists: used by Post and Put methods to see if a specific instance of the order class exists already
//     Put: Modifies a single order instance specified by Id in the url request
// */

namespace BangazonAPI.Controllers
{
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        private BangazonAPIContext _context;

        public OrderController(BangazonAPIContext ctx)
        {
            _context = ctx;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            IQueryable<object> orders = from order in _context.Order select order;

            if (orders == null)
            {
                return NotFound();
            }
            return Ok(orders);
        }

        // GET api/values/5
        [HttpGet("{id}", Name = "GetOrder")]
        
        public IActionResult Get([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

        try
        {
            Order order = _context.Order.Single(m => m.OrderId == id);

            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }
        catch (System.InvalidOperationException ex)
        {
            return NotFound();
        }
    }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
        
        _context.Order.Add(order);

        try
        {
            _context.SaveChanges();
        }
        catch (DbUpdateException)
        {
            if (OrderExists(order.OrderId))
            {
                return new StatusCodeResult(StatusCodes.Status409Conflict);
            }
            else
            {
                throw;
            }
        }
        return CreatedAtRoute("GetOrder", new {id = order.OrderId}, order);
    }

    private bool OrderExists(int orderId)
    {
        return _context.Order.Count(e => e.OrderId == orderId) > 0;
    }

        // PUT api/values/5
        [HttpPut("{id}")]
        
        public IActionResult Put(int id, [FromBody] Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != order.OrderId)
            {
                return BadRequest();
            }
        
        _context.Entry(order).State = EntityState.Modified;

        try
        {
            _context.SaveChanges();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!OrderExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }
        return new StatusCodeResult(StatusCodes.Status204NoContent);
    }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Order order = _context.Order.Single(m => m.OrderId == id);
            if (order == null)
            {
                return NotFound();
            }
            _context.Order.Remove(order);
            _context.SaveChanges();

            return Ok(order);
        }
    }
}