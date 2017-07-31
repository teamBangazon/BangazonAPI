using System.Linq;
using BangazonAPI.Data;
using BangazonAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

/*  * CLASS: PaymentType
    * PURPOSE: The PaymentType Class holds PaymentType information.
    * AUTHOR: One-to-What(Willie)
    * METHODS:
        Get(): Retrieves a list of all PaymentTypes from DB
        Get(int id): Retrieves a single PaymentType specified by Id in the url or the request
        Post(): Adds PaymentType object to DB
        PaymentTypeExists: used by Put and Delete methods to see if a specific instance of the PaymentType object exists already
        Put(int id): Edits PaymentType object in DB (must include id in object)
        Delete(int id): Deletes PaymentType object from DB  
*/

namespace BangazonAPI.Controllers
{
    [Route("api/[controller]")]
    public class PaymentTypeController : Controller
    {
        private BangazonAPIContext _context;
        public PaymentTypeController(BangazonAPIContext ctx)
        {
            _context = ctx;
        }

        //GET api/paymenttype
        [HttpGet]
        public IActionResult Get()
        {
            IQueryable<object> paymenttypes = from paymenttype in _context.PaymentType select paymenttype;

            if (paymenttypes == null)
            {
                return NotFound();
            }
            return Ok(paymenttypes);
        }

        //GET api/paymenttype/1
        [HttpGet("{id}", Name = "GetPaymentType")]
        public IActionResult Get([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                PaymentType paymenttype = _context.PaymentType.Single(m => m.PaymentTypeId == id);

                if (paymenttype == null)
                {
                    return NotFound();
                }
                return Ok(paymenttype);
            }
            catch (System.InvalidOperationException ex)
            {
                return NotFound();
            }
        }

        //POST api/paymenttype
        [HttpPost]
        public IActionResult Post([FromBody] PaymentType paymenttype)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.PaymentType.Add(paymenttype);

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (PaymentTypeExists(paymenttype.PaymentTypeId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }
            return CreatedAtRoute("GetPaymentType", new {id = paymenttype.PaymentTypeId}, paymenttype);
        }

        private bool PaymentTypeExists(int paymenttypeId)
        {
            return _context.PaymentType.Count(e => e.PaymentTypeId == paymenttypeId) >0;
        }

        //PUT api/paymenttype/1
        [HttpPut("{id}")]

        public IActionResult Put(int id, [FromBody] PaymentType paymenttype)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != paymenttype.PaymentTypeId)
            {
                return BadRequest();
            }

            _context.Entry(paymenttype).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentTypeExists(id))
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

        //DELET api/paymenttype/1
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            PaymentType paymenttype = _context.PaymentType.Single(m => m.PaymentTypeId == id);
            if (paymenttype == null)
            {
                return NotFound();
            }
            _context.PaymentType.Remove(paymenttype);
            _context.SaveChanges();

            return Ok(paymenttype);
        }
    }
}