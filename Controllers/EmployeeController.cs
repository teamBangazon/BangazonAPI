using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BangazonAPI.Data;
using BangazonAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

/*  * CLASS: Employee Controller
    * PURPOSE: Provides methods to handle http requests involving instances of the Employee class.
    * AUTHOR: Team One to What
    * METHODS:
        Get(): Retrieves a list of all Employee’s from DB
        Get(int id): Retrieves a single Employee specified by Id in the url or the request
        Post(): Creates a new instance of the Employee class and add’s it to the Db
        EmployeeExists: used by Post and Put methods to see if a specific instance of the Employee class exists already
        Put(int id): Modifies a single Employee instance specified by Id in the url request
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
