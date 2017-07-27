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
 * Class: 
 * Purpose: The Order class is used to store all order information.
 * Author: Team Delta
 * Properties:
 *   OrderId: A unique idetification number for each order 
     UserId: The user who created/completed this order
     User: All of the user information that has created/completed this order
     PaymentTypeId: The specific payment that was used for this order. This also indicates whether this is a current order, or a completed order. If the PaymentTypeId is null, the payment is current, if it has a value then the order has been completed by the user. 
     PaymentType: The type of payment used to complete the order
     OrderProducts: A collection of OrderProducts to allow database traversing
 */


namespace BangazonAPI.Controllers
{
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        private BangazonAPIContext _context;

        public EmployeeController(BangazonAPIContext ctx)
        {
            _context = ctx;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            IQueryable<object> employees = from employee in _context.Employee select employee;

            if (employees == null)
            {
                return NotFound();
            }
            return Ok(employees);
        }

        // GET api/values/5
        [HttpGet("{id}", Name = "GetEmployee")]
        
        public IActionResult Get([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

        try
        {
            Employee employee = _context.Employee.Single(m => m.EmployeeId == id);

            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }
        catch (System.InvalidOperationException ex)
        {
            return NotFound();
        }
    }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
        
        _context.Employee.Add(employee);

        try
        {
            _context.SaveChanges();
        }
        catch (DbUpdateException)
        {
            if (EmployeeExists(employee.EmployeeId))
            {
                return new StatusCodeResult(StatusCodes.Status409Conflict);
            }
            else
            {
                throw;
            }
        }
        return CreatedAtRoute("GetEmployee", new {id = employee.EmployeeId}, employee);
    }

    private bool EmployeeExists(int employeeId)
    {
        return _context.Employee.Count(e => e.EmployeeId == employeeId) > 0;
    }

        // PUT api/values/5
        [HttpPut("{id}")]
        
        public IActionResult Put(int id, [FromBody] Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != employee.EmployeeId)
            {
                return BadRequest();
            }
        
        _context.Entry(employee).State = EntityState.Modified;

        try
        {
            _context.SaveChanges();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!EmployeeExists(id))
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
        // [HttpDelete("{id}")]
        // public void Delete(int id)
        // {
        // }
    }
}
