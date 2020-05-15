using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using LibraryDbContext.Models; 

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly CoreDbContext _context;

        public RolesController(CoreDbContext context)
        {
            _context = context;
        }

        // GET: api/Roles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AspNetRole>>> GetAspNetRoles()
        {
            return await _context.AspNetRoles.ToListAsync();
        }

        // GET: api/Roles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AspNetRole>> GetAspNetRole(string id)
        {
            var aspNetRole = await _context.AspNetRoles.FindAsync(id);

            if (aspNetRole == null)
            {
                return NotFound();
            }

            return aspNetRole;
        }

        // PUT: api/Roles/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAspNetRole(string id, AspNetRole aspNetRole)
        {
            if (id != aspNetRole.Id)
            {
                return BadRequest();
            }

            _context.Entry(aspNetRole).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AspNetRoleExists(id))
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

        // POST: api/Roles
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<AspNetRole>> PostAspNetRole(AspNetRole aspNetRole)
        {
            _context.AspNetRoles.Add(aspNetRole);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AspNetRoleExists(aspNetRole.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAspNetRole", new { id = aspNetRole.Id }, aspNetRole);
        }

        // DELETE: api/Roles/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AspNetRole>> DeleteAspNetRole(string id)
        {
            var aspNetRole = await _context.AspNetRoles.FindAsync(id);
            if (aspNetRole == null)
            {
                return NotFound();
            }

            _context.AspNetRoles.Remove(aspNetRole);
            await _context.SaveChangesAsync();

            return aspNetRole;
        }

        private bool AspNetRoleExists(string id)
        {
            return _context.AspNetRoles.Any(e => e.Id == id);
        }
    }
}
