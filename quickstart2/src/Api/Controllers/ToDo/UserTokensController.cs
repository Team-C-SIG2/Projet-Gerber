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
    public class UserTokensController : ControllerBase
    {
        private readonly CoreDbContext _context;

        public UserTokensController(CoreDbContext context)
        {
            _context = context;
        }

        // GET: api/UserTokens
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AspNetUserToken>>> GetAspNetUserTokens()
        {
            return await _context.AspNetUserTokens.ToListAsync();
        }

        // GET: api/UserTokens/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AspNetUserToken>> GetAspNetUserToken(string id)
        {
            var aspNetUserToken = await _context.AspNetUserTokens.FindAsync(id);

            if (aspNetUserToken == null)
            {
                return NotFound();
            }

            return aspNetUserToken;
        }

        // PUT: api/UserTokens/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAspNetUserToken(string id, AspNetUserToken aspNetUserToken)
        {
            if (id != aspNetUserToken.LoginProvider)
            {
                return BadRequest();
            }

            _context.Entry(aspNetUserToken).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AspNetUserTokenExists(id))
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

        // POST: api/UserTokens
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<AspNetUserToken>> PostAspNetUserToken(AspNetUserToken aspNetUserToken)
        {
            _context.AspNetUserTokens.Add(aspNetUserToken);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AspNetUserTokenExists(aspNetUserToken.LoginProvider))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAspNetUserToken", new { id = aspNetUserToken.LoginProvider }, aspNetUserToken);
        }

        // DELETE: api/UserTokens/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AspNetUserToken>> DeleteAspNetUserToken(string id)
        {
            var aspNetUserToken = await _context.AspNetUserTokens.FindAsync(id);
            if (aspNetUserToken == null)
            {
                return NotFound();
            }

            _context.AspNetUserTokens.Remove(aspNetUserToken);
            await _context.SaveChangesAsync();

            return aspNetUserToken;
        }

        private bool AspNetUserTokenExists(string id)
        {
            return _context.AspNetUserTokens.Any(e => e.LoginProvider == id);
        }
    }
}
