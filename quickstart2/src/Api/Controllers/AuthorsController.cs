using Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly ESBookshopContext _context;

        public AuthorsController(ESBookshopContext context)
        {
            _context = context;
        }

        // GET: api/Authors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Author>>> GetAuthors()
        {
            return await _context.Authors.ToListAsync();
        }

        // GET: api/Authors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Author>> GetAuthors(int id)
        {
            var authors = await _context.Authors.FindAsync(id);

            if (authors == null)
            {
                return NotFound();
            }

            return authors;
        }

        // PUT: api/Authors/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuthors(int id, Author authors)
        {
            if (id != authors.Id)
            {
                return BadRequest();
            }

            _context.Entry(authors).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuthorsExists(id))
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

        // POST: api/Authors
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Author>> PostAuthors(Author authors)
        {
            _context.Authors.Add(authors);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAuthors", new { id = authors.Id }, authors);
        }

        // DELETE: api/Authors/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Author>> DeleteAuthors(int id)
        {
            var authors = await _context.Authors.FindAsync(id);
            if (authors == null)
            {
                return NotFound();
            }

            _context.Authors.Remove(authors);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                var sqlException = ex.GetBaseException() as SqlException;

                if (sqlException != null)
                {
                    var number = sqlException.Number;

                    if (number == 547)
                    {
                        return ValidationProblem(sqlException.Message);
                    }
                }
            }

            return authors;
        }

        private bool AuthorsExists(int id)
        {
            return _context.Authors.Any(e => e.Id == id);
        }
    }
}
