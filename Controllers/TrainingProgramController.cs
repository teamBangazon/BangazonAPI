using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BangazonAPI.Data;
using BangazonAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

/*  * CLASS: TrainingProgram Controller
    * PURPOSE: Provides methods to handle http requests for the TrainingProgram class
    * AUTHOR: Team ONE TO WHAT
    * METHODS: 
        Get(): Retrieves list of all TrainingProgram from Db.
        Get(int id): Retrieves a single TrainingProgram from Db as specified by the id.
        Post: Creates new instance of TrainingProgram class and adds it to the Db.
        TrainingProgramExists: used by Put and Delete methods to see if a specific instance of the Training object exists already
        Put(int id): Edits a single TrainingProgram instance specified by the id in the url request.
        Delete(int id): Deletes TrainingProgram object specified by Id in url from DB  
*/

namespace BangazonAPI.Controllers
{
    [Route("api/[controller]")]
    public class TrainingProgramController : Controller
    {
        private BangazonAPIContext _context;

        public TrainingProgramController(BangazonAPIContext ctx)
        {
            _context = ctx;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            IQueryable<object> trainingprograms = from trainingprogram in _context.TrainingProgram select trainingprogram;

            if (trainingprograms == null)
            {
                return NotFound();
            }
            return Ok(trainingprograms);
        }

        // GET api/values/5
        [HttpGet("{id}", Name = "GetTrainingProgram")]
        
        public IActionResult Get([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

        try
        {
            TrainingProgram trainingprogram = _context.TrainingProgram.Single(m => m.TrainingProgramId == id);

            if (trainingprogram == null)
            {
                return NotFound();
            }
            return Ok(trainingprogram);
        }
        catch (System.InvalidOperationException ex)
        {
            return NotFound();
        }
    }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] TrainingProgram trainingprogram)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
        
        _context.TrainingProgram.Add(trainingprogram);

        try
        {
            _context.SaveChanges();
        }
        catch (DbUpdateException)
        {
            if (TrainingProgramExists(trainingprogram.TrainingProgramId))
            {
                return new StatusCodeResult(StatusCodes.Status409Conflict);
            }
            else
            {
                throw;
            }
        }
        return CreatedAtRoute("GetTrainingProgram", new {id = trainingprogram.TrainingProgramId}, trainingprogram);
    }

    private bool TrainingProgramExists(int trainingprogramId)
    {
        return _context.TrainingProgram.Count(e => e.TrainingProgramId == trainingprogramId) > 0;
    }

        // PUT api/values/5
        [HttpPut("{id}")]
        
        public IActionResult Put(int id, [FromBody] TrainingProgram trainingprogram)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != trainingprogram.TrainingProgramId)
            {
                return BadRequest();
            }
        
        _context.Entry(trainingprogram).State = EntityState.Modified;

        try
        {
            _context.SaveChanges();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TrainingProgramExists(id))
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
            TrainingProgram trainingprogram = _context.TrainingProgram.Single(m => m.TrainingProgramId == id);
            if (trainingprogram == null)
            {
                return NotFound();
            }
            if (trainingprogram.StartDate > DateTime.Now)
             {
                _context.TrainingProgram.Remove(trainingprogram);
                _context.SaveChanges();
             } 
             else
             {
                 Console.WriteLine("pick a date in the future.");
             }
             return Ok(trainingprogram);
        }
    }
}