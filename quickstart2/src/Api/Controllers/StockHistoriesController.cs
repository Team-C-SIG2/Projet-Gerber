using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api.Models;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockHistoriesController : ControllerBase
    {
        private readonly ESBookshopContext _context;

        public StockHistoriesController(ESBookshopContext context)
        {
            _context = context;
        }

        // GET: api/StockHistories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StockHistory>>> GetStockHistories()
        {
            return await _context.StockHistories.ToListAsync();
        }

        // GET: api/StockHistories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StockHistory>> GetStockHistory(int id)
        {
            var stockHistory = await _context.StockHistories.FindAsync(id);

            if (stockHistory == null)
            {
                return NotFound();
            }

            return stockHistory;
        }

        // PUT: api/StockHistories/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStockHistory(int id, StockHistory stockHistory)
        {
            if (id != stockHistory.Id)
            {
                return BadRequest();
            }

            _context.Entry(stockHistory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StockHistoryExists(id))
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

        // POST: api/StockHistories
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<StockHistory>> PostStockHistory(StockHistory stockHistory)
        {
            _context.StockHistories.Add(stockHistory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStockHistory", new { id = stockHistory.Id }, stockHistory);
        }

        // DELETE: api/StockHistories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<StockHistory>> DeleteStockHistory(int id)
        {
            var stockHistory = await _context.StockHistories.FindAsync(id);
            if (stockHistory == null)
            {
                return NotFound();
            }

            _context.StockHistories.Remove(stockHistory);
            await _context.SaveChangesAsync();

            return stockHistory;
        }

        private bool StockHistoryExists(int id)
        {
            return _context.StockHistories.Any(e => e.Id == id);
        }
    }
}
