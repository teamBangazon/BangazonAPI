using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BangazonAPI.Data;
using BangazonAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

/*  * CLASS: Department Controller
    * PURPOSE: Provides methods to handle http requests involving instances of the Department class.
    * AUTHOR: Team One to What
    * METHODS:
        Get(): Retrieves a list of all Department’s from DB
        Get(int id): Retrieves a single Department specified by Id in the url or the request
        Post(): Creates a new instance of the Department class and add’s it to the Db
        DepartmentExists: used by Post and Put methods to see if a specific instance of the Department class exists already
        Put(int id): Modifies a single Department instance specified by Id in the url request 
*/


namespace BangazonAPI.Controllers
{
    [Route("api/[controller]")]
    public class DepartmentController : Controller
    {
        private BangazonAPIContext _context;

        public DepartmentController(BangazonAPIContext ctx)
        {
            _context = ctx;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            IQueryable<object> departments = from department in _context.Department select department;

            if (departments == null)
            {
                return NotFound();
            }
            return Ok(departments);
        }

        // GET api/values/5
        [HttpGet("{id}", Name = "GetDepartment")]
        
        public IActionResult Get([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

        try
        {
            Department department = _context.Department.Single(m => m.DepartmentId == id);

            if (department == null)
            {
                return NotFound();
            }
            return Ok(department);
        }
        catch (System.InvalidOperationException ex)
        {
            return NotFound();
        }
    }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Department department)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
        
        _context.Department.Add(department);

        try
        {
            _context.SaveChanges();
        }
        catch (DbUpdateException)
        {
            if (DepartmentExists(department.DepartmentId))
            {
                return new StatusCodeResult(StatusCodes.Status409Conflict);
            }
            else
            {
                throw;
            }
        }
        return CreatedAtRoute("GetEmployee", new {id = department.DepartmentId}, department);
    }

    private bool DepartmentExists(int DepartmentId)
    {
        return _context.Department.Count(e => e.DepartmentId == DepartmentId) > 0;
    }

        // PUT api/values/5
        [HttpPut("{id}")]
        
        public IActionResult Put(int id, [FromBody] Department department)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != department.DepartmentId)
            {
                return BadRequest();
            }
        
        _context.Entry(department).State = EntityState.Modified;

        try
        {
            _context.SaveChanges();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!DepartmentExists(id))
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
