using System.Linq;
using BangazonAPI.Data;
using BangazonAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BangazonAPI.Controllers
{
    [Route("api/[controller]")]
    public class ProductTypeController : Controller
    {
        private BangazonAPIContext _context;
        public ProductTypeController(BangazonAPIContext ctx)
        {
            _context = ctx;
        }

        //GET api/producttype
        [HttpGet]
        public IActionResult Get()
        {
            IQueryable<object> producttypes = from producttype in _context.ProductType select producttype;

            if (producttypes == null)
            {
                return NotFound();
            }
            return Ok(producttypes);
        }

        //GET api/producttype/1
        [HttpGet("{id}", Name = "GetProductType")]
        public IActionResult Get([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                ProductType producttype = _context.ProductType.Single(m => m.ProductTypeId == id);

                if (producttype == null)
                {
                    return NotFound();
                }
                return Ok(producttype);
            }
            catch (System.InvalidOperationException ex)
            {
                return NotFound();
            }
        }

        //POST api/producttype
        [HttpPost]
        public IActionResult Post([FromBody] ProductType producttype)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ProductType.Add(producttype);

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ProductTypeExists(producttype.ProductTypeId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }
            return CreatedAtRoute("GetProductType", new {id = producttype.ProductTypeId}, producttype);
        }

        private bool ProductTypeExists(int producttypeId)
        {
            return _context.ProductType.Count(e => e.ProductTypeId == producttypeId) >0;
        }

        //PUT api/producttype/1
        [HttpPut("{id}")]

        public IActionResult Put(int id, [FromBody] ProductType producttype)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != producttype.ProductTypeId)
            {
                return BadRequest();
            }

            _context.Entry(producttype).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductTypeExists(id))
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

        //DELET api/producttype/1
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ProductType producttype = _context.ProductType.Single(m => m.ProductTypeId == id);
            if (producttype == null)
            {
                return NotFound();
            }
            _context.ProductType.Remove(producttype);
            _context.SaveChanges();

            return Ok(producttype);
        }
    }
}