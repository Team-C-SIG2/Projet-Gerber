using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AppDbContext.Models;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRolesController : ControllerBase
    {
        private readonly CoreDbContext _context;

        public UserRolesController(CoreDbContext context)
        {
            _context = context;
        }

        // GET: api/UserRoles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AspNetUserRole>>> GetAspNetUserRoles()
        {
            return await _context.AspNetUserRoles.ToListAsync();
        }

        // GET: api/UserRoles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AspNetUserRole>> GetAspNetUserRole(string id)
        {
            var aspNetUserRole = await _context.AspNetUserRoles.FindAsync(id);

            if (aspNetUserRole == null)
            {
                return NotFound();
            }

            return aspNetUserRole;
        }

        // PUT: api/UserRoles/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAspNetUserRole(string id, AspNetUserRole aspNetUserRole)
        {
            if (id != aspNetUserRole.RoleId)
            {
                return BadRequest();
            }

            _context.Entry(aspNetUserRole).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AspNetUserRoleExists(id))
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

        // POST: api/UserRoles
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<AspNetUserRole>> PostAspNetUserRole(AspNetUserRole aspNetUserRole)
        {
            _context.AspNetUserRoles.Add(aspNetUserRole);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AspNetUserRoleExists(aspNetUserRole.RoleId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAspNetUserRole", new { id = aspNetUserRole.RoleId }, aspNetUserRole);
        }

        // DELETE: api/UserRoles/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AspNetUserRole>> DeleteAspNetUserRole(string id)
        {
            var aspNetUserRole = await _context.AspNetUserRoles.FindAsync(id);
            if (aspNetUserRole == null)
            {
                return NotFound();
            }

            _context.AspNetUserRoles.Remove(aspNetUserRole);
            await _context.SaveChangesAsync();

            return aspNetUserRole;
        }

        private bool AspNetUserRoleExists(string id)
        {
            return _context.AspNetUserRoles.Any(e => e.RoleId == id);
        }
    }
}
