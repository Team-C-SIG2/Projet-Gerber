using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


using ESBAppCoreMVC.Data;
using ESBAppCoreMVC.Models;

namespace ESBAppCoreMVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CUSTOMERsController : ControllerBase
    {
        private readonly ESBookshop2 _context;

        public CUSTOMERsController(ESBookshop2 context)
        {
            _context = context;
        }

        // GET: api/CUSTOMERs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CUSTOMER>>> GetCUSTOMER()
        {
            return await _context.CUSTOMERS.ToListAsync();
        }

        // GET: api/CUSTOMERs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CUSTOMER>> GetCUSTOMER(int id)
        {
            var cUSTOMER = await _context.CUSTOMERS.FindAsync(id);

            if (cUSTOMER == null)
            {
                return NotFound();
            }

            return cUSTOMER;
        }

        // PUT: api/CUSTOMERs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCUSTOMER(int id, CUSTOMER cUSTOMER)
        {
            if (id != cUSTOMER.ID)
            {
                return BadRequest();
            }

            _context.Entry(cUSTOMER).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CUSTOMERExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/CUSTOMERs
        [HttpPost]
        public async Task<ActionResult<CUSTOMER>> PostCUSTOMER(CUSTOMER cUSTOMER)
        {
            _context.CUSTOMERS.Add(cUSTOMER);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCUSTOMER", new { id = cUSTOMER.ID }, cUSTOMER);
        }

        // DELETE: api/CUSTOMERs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CUSTOMER>> DeleteCUSTOMER(int id)
        {
            var cUSTOMER = await _context.CUSTOMERS.FindAsync(id);
            if (cUSTOMER == null)
            {
                return NotFound();
            }

            _context.CUSTOMERS.Remove(cUSTOMER);
            await _context.SaveChangesAsync();

            return cUSTOMER;
        }

        private bool CUSTOMERExists(int id)
        {
            return _context.CUSTOMERS.Any(e => e.ID == id);
        }
    }
}
