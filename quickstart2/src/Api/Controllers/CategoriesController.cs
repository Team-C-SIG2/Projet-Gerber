

namespace Api.Controllers
{
    using Api.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;



    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoriesController : ControllerBase
    {
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Initialize the Database Context 
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////

        private readonly ESBookshopContext _context;

        public CategoriesController(ESBookshopContext context)
        {
            _context = context;
        }


        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Return the list of all categories 
        // GET: api/Categories
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            return await _context.Categories.ToListAsync();
        }


        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Return an Categorie (id)
        // GET: api/Categories/5
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////

        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategories(int? id)
        {
            var categories = await _context.Categories.FindAsync(id);

            if (categories == null)
            {
                return NotFound();
            }

            return categories;
        }



        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Update an existing categorie 
        // PUT: api/Categories/5
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategories(int id, Category categories)
        {
            if (id != categories.Id)
            {
                return BadRequest();
            }

            _context.Entry(categories).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoriesExists(id))
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



        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // POST — create a new resource categorie
        // POST: api/Categories
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////

        [HttpPost]
        public async Task<ActionResult<Category>> PostCategories(Category categorie)
        {
            _context.Categories.Add(categorie);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategories", new { id = categorie.Id }, categorie);
        }


        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Delete a Categorie
        // DELETE: api/Categories/5
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////

        [HttpDelete("{id}")]
        public async Task<ActionResult<Category>> DeleteCategorie(int id)
        {
            var categorie = await _context.Categories.FindAsync(id);
            if (categorie == null)
            {
                return NotFound();
            }
            _context.Categories.Remove(categorie);
            await _context.SaveChangesAsync();

            return categorie;
        }


        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Verify if a categorie existe 
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////

        private bool CategoriesExists(int id)
        {
            return _context.Categories.Any(e => e.Id == id);
        }



    }// End Class
}
