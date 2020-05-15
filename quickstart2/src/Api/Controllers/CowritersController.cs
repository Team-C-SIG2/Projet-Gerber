
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using LibraryDbContext.Models; 

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CowritersController : ControllerBase
    {
        private readonly CoreDbContext _context;

        public CowritersController(CoreDbContext context)
        {
            _context = context;
        }

        // GET: api/Cowriters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cowriter>>> GetCowriters()
        {
            return await _context.Cowriters.ToListAsync();
        }

        // GET: api/Cowriters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cowriter>> GetCowriters(int id)
        {
            var cowriters = await _context.Cowriters.FindAsync(id);

            if (cowriters == null)
            {
                return NotFound();
            }

            return cowriters;
        }

        // PUT: api/Cowriters/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCowriters(int id, Cowriter cowriters)
        {
            if (id != cowriters.IdAuthor)
            {
                return BadRequest();
            }

            _context.Entry(cowriters).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CowritersExists(id))
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

        // POST: api/Cowriters
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Cowriter>> PostCowriters(Cowriter cowriters)
        {
            _context.Cowriters.Add(cowriters);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CowritersExists(cowriters.IdAuthor))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCowriters", new { id = cowriters.IdAuthor }, cowriters);
        }

        // DELETE: api/Cowriters/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Cowriter>> DeleteCowriters(int id)
        {
            var cowriters = await _context.Cowriters.FindAsync(id);
            if (cowriters == null)
            {
                return NotFound();
            }

            _context.Cowriters.Remove(cowriters);
            await _context.SaveChangesAsync();

            return cowriters;
        }

        private bool CowritersExists(int id)
        {
            return _context.Cowriters.Any(e => e.IdAuthor == id);
        }
    }
}
