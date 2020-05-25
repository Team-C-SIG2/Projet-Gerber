using Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AppreciationsController : ControllerBase
    {


        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Initialize the Database Context 
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        private readonly ESBookshopContext _context;


        public AppreciationsController(ESBookshopContext context)
        {
            _context = context;
        }


        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Return the list of all resources Appreciations
        // GET (HTTP VERB): api/Appreciations	
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Appreciation>>> GetAppreciations()
        {


            var items =
                (from i in _context.Appreciations
                 select new Appreciation()
                 {
                     Id = i.Id,
                     Evaluation = i.Evaluation,
                     IdLineItem = i.IdLineItem,

                     IdLineItemNavigation = (from a in _context.LineItems
                                             where a.Id == i.IdLineItem
                                             select a).FirstOrDefault(),

                     IdOrderNavigation = (from o in _context.Orders
                                          where o.Id == i.IdOrder
                                          select o).FirstOrDefault(),

                     IdOrder = i.IdOrder,
                     IdPayment = i.IdPayment,


                     IdPaymentNavigation = (from p in _context.Payments
                                            where p.Id == i.IdPayment
                                            select (new Payment()
                                            {
                                                Id = p.Id
                                            })
                                            ).FirstOrDefault()

                 });


            return await items.ToListAsync();

        }


        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Return an Appreciation (id)
        // GET: api/Appreciations/5
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////

        [HttpGet("{id}")]
        public async Task<ActionResult<Appreciation>> ReadRessource(int? id) // int ? - supprimé
        {
            if (id == null)
            {
                return NotFound();
            }

            var appreciation = await _context.Appreciations
                .Include(a => a.IdLineItemNavigation)
                .Include(a => a.IdOrderNavigation)
                .Include(a => a.IdPaymentNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appreciation == null)
            {
                return NotFound();
            }

            return appreciation;
        }


        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Update an existing Appreciation 
        // PUT: api/Categories/5
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppreciations(int id, Appreciation appreciation)
        {
            if (id != appreciation.Id)
            {
                return BadRequest();
            }

            _context.Entry(appreciation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppreciationExists(id))
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
        // POST: Create a new Appreciation  
        // POST: api/Appreciations/Create	
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////		


        [HttpPost]
        public async Task<ActionResult<Category>> PostAppreciations(Appreciation appreciation)
        {
            _context.Appreciations.Add(appreciation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAppreciations", new { id = appreciation.Id }, appreciation);
        }



        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Delete an Appreciation (id) 
        // DELETE: Appreciations/Delete/5		
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////		

        [HttpDelete("{id}")]
        public async Task<ActionResult<Appreciation>> DeleteAppreciations(int id)
        {
            var appreciation = await _context.Appreciations.FindAsync(id);
            if (appreciation == null)
            {
                return NotFound();
            }

            _context.Appreciations.Remove(appreciation);
            await _context.SaveChangesAsync();

            return appreciation;
        }


        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Verify if an Appreciation existe 
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////		

        private bool AppreciationExists(int id)
        {
            return _context.Appreciations.Any(e => e.Id == id);
        }



        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Send the List of LineItems, Orders and Payments for the Appreciations Views 
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////	

        [Route("GetLineItems")]

        public async Task<ActionResult<IEnumerable<LineItem>>> GetLineItems()
        {
            var linesItems = (from a in _context.LineItems select a).ToListAsync();
            return await linesItems;
        }




        [Route("GetOrders")]

        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            var orders = (from a in _context.Orders select a).ToListAsync();
            return await orders;
        }



        [Route("GetPayments")]
        public async Task<ActionResult<IEnumerable<Payment>>> GetPayments()
        {
            var payments = (from a in _context.Payments select a).ToListAsync();
            return await payments;
        }





    }// END CLASS
}
