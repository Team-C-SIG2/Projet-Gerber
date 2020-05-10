using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AspNetUsersController : ControllerBase
    {
        private readonly ESBookshopContext _context;

        public AspNetUsersController(ESBookshopContext context)
        {
            _context = context;
        }

        //// GET: api/AspNetUsers
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<AspNetUser>>> GetAspNetUsers()
        //{
        //    return await _context.AspNetUsers.ToListAsync();
        //}

        //GET: api/AspNetUsers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserRoles>>> GetAspNetUsers()
        {
            var utilisateurs =
                (from i in _context.AspNetUsers
                 join f in _context.AspNetUserRoles on i.Id equals f.UserId
                 join n in _context.AspNetRoles on f.RoleId equals n.Id
                 where (i.Id == f.UserId) && (n.Id == f.RoleId) || (f.RoleId != n.Id)
                 select new UserRoles() { UserId = i.Id, Email = i.Email, Name = n.Name, RoleId = n.Id, Username = i.Username, PhoneNumber = i.PhoneNumber }
                 );

            if (utilisateurs == null)
            {
                return NotFound();
            }

            return await utilisateurs.ToListAsync();
        }

        // GET: api/AspNetUsers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserRoles>> GetAspNetUser(string id)
        {
            var utilisateur = (from i in _context.AspNetUsers
                               join f in _context.AspNetUserRoles on i.Id equals f.UserId
                               join n in _context.AspNetRoles on f.RoleId equals n.Id
                               where (i.Id == f.UserId)
                               select new UserRoles() { UserId = i.Id, Email = i.Email, Name = n.Name, RoleId = n.Id, Username = i.Username, PhoneNumber = i.PhoneNumber }
                 ).FirstOrDefault();

            if (utilisateur == null)
            {
                return NotFound();
            }

            return utilisateur;
        }

        // PUT: api/AspNetUsers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAspNetUser(string id, AspNetUser aspNetUser)
        {
            if (id != aspNetUser.Id)
            {
                return BadRequest();
            }

            _context.Entry(aspNetUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AspNetUserExists(id))
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

        // POST: api/AspNetUsers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<AspNetUser>> PostAspNetUser(AspNetUser aspNetUser)
        {
            _context.AspNetUsers.Add(aspNetUser);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AspNetUserExists(aspNetUser.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAspNetUser", new { id = aspNetUser.Id }, aspNetUser);
        }

        // DELETE: api/AspNetUsers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AspNetUser>> DeleteAspNetUser(string id)
        {
            var aspNetUser = await _context.AspNetUsers.FindAsync(id);
            if (aspNetUser == null)
            {
                return NotFound();
            }

            _context.AspNetUsers.Remove(aspNetUser);
            await _context.SaveChangesAsync();

            return aspNetUser;
        }

        private bool AspNetUserExists(string id)
        {
            return _context.AspNetUsers.Any(e => e.Id == id);
        }
    }
}
