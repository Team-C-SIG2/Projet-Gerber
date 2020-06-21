namespace Api.Controllers
{
    using Api.Models;
    using Api.ViewModel;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Threading.Tasks;
    using NLog;
    using System;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Data.SqlClient;

    [Route("api/[controller]")]
    [ApiController]

    [Authorize]
    public class LineItemsController : ControllerBase
    {
        // NLog 
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Initialize the Database Context 
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////

        private readonly ESBookshopContext _context;

        public LineItemsController(ESBookshopContext context)
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
            // NLog 
            string message = $"(API Server) - Try to GET LineItems List of ShoppingCart " + id + " (Id) - Controller: LineItemsController; " +
                $"Actionname: GetCartItemByShoppingCartId(); HTTP method : HttpGet; Route : Items/id? ; Time: " + DateTime.Now + "\n";
            _logger.Info(message);

            IQueryable<LineItem> lines = null;
            try
            {
                lines =
                   (from i in _context.LineItems
                    where i.IdShoppingcart == id
                    select new LineItem()
                    {
                        Id = i.Id,
                        Quantity = i.Quantity,
                        UnitPrice = i.UnitPrice,
                        IdShoppingcart = i.IdShoppingcart,
                        IdWishlist = i.IdWishlist,
                        IdBook = i.IdBook,
                        IdOrder = i.IdOrder,
                        IdBookNavigation = (from b in _context.Books where b.Id == i.IdBook select b).FirstOrDefault(),
                        IdShoppingcartNavigation = (from s in _context.ShoppingCarts where s.Id == i.IdShoppingcart select s).FirstOrDefault(),
                        IdWishlistNavigation = (from w in _context.Wishlists where w.Id == i.IdWishlist select w).FirstOrDefault()
                    });
            }
            catch (Exception ex)
            {
                // NLog Framework Call 

                // LOG INFO 
                _logger.Info("INFORMATION DETAILS, Exception occured during operation : " + message);
                _logger.Info("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG WARN
                _logger.Warn("WARNING DETAILS, Exception occured during operation : " + message);
                _logger.Warn("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG ERROR
                _logger.Error("ERROR DETAILS, Exception occured during operation : " + message);
                _logger.Error("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG TRACE 
                _logger.Trace("WARNING DETAILS, Exception occured during operation : " + message);
                _logger.Trace("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG FATAL
                _logger.Fatal("FATAL DETAILS, Exception occured during operation : " + message);
                _logger.Fatal("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG DEGUG 
                _logger.Debug("DEGUG DETAILS, Exception occured during operation : " + message);
                _logger.Debug("EXCEPTION DETAILS: " + ex.Message + "\n");

                if (lines != null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                }
                else
                {
                    return NotFound();
                }
            }

            return await lines.ToListAsync();
        }

        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Return the Wishlist
        // GET: api/Wishlist/S
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        [Route("Wishlist/{id?}")]
        public async Task<ActionResult<IEnumerable<LineItem>>> GetUserWishList(int? id)
        {
            // NLog 
            string message = $"(API Server) - Try to GET User Wishlist " + id + " (Id) - Controller: LineItemsController; " +
                $"Actionname: GetUserWishList(); HTTP method : HttpGet; Route : Wishlist/id? ; Time: " + DateTime.Now + "\n";
            _logger.Info(message);

            IQueryable<LineItem> lines = null;
            try
            {
                lines =
                    (from i in _context.LineItems
                     where i.IdWishlist == id
                     select new LineItem()
                     {
                         Id = i.Id,
                         Quantity = i.Quantity,
                         UnitPrice = i.UnitPrice,
                         IdShoppingcart = i.IdShoppingcart,
                         IdWishlist = i.IdWishlist,
                         IdBook = i.IdBook,
                         IdOrder = i.IdOrder,
                         IdBookNavigation = (from b in _context.Books where b.Id == i.IdBook select b).FirstOrDefault(),
                         IdShoppingcartNavigation = (from s in _context.ShoppingCarts where s.Id == i.IdShoppingcart select s).FirstOrDefault(),
                         IdWishlistNavigation = (from w in _context.Wishlists where w.Id == i.IdWishlist select w).FirstOrDefault()
                     });
            }
            catch (Exception ex)
            {
                // NLog Framework Call 

                // LOG INFO 
                _logger.Info("INFORMATION DETAILS, Exception occured during operation : " + message);
                _logger.Info("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG WARN
                _logger.Warn("WARNING DETAILS, Exception occured during operation : " + message);
                _logger.Warn("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG ERROR
                _logger.Error("ERROR DETAILS, Exception occured during operation : " + message);
                _logger.Error("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG TRACE 
                _logger.Trace("WARNING DETAILS, Exception occured during operation : " + message);
                _logger.Trace("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG FATAL
                _logger.Fatal("FATAL DETAILS, Exception occured during operation : " + message);
                _logger.Fatal("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG DEGUG 
                _logger.Debug("DEGUG DETAILS, Exception occured during operation : " + message);
                _logger.Debug("EXCEPTION DETAILS: " + ex.Message + "\n");

                if (lines != null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                }
                else
                {
                    return NotFound();
                }
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
            // NLog 
            string message = $"(API Server) - Try to GET ALL LineItems - Controller name: LineItemsController; " +
                $"Actionname: GetLineItems(); HTTP method : HttpGet; Time: " + DateTime.Now + "\n";
            _logger.Info(message);

            IQueryable<LineItem> lines = null;
            try
            {
                lines = _context.LineItems;
            }
            catch (Exception ex)
            {
                // NLog Framework Call 

                // LOG INFO 
                _logger.Info("INFORMATION DETAILS, Exception occured during operation : " + message);
                _logger.Info("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG WARN
                _logger.Warn("WARNING DETAILS, Exception occured during operation : " + message);
                _logger.Warn("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG ERROR
                _logger.Error("ERROR DETAILS, Exception occured during operation : " + message);
                _logger.Error("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG TRACE 
                _logger.Trace("WARNING DETAILS, Exception occured during operation : " + message);
                _logger.Trace("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG FATAL
                _logger.Fatal("FATAL DETAILS, Exception occured during operation : " + message);
                _logger.Fatal("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG DEGUG 
                _logger.Debug("DEGUG DETAILS, Exception occured during operation : " + message);
                _logger.Debug("EXCEPTION DETAILS: " + ex.Message + "\n");

                if (lines != null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                }
                else
                {
                    return NotFound();
                }
            }

            return await lines.ToListAsync();
        }


        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Return a LineItem (id)
        // GET: api/LineItems/5
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        [Route("LineItem/{id}")]
        public async Task<ActionResult<LineItem>> GetLineItem(int id)
        {
            // NLog 
            string message = $"(API Server) -Try to GET LineItem " + id + "(Id) - Controller name: LineItemsController; " +
                "Actionname: GetLineItem(...); HTTP method : HttpGet; Time: " + DateTime.Now + "\n";
            _logger.Info(message);

            LineItem lineItem = new LineItem();
            try
            {
                lineItem = await _context.LineItems.Include(book => book.IdBookNavigation).Where(book => book.Id == id).SingleOrDefaultAsync();
            }
            catch (Exception ex)
            {
                // NLog Framework Call 

                // LOG INFO 
                _logger.Info("INFORMATION DETAILS, Exception occured during operation : " + message);
                _logger.Info("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG WARN
                _logger.Warn("WARNING DETAILS, Exception occured during operation : " + message);
                _logger.Warn("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG ERROR
                _logger.Error("ERROR DETAILS, Exception occured during operation : " + message);
                _logger.Error("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG TRACE 
                _logger.Trace("WARNING DETAILS, Exception occured during operation : " + message);
                _logger.Trace("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG FATAL
                _logger.Fatal("FATAL DETAILS, Exception occured during operation : " + message);
                _logger.Fatal("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG DEGUG 
                _logger.Debug("DEGUG DETAILS, Exception occured during operation : " + message);
                _logger.Debug("EXCEPTION DETAILS: " + ex.Message + "\n");

                if (lineItem != null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                }
                else
                {
                    return NotFound();
                }
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
            // NLog 
            string message = $"(API Server) -Try to PUT (update) LineItem " + id + "(Id) - Controller : LineItemsController; " +
                "Actionname: PutLineItem(...); HTTP method : HttpPut; Time: " + DateTime.Now + "\n";
            _logger.Info(message);

            try
            {
                _context.Entry(lineItem).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                // NLog Framework Call 

                // LOG INFO 
                _logger.Info("INFORMATION DETAILS, Exception occured during operation : " + message);
                _logger.Info("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG WARN
                _logger.Warn("WARNING DETAILS, Exception occured during operation : " + message);
                _logger.Warn("EXCEPTION DETAILS: " + ex.Message + "\n");


                // LOG ERROR
                _logger.Error("ERROR DETAILS, Exception occured during operation : " + message);
                _logger.Error("EXCEPTION DETAILS: " + ex.Message + "\n");


                // LOG TRACE 
                _logger.Trace("WARNING DETAILS, Exception occured during operation : " + message);
                _logger.Trace("EXCEPTION DETAILS: " + ex.Message + "\n");


                // LOG FATAL
                _logger.Fatal("FATAL DETAILS, Exception occured during operation : " + message);
                _logger.Fatal("EXCEPTION DETAILS: " + ex.Message + "\n");


                // LOG DEGUG 
                _logger.Debug("DEGUG DETAILS, Exception occured during operation : " + message);
                _logger.Debug("EXCEPTION DETAILS: " + ex.Message + "\n");

                if (id != lineItem.Id)
                {
                    return BadRequest();
                }
                else if (!LineItemExists(id))
                {
                    return NotFound();
                }

                return NotFound();
            }

            return NoContent();
        }



        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // DELETE: api/LineItems/5
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////

        [HttpDelete("{id}")]
        public async Task<ActionResult<LineItem>> DeleteLineItem(int id)
        {
            // NLog 
            string message = $"(API Server) -Try to DELETE lineItem " + id + "(Id) - Controller : LineItemsController; " +
                "Actionname: DeleteLineItem(id); HTTP method : HttpDelete; Time: " + DateTime.Now + "\n";
            _logger.Info(message);

            LineItem lineItem = null;
            try
            {
                // Find lineItem 
                lineItem = await _context.LineItems.FindAsync(id);

                // Remove lineItem 
                _context.LineItems.Remove(lineItem);
                await _context.SaveChangesAsync();

                // GET UPDATED DB VALUES 
                _context.Entry(lineItem).GetDatabaseValues();

            }
            catch (Exception ex)
            {
                var sqlException = ex.GetBaseException() as SqlException;

                // NLog Framework Call 

                // LOG INFO 
                _logger.Info("INFORMATION DETAILS, Exception occured during operation : " + message);
                _logger.Info("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG WARN
                _logger.Warn("WARNING DETAILS, Exception occured during operation : " + message);
                _logger.Warn("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG ERROR
                _logger.Error("ERROR DETAILS, Exception occured during operation : " + message);
                _logger.Error("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG TRACE 
                _logger.Trace("WARNING DETAILS, Exception occured during operation : " + message);
                _logger.Trace("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG FATAL
                _logger.Fatal("FATAL DETAILS, Exception occured during operation : " + message);
                _logger.Fatal("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG DEGUG 
                _logger.Debug("DEGUG DETAILS, Exception occured during operation : " + message);
                _logger.Debug("EXCEPTION DETAILS: " + ex.Message + "\n");

                if (lineItem == null)
                {
                    return NotFound();
                }
                else if (sqlException != null)
                {
                    var number = sqlException.Number;
                    if (number == 547)
                    {
                        return ValidationProblem(sqlException.Message);
                    }
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                }
            }

            return lineItem;
        }

        // _____________________________________________
        // DELETE: api/LineItems/DeleteItems/5
        // _____________________________________________
        [HttpGet]
        [Route("DeleteItems/{id}")]
        public async Task<ActionResult<List<LineItem>>> DeleteLineItems(int id)
        {
            // NLog 
            string message = $"(API Server) -Try to DELETE lineItems of ShoppingCart " + id + "(Id) - Controller : LineItemsController; " +
                "Actionname: DeleteLineItem(id); HTTP method : HttpDelete; Route : DeleteItems/{id} ; Time: " + DateTime.Now + "\n";
            _logger.Info(message);

            List<LineItem> listLineItems = null;
            try
            {
                // Find lineItem List of ShoppingCart (Param id) 
                listLineItems = await _context.LineItems.Where(l => l.IdShoppingcart == id).ToListAsync();

                // Remove lineItem List
                foreach (LineItem lineItem in listLineItems)
                {
                    _context.LineItems.Remove(lineItem);
                }

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                var sqlException = ex.GetBaseException() as SqlException;

                // NLog Framework Call 

                // LOG INFO 
                _logger.Info("INFORMATION DETAILS, Exception occured during operation : " + message);
                _logger.Info("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG WARN
                _logger.Warn("WARNING DETAILS, Exception occured during operation : " + message);
                _logger.Warn("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG ERROR
                _logger.Error("ERROR DETAILS, Exception occured during operation : " + message);
                _logger.Error("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG TRACE 
                _logger.Trace("WARNING DETAILS, Exception occured during operation : " + message);
                _logger.Trace("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG FATAL
                _logger.Fatal("FATAL DETAILS, Exception occured during operation : " + message);
                _logger.Fatal("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG DEGUG 
                _logger.Debug("DEGUG DETAILS, Exception occured during operation : " + message);
                _logger.Debug("EXCEPTION DETAILS: " + ex.Message + "\n");

                if (listLineItems == null)
                {
                    return NotFound();
                }
                else if (sqlException != null)
                {
                    var number = sqlException.Number;
                    if (number == 547)
                    {
                        return ValidationProblem(sqlException.Message);
                    }
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                }
            }

            return listLineItems;
        }

        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Verify if a LineItem existe 
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        private bool LineItemExists(int id)
        {
            // NLog 
            string message = $"(API Server) - Verify if the LineItem " + id + "(Id) EXISTS - Controller : LineItemsController; " +
                "Actionname: LineItemExists(id); Return: bool; Time: " + DateTime.Now + "\n";
            _logger.Info(message);

            bool exist = false;

            try
            {
                exist = _context.LineItems.Any(e => e.Id == id);
            }
            catch (Exception ex)
            {
                // NLog Framework Call 

                // LOG INFO 
                _logger.Info("INFORMATION DETAILS, Exception occured during operation : " + message);
                _logger.Info("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG WARN
                _logger.Warn("WARNING DETAILS, Exception occured during operation : " + message);
                _logger.Warn("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG ERROR
                _logger.Error("ERROR DETAILS, Exception occured during operation : " + message);
                _logger.Error("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG TRACE 
                _logger.Trace("WARNING DETAILS, Exception occured during operation : " + message);
                _logger.Trace("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG FATAL
                _logger.Fatal("FATAL DETAILS, Exception occured during operation : " + message);
                _logger.Fatal("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG DEGUG 
                _logger.Debug("DEGUG DETAILS, Exception occured during operation : " + message);
                _logger.Debug("EXCEPTION DETAILS: " + ex.Message + "\n");

                return exist = false;
            }

            return exist;
        }

        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // POST — create a new resource LineItem
        // POST: api/LineItems
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        [HttpPost]
        [Route("PostLineItem")]
        public async Task<ActionResult<LineItem>> PostLineItem(LineItem lineItem)
        {
            // NLog 
            string message = $"(API Server) -Try to POST Categorie " + lineItem.Id + " (Id) - Controller : LineItemsController; " +
                "Actionname: PostLineItem(...); HTTP method : HttpPost; Time: " + DateTime.Now + "\n";
            _logger.Info(message);

            try
            {
                _context.LineItems.Add(lineItem);
                await _context.SaveChangesAsync();

                _context.Entry(lineItem).GetDatabaseValues();

                return CreatedAtAction("GetLineItem", new { id = lineItem.Id }, lineItem);
            }
            catch (Exception ex)
            {
                // NLog Framework Call 

                // LOG INFO 
                _logger.Info("INFORMATION DETAILS, Exception occured during operation : " + message);
                _logger.Info("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG WARN
                _logger.Warn("WARNING DETAILS, Exception occured during operation : " + message);
                _logger.Warn("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG ERROR
                _logger.Error("ERROR DETAILS, Exception occured during operation : " + message);
                _logger.Error("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG TRACE 
                _logger.Trace("WARNING DETAILS, Exception occured during operation : " + message);
                _logger.Trace("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG FATAL
                _logger.Fatal("FATAL DETAILS, Exception occured during operation : " + message);
                _logger.Fatal("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG DEGUG 
                _logger.Debug("DEGUG DETAILS, Exception occured during operation : " + message);
                _logger.Debug("EXCEPTION DETAILS: " + ex.Message + "\n");

                if (LineItemExists(lineItem.Id))
                {
                    return Conflict();
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                }
            }
        }

        // ______________________________________________________________ 
        // GET: .../ api/LineItems/GetBook/S
        // ______________________________________________________________
        [HttpGet]
        [Route("GetBook")]
        public async Task<Book> GetBook(int id)
        {
            // NLog 
            string message = $"(API Server) -Try to GET Book " + id + "(Id) - Controller name: LineItemsController; " +
                "Actionname: GetBook(id); HTTP method : HttpGet; Time: " + DateTime.Now + "\n";
            _logger.Info(message);

            Book book = new Book();
            try
            {
                book = (from b in _context.Books
                        where id == b.Id
                        select b).FirstOrDefault();
            }
            catch (Exception ex)
            {
                // NLog Framework Call 

                // LOG INFO 
                _logger.Info("INFORMATION DETAILS, Exception occured during operation : " + message);
                _logger.Info("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG WARN
                _logger.Warn("WARNING DETAILS, Exception occured during operation : " + message);
                _logger.Warn("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG ERROR
                _logger.Error("ERROR DETAILS, Exception occured during operation : " + message);
                _logger.Error("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG TRACE 
                _logger.Trace("WARNING DETAILS, Exception occured during operation : " + message);
                _logger.Trace("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG FATAL
                _logger.Fatal("FATAL DETAILS, Exception occured during operation : " + message);
                _logger.Fatal("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG DEGUG 
                _logger.Debug("DEGUG DETAILS, Exception occured during operation : " + message);
                _logger.Debug("EXCEPTION DETAILS: " + ex.Message + "\n");

            }

            return book;
        }

        // ______________________________________________________________
        // GET StockControl 
        // ______________________________________________________________
        [HttpGet]
        [Route("StockControl")]
        public async Task<List<LineItemStock>> GetStockControl(int id)
        {
            // NLog 
            string message = $"(API Server) - Try to GET Stock Control - Controller name: LineItemsController; " +
                $"Actionname: GetStockControl(); HTTP method : HttpGet; Route : /StockControl; Time: " + DateTime.Now + "\n";
            _logger.Info(message);

            List<LineItem> lineItems = null;
            List<LineItemStock> stockCtrlList = new List<LineItemStock>();
            Book book = new Book();
            try
            {
                lineItems = (from i in _context.LineItems
                             where i.IdShoppingcart == id
                             select i).ToList();


                foreach (var item in lineItems)
                {
                    book = (from i in _context.Books
                            where i.Id == item.IdBook
                            select i).FirstOrDefault();
                    stockCtrlList.Add(new LineItemStock { IdLineItem = item.Id, stockOk = item.Quantity <= book.Stock });
                }
            }
            catch (Exception ex)
            {
                // NLog Framework Call 

                // LOG INFO 
                _logger.Info("INFORMATION DETAILS, Exception occured during operation : " + message);
                _logger.Info("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG WARN
                _logger.Warn("WARNING DETAILS, Exception occured during operation : " + message);
                _logger.Warn("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG ERROR
                _logger.Error("ERROR DETAILS, Exception occured during operation : " + message);
                _logger.Error("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG TRACE 
                _logger.Trace("WARNING DETAILS, Exception occured during operation : " + message);
                _logger.Trace("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG FATAL
                _logger.Fatal("FATAL DETAILS, Exception occured during operation : " + message);
                _logger.Fatal("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG DEGUG 
                _logger.Debug("DEGUG DETAILS, Exception occured during operation : " + message);
                _logger.Debug("EXCEPTION DETAILS: " + ex.Message + "\n");

                if (lineItems == null || stockCtrlList == null || book == null)
                {
                    return null;
                }

            }

            return stockCtrlList;
        }

    }// End Class
}
