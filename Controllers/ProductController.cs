using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BangazonAPI.Data;
using BangazonAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// * Class: Product Controller
// * Purpose: Provides methods to handle http requests involving instances of the Product class.
// * Author: Team One to What
// * Properties:
// *   Get(): Retrieves a list of all Product’s from DB
//     Get(int ProductId): Retrieves a list of a single Product specified by Id in the url or the request
//     Post(): Creates a new instance of the Product class and add’s it to the Db
//     ProductExists: used by Put and Delete methods to see if a specific instance of the Product class exists already
//     Put(int ProductId): Modifies (edits) a single Product instance specified by Id in the url request
//     Delete(int ProductId): Deletes a single Product instance specified by the Id in the url request

namespace BangazonAPI.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private BangazonAPIContext _context;

        public ProductController(BangazonAPIContext ctx)
        {
            _context = ctx;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            IQueryable<object> products = from product in _context.Product select product;

            if (products == null)
            {
                return NotFound();
            }
            return Ok(products);
        }

        // GET api/values/5
        [HttpGet("{id}", Name = "GetProduct")]
        
        public IActionResult Get([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

        try
        {
            Product product = _context.Product.Single(m => m.ProductId == id);

            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
        catch (System.InvalidOperationException ex)
        {
            return NotFound();
        }
    }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
        
        _context.Product.Add(product);

        try
        {
            _context.SaveChanges();
        }
        catch (DbUpdateException)
        {
            if (ProductExists(product.ProductId))
            {
                return new StatusCodeResult(StatusCodes.Status409Conflict);
            }
            else
            {
                throw;
            }
        }
        return CreatedAtRoute("GetProduct", new {id = product.ProductId}, product);
    }

    private bool ProductExists(int ProductId)
    {
        return _context.Product.Count(e => e.ProductId == ProductId) > 0;
    }

        // PUT api/values/5
        [HttpPut("{id}")]
        
        public IActionResult Put(int id, [FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != product.ProductId)
            {
                return BadRequest();
            }
        
        _context.Entry(product).State = EntityState.Modified;

        try
        {
            _context.SaveChanges();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ProductExists(id))
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

        //DELETE api/values/5
       [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Product product = _context.Product.Single(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Product.Remove(product);
            _context.SaveChanges();

            return Ok(product);
        }
    }
}
