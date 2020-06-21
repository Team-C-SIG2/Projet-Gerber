

namespace Api.Controllers
{

using Api.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using NLog;
    using System;
    using Microsoft.AspNetCore.Http;

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AppreciationsController : ControllerBase
    {

        // NLog 
        private static Logger _logger = LogManager.GetCurrentClassLogger();


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
            // NLog 
            string message = $"(API Server) - Try to GET ALL Appreciations - Controller: AppreciationsController; " +
                $"Actionname: GetAppreciations(); HTTP method : HttpGet; Time: " + DateTime.Now + "\n";
            _logger.Info(message);


            IQueryable<Appreciation> items = null;
            try
            {
                items =
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

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

            return await items.ToListAsync();
        }


        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Return an Appreciation (id)
        // GET: api/Appreciations/5
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////

        [HttpGet("{id}")]
        public async Task<ActionResult<Appreciation>> ReadRessource(int? id) // int ? - supprimé
        {
            // NLog 
            string message = $"(API Server) -Try to GET Appreciation " + id + "(Id) - Controller name: AppreciationsController; " +
                "Actionname: ReadRessource(...); HTTP method : HttpGet; Time: " + DateTime.Now + "\n";
            _logger.Info(message);


            Appreciation appreciation = new Appreciation();
            try
            {
                appreciation = await _context.Appreciations
                    .Include(a => a.IdLineItemNavigation)
                    .Include(a => a.IdOrderNavigation)
                    .Include(a => a.IdPaymentNavigation)
                    .FirstOrDefaultAsync(m => m.Id == id);
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

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
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
            // NLog 
            string message = $"(API Server) -Try to PUT (update) Appreciation " + id + "(Id) - Controller : AppreciationsController; " +
                "Actionname: Put(...); HTTP method : HttpPut; Time: " + DateTime.Now + "\n";
            _logger.Info(message);

            try
            {
                _context.Entry(appreciation).State = EntityState.Modified;
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

                if (id != appreciation.Id)
                {
                    return BadRequest();
                }
                else
                {
                    return NotFound();
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
            // NLog 
            string message = $"Log Information(API Server) -Try to POST Appreciation " + appreciation.Id + "(Id) - Controller : AppreciationsController; " +
                "Actionname: Post(...); HTTP method : HttpPost; Time: " + DateTime.Now + "\n";
            _logger.Info(message);

            try
            {
                _context.Appreciations.Add(appreciation);
                await _context.SaveChangesAsync();

                _context.Entry(appreciation).GetDatabaseValues();
                return CreatedAtAction("GetAppreciations", new { id = appreciation.Id }, appreciation);
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

                if (AppreciationExists(appreciation.Id))
                {
                    return Conflict();
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                }
            }
        }


        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Delete an Appreciation (id) 
        // DELETE: Appreciations/Delete/5		
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////		

        [HttpDelete("{id}")]
        public async Task<ActionResult<Appreciation>> DeleteAppreciations(int id)
        {

            // NLog 
            string message = $"(API Server) -Try to DELETE an Appreciation " + id + "(Id) - Controller : AppreciationsController; " +
                "Actionname: DeleteAppreciations(...); HTTP method : HttpDelete; Time: " + DateTime.Now + "\n";
            _logger.Info(message);

            Appreciation appreciation = null;
            try
            {
                // Find Appreciation 
                appreciation = await _context.Appreciations.FindAsync(id);

                // Remove Appreciation 
                _context.Appreciations.Remove(appreciation);
                await _context.SaveChangesAsync();

                // GET UPDATED DB VALUES 
                _context.Entry(appreciation).GetDatabaseValues();

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


                if (appreciation == null)
                {
                    return NotFound();
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                }

            }

            return appreciation;
        }


        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Verify if an Appreciation existe 
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////		

        private bool AppreciationExists(int id)
        {
            // NLog 
            string message = $"(API Server) - Verify if  Appreciation " + id + "(Id) exists - Controller : AppreciationController; " +
                "Actionname: AppreciationExists(...); Return: bool; Time: " + DateTime.Now + "\n";
            _logger.Info(message);

            bool exist = false;

            try
            {
                exist = _context.Appreciations.Any(e => e.Id == id);
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
        // Send the List of LineItems, Orders and Payments for the Appreciations Views 
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////	

        [Route("GetLineItems")]

        public async Task<ActionResult<IEnumerable<LineItem>>> GetLineItems()
        {
            // NLog 
            string message = $"(API Server) - Try to GET ALL LineItems - Controller: AppreciationsController; " +
                $"Actionname: GetLineItems(); HTTP method : HttpGet; Time: " + DateTime.Now + "\n";
            _logger.Info(message);


            IQueryable<LineItem> linesItems = null;
            try
            {
                linesItems = (from a in _context.LineItems select a);
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

            return await linesItems.ToListAsync();
        }


        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // GET : GetOrders 
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////	
        [Route("GetOrders")]

        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {

            // NLog 
            string message = $"(API Server) - Try to GET ALL Orders - Controller: AppreciationsController; " +
                $"Actionname: GetOrders(); HTTP method : HttpGet; Time: " + DateTime.Now + "\n";
            _logger.Info(message);

            IQueryable<Order> orders = null;
            try
            {
                orders = (from a in _context.Orders select a);
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

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

            }

            return await orders.ToListAsync();
        }


        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // GET : GetPayments
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////	
        [Route("GetPayments")]
        public async Task<ActionResult<IEnumerable<Payment>>> GetPayments()
        {
            // NLog 
            string message = $"(API Server) - Try to GET ALL Payments - Controller: AppreciationsController; " +
                $"Actionname: GetPayments(); HTTP method : HttpGet; Time: " + DateTime.Now + "\n";
            _logger.Info(message);

            IQueryable<Payment> payments = null;
            try
            {
                payments = (from a in _context.Payments select a);
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

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

            return await payments.ToListAsync();
        }



    }// END CLASS
}
