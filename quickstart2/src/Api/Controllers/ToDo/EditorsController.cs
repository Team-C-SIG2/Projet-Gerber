using Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EditorsController : ControllerBase
    {
        private readonly ESBookshopContext _context;

        public EditorsController(ESBookshopContext context)
        {
            _context = context;
        }

        // GET: api/Editors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Editor>>> GetEditors()
        {
            return await _context.Editors.ToListAsync();
        }

        // GET: api/Editors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Editor>> GetEditors(int id)
        {
            var editors = await _context.Editors.FindAsync(id);

            if (editors == null)
            {
                return NotFound();
            }

            return editors;
        }

        // PUT: api/Editors/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEditors(int id, Editor editors)
        {
            if (id != editors.Id)
            {
                return BadRequest();
            }

            _context.Entry(editors).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EditorsExists(id))
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

        // POST: api/Editors
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Editor>> PostEditors(Editor editors)
        {
            _context.Editors.Add(editors);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEditors", new { id = editors.Id }, editors);
        }

        // DELETE: api/Editors/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Editor>> DeleteEditors(int id)
        {
            var editors = await _context.Editors.FindAsync(id);
            if (editors == null)
            {
                return NotFound();
            }

            _context.Editors.Remove(editors);
            await _context.SaveChangesAsync();

            return editors;
        }

        private bool EditorsExists(int id)
        {
            return _context.Editors.Any(e => e.Id == id);
        }
    }
}
