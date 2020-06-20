namespace Api.Controllers
{
    using Api.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Data.SqlClient;
    using Microsoft.EntityFrameworkCore;
    using NLog;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;


    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        // NLog 
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Initialize the Database Context 
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        private readonly ESBookshopContext _context;

        public OrdersController(ESBookshopContext context)
        {
            _context = context;
        }

        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // GET: api/Orders
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            // NLog 
            string message = $"(API Server) - Try to GET ALL Order - Controller: OrdersController; " +
                $"Actionname: GetOrders(); HTTP method : HttpGet;  Time: " + DateTime.Now + "\n";
            _logger.Info(message);

            IQueryable<Order> orders;
            try
            {
                orders = _context.Orders;
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
        // GET: api/Orders
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////

        [Route("Commandes/{id}")]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrdersWithUser(string id)
        {
            // NLog 
            string message = $"(API Server) - Try to GET ALL Order of User " + id + " (Id) - Controller: OrdersController; " +
                $"Actionname: GetOrdersWithUser(id); HTTP method : HttpGet; Route : /Commandes/id ;  Time: " + DateTime.Now + "\n";
            _logger.Info(message);

            IQueryable<Order> orders;
            try
            {
                /* 
                 SELECT [Id]
                      ,[UserId]
                      ,[OrderedDate]
                      ,[ShippedDate]
                      ,[ShippingAddress]
                      ,[Status]
                      ,[TotalPrice]
                  FROM [ESBookshop8].[dbo].[Orders]
                  where UserId = 'c9ec883f-dc10-476f-8d41-a79106fcfde6'

                */

                orders =
                    (from i in _context.Orders
                     where i.UserId == id // HB 
                     select new Order()
                     {
                         Id = i.Id,
                         UserId = i.UserId,
                         User = (from user in _context.AspNetUsers
                                 where user.Id == i.UserId
                                 select user).FirstOrDefault(),
                         OrderedDate = i.OrderedDate,
                         ShippedDate = i.ShippedDate,
                         ShippingAddress = i.ShippingAddress,
                         Status = i.Status,
                         TotalPrice = i.TotalPrice
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

            return await orders.ToListAsync();
        }
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // GET: api/Orders/5
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrders(int id)
        {
            // NLog 
            string message = $"(API Server) -Try to GET Order " + id + "(Id) - Controller name: OrdersController; " +
                "Actionname: GetOrders(id); HTTP method : HttpGet; Time: " + DateTime.Now + "\n";
            _logger.Info(message);

            Order order = new Order();
            try
            {
                order = await _context.Orders.FindAsync(id);
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

                if (order == null)
                {
                    return NotFound();
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                }
            }
            return order;
        }
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // PUT: api/Orders/5
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////

        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrders(int id, Order orders)
        {
            // NLog 
            string message = $"(API Server) -Try to PUT (update) Order " + id + "(Id) - Controller : OrdersController; " +
                "Actionname: PutOrders(...); HTTP method : HttpPut; Time: " + DateTime.Now + "\n";
            _logger.Info(message);

            try
            {
                _context.Entry(orders).State = EntityState.Modified;
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

                if (id != orders.Id)
                {
                    return BadRequest();
                }
                else if (!OrdersExists(id))
                {
                    return NotFound();
                }

                return NotFound();
            }

            return NoContent();
        }


        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // POST: api/Orders
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        [HttpPost]
        public async Task<ActionResult<Order>> PostOrders(Order orders)
        {
            // NLog 
            string message = $"(API Server) -Try to POST Order " + orders.Id + " (Id) - Controller : OrdersController; " +
                "Actionname: PostOrders(...); HTTP method : HttpPost; Time: " + DateTime.Now + "\n";
            _logger.Info(message);

            try
            {
                _context.Orders.Add(orders);
                await _context.SaveChangesAsync();

                _context.Entry(orders).GetDatabaseValues();
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

                if (OrdersExists(orders.Id))
                {
                    return Conflict();
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                }
            }
            return orders;
        }


        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // DELETE: api/Orders/5
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        [HttpDelete("{id}")]
        public async Task<ActionResult<Order>> DeleteOrders(int id)
        {
            // NLog 
            string message = $"(API Server) -Try to DELETE Order " + id + "(Id) - Controller : OrdersController; " +
                "Actionname: DeleteOrders(id); HTTP method : HttpDelete; Time: " + DateTime.Now + "\n";
            _logger.Info(message);

            Order order = null;
            try
            {
                // Find order 
                order = await _context.Orders.FindAsync(id);

                // Remove order 
                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();

                // GET UPDATED DB VALUES 
                _context.Entry(order).GetDatabaseValues();
            }
            catch (Exception ex)
            {
                var sqlException = ex.GetBaseException() as SqlException;

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

                if (order == null)
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
            return order;
        }

        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // BOOL : OrdersExists? 
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        private bool OrdersExists(int id)
        {
            // NLog 
            string message = $"(API Server) - Verify if the Order " + id + "(Id) EXISTS - Controller : OrdersController; " +
                "Actionname: OrdersExists(id) ; Return: bool; Time: " + DateTime.Now + "\n";
            _logger.Info(message);

            bool exist = false;
            try
            {
                exist = _context.Orders.Any(e => e.Id == id);
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
    }// END CLASS
}
