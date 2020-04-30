﻿

namespace Api.Controllers
{

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Data;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using AppDbContext.Models;
    using Microsoft.AspNetCore.Authorization;

    [Route("api/[controller]")]
    [ApiController]

    [Authorize]
    public class LineItemsController : ControllerBase
    {

        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Initialize the Database Context 
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////


        private readonly CoreDbContext _context;

        public LineItemsController(CoreDbContext context)
        {
            _context = context;
        }



        // __________________________________________________________________________
        // To get LineItems List of a ShoppingCart (Id) and send it to View (ViewBag)
        // __________________________________________________________________________


        /*
 
         // A JSON LineItem 

         {
            "id": 1,
            "quantity": 1,
            "unitPrice": 30.0000,
            "idShoppingcart": 2,
            "idShoppingcartNavigation": null,
            "idBook": 3,
            "idBookNavigation": null,
            "idOrder": 1,
            "appreciations": []
          }

        */


        [Route("Items/{id?}")]
        public async Task<ActionResult<IEnumerable<LineItem>>> GetCartItemByShoppingCartId(int? id)
        {
            var lines =
                (from i in _context.LineItems
                 where i.IdShoppingcart == id
                 select new LineItem()
                 {
                     Id = i.Id,
                     Quantity = i.Quantity,
                     UnitPrice = i.UnitPrice,
                     IdShoppingcart = i.IdShoppingcart,
                     IdBook = i.IdBook,
                     IdOrder = i.IdOrder,
                     IdBookNavigation = (from b in _context.Books where b.Id == i.IdBook select b).FirstOrDefault(),
                     IdShoppingcartNavigation = (from s in _context.ShoppingCarts where s.Id == i.IdShoppingcart select s).FirstOrDefault()
                 });

            if (lines == null)
            {
                return NotFound();
            }

            return await lines.ToListAsync();

        }



        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Return the list of all LineItems 
        // GET: api/LineItems
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LineItem>>> GetLineItems()
        {
            return await _context.LineItems.ToListAsync();
        }


        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Return a LineItem (id)
        // GET: api/LineItems/5
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        [HttpGet("{id}")]
        public async Task<ActionResult<LineItem>> GetLineItem(int id)
        {
            var lineItem = await _context.LineItems.FindAsync(id);

            if (lineItem == null)
            {
                return NotFound();
            }

            return lineItem;
        }



        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Update an existing LineItem 
        // PUT: api/LineItems/5
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////

        [HttpPut("{id}")]
        public async Task<IActionResult> PutLineItem(int id, LineItem lineItem)
        {
            if (id != lineItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(lineItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LineItemExists(id))
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
        // Delete a LineItem
        // DELETE: api/LineItems/5
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////

        [HttpDelete("{id}")]
        public async Task<ActionResult<LineItem>> DeleteLineItem(int id)
        {
            var lineItem = await _context.LineItems.FindAsync(id);
            if (lineItem == null)
            {
                return NotFound();
            }

            _context.LineItems.Remove(lineItem);
            await _context.SaveChangesAsync();

            return lineItem;
        }

        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Verify if a LineItem existe 
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////

        private bool LineItemExists(int id)
        {
            return _context.LineItems.Any(e => e.Id == id);
        }



        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // POST — create a new resource LineItem
        // POST: api/LineItems
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////

        [HttpPost]
        [Route("PostLineItem")]
        public async Task<ActionResult<LineItem>> PostLineItem(LineItem lineItem)
        {
            _context.LineItems.Add(lineItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLineItem", new { id = lineItem.Id }, lineItem);
        }




        // ______________________________________________________________
        // GET the Book of the LineItems 
        // GET: .../ api/LineItems/GetBook/S
        // ______________________________________________________________

        [HttpGet]
        [Route("GetBook")]
        public async Task<Book> GetBook(int id)
        {
            var book = (from b in _context.Books
                        where id == b.Id
                        select b).FirstOrDefault();

            return book;
        }








    }// End Class
}