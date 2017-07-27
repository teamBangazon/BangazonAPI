using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BangazonAPI.Data;
using BangazonAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

/**
 * Class: Customer Controller
 * Purpose: Provides methods to handle http requests involving instances of the customer class.
 * Author: Team One to What - Dylan Smith
 * Properties:
 *   Get(): Retrieves a list of all customer's from DB
     Get(int CustomerId): Retrieves a list of a single customer specified by Id in the url or the request
     Post(new Customer customer): Creates a new instance of the customer class and add's it to the Db
     CustomerExists(int CustomerId): used by Post and Put methods to see if a specific instance of the customer class exists already
     Put(int CustomerId): Modifies a single customer instance specified by Id in the url request
 */

namespace BangazonAPI.Controllers
{
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        private BangazonAPIContext _context;

        public CustomerController(BangazonAPIContext ctx)
        {
            _context = ctx;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            IQueryable<object> customers = from customer in _context.Customer select customer;

            if (customers == null)
            {
                return NotFound();
            }
            return Ok(customers);
        }

        // GET api/values/5
        [HttpGet("{id}", Name = "GetCustomer")]
        
        public IActionResult Get([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

        try
        {
            Customer customer = _context.Customer.Single(m => m.CustomerId == id);

            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }
        catch (System.InvalidOperationException ex)
        {
            return NotFound();
        }
    }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
        
        _context.Customer.Add(customer);

        try
        {
            _context.SaveChanges();
        }
        catch (DbUpdateException)
        {
            if (CustomerExists(customer.CustomerId))
            {
                return new StatusCodeResult(StatusCodes.Status409Conflict);
            }
            else
            {
                throw;
            }
        }
        return CreatedAtRoute("GetCustomer", new {id = customer.CustomerId}, customer);
    }

    private bool CustomerExists(int customerId)
    {
        return _context.Customer.Count(e => e.CustomerId == customerId) > 0;
    }

        // PUT api/values/5
        [HttpPut("{id}")]
        
        public IActionResult Put(int id, [FromBody] Customer cusotmer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cusotmer.CustomerId)
            {
                return BadRequest();
            }
        
        _context.Entry(cusotmer).State = EntityState.Modified;

        try
        {
            _context.SaveChanges();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CustomerExists(id))
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

    }
}