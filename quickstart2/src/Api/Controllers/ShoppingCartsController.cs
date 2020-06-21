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
    using Microsoft.Data.SqlClient;


    [Route("api/[controller]")]
    [ApiController]

    [Authorize]
    public class ShoppingCartsController : ControllerBase
    {
        // NLog 
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Initialize the Database Context 
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        private readonly ESBookshopContext _context;

        public ShoppingCartsController(ESBookshopContext context)
        {
            _context = context;
        }

        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // To GET LineItems List of a ShoppingCart (Id)
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////

        // _____________________________________________________
        // GET (HTTP VERB): api/ShoppingCarts/Items/S	
        // _____________________________________________________

        [Route("Items/{id}")]
        public async Task<ActionResult<IEnumerable<LineItem>>> GetLineItems(int? id)
        {
            // NLog 
            string message = $"(API Server) - Try to GET ALL LineItems of ShoppingCart " + id + " (Id) - Controller name: ShoppingCartsController; " +
                $"Actionname: GetLineItems(); HTTP method : HttpGet; Route: Items/id;  Time: " + DateTime.Now + "\n";
            _logger.Info(message);

            IQueryable<LineItem> cartItems = null;
            try
            {
                cartItems = (from c in _context.LineItems where c.IdShoppingcart == id select c);
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

                if (cartItems == null)
                {
                    return NotFound();
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                }

            }

            return await cartItems.ToListAsync();
        }

        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Get ShoppingCart List
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////

        [Route("ShoppingCarts")]
        public IQueryable<ShoppingCart> GetAll()
        {
            // NLog 
            string message = $"(API Server) - Try to GET ALL ShoppingCarts - Controller: ShoppingCartsController; " +
                $"Actionname: GetAll(); HTTP method : HttpGet; Route : .../ShoppingCarts/ ; Time: " + DateTime.Now + "\n";
            _logger.Info(message);

            IQueryable<ShoppingCart> items;
            try
            {
                items =
                    (from i in _context.ShoppingCarts
                     select new ShoppingCart()
                     {
                         Id = i.Id,
                         CreatedDate = i.CreatedDate,

                         User = (from user in _context.AspNetUsers
                                 where user.Id == i.UserId
                                 select user).FirstOrDefault()
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

                return null;
            }

            return items;
        }

        // _____________________________________________________
        // GET (HTTP VERB): api/ShoppingCarts	
        // _____________________________________________________

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShoppingCart>>> GetShoppingCarts()
        {
            // NLog 
            string message = $"(API Server) - Try to GET ALL ShoppingCarts - Controller: ShoppingCartsController; " +
                $"Actionname: GetShoppingCarts(); HTTP method : HttpGet; Time: " + DateTime.Now + "\n";
            _logger.Info(message);

            IQueryable<ShoppingCart> items;
            try
            {
                items = GetAll();
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
        // Return a ShoppingCart (id)
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////

        [Route("ShoppingCart/{id}")]
        public ShoppingCart GetOne(string id)
        {
            // NLog 
            string message = $"(API Server) -Try to GET ShoppingCart " + id + "(Id) - Controller name: ShoppingCartsController; " +
                "Actionname: GetOne(id); HTTP method : HttpGet; Route : ShoppingCart/id ; Time: " + DateTime.Now + "\n";
            _logger.Info(message);

            ShoppingCart item;
            try
            {
                item = (from i in _context.ShoppingCarts
                        where i.UserId == id
                        select new ShoppingCart()
                        {
                            Id = i.Id,
                            CreatedDate = i.CreatedDate,
                            User = (from user in _context.AspNetUsers
                                    where user.Id == i.UserId
                                    select user).FirstOrDefault()
                        }).FirstOrDefault();
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

                return null;
            }

            return item;
        }

        // _____________________________________________________
        // GET (HTTP VERB): api/ShoppingCarts/S 
        // _____________________________________________________

        [Route("GetShoppingCart/{id}")]
        public ActionResult<ShoppingCart> GetShoppingCarts(string id) // string UserID
        {
            // NLog 
            string message = $"(API Server) -Try to GET ShoppingCart " + id + "(Id) - Controller name: ShoppingCartsController; " +
                "Actionname: GetShoppingCarts(id); HTTP method : HttpGet; Route : GetShoppingCart/id ; Time: " + DateTime.Now + "\n";
            _logger.Info(message);

            ShoppingCart shoppingCart = new ShoppingCart();
            try
            {
                shoppingCart = GetOne(id);
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

                if (shoppingCart == null)
                {
                    return NotFound();
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                }
            }

            return shoppingCart;
        }

        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // GET : GetUserShoppingCarts/userId
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////

        [Route("GetUserShoppingCarts/{userId}")]
        public ActionResult<ShoppingCart> GetUserShoppingCarts(string userId) // string UserID
        {
            // NLog 
            string message = $"(API Server) -Try to GET User " + userId + "(userId) ShoppingCarts - Controller name: ShoppingCartsController; " +
                "Actionname: GetUserShoppingCarts(id); HTTP method : HttpGet; Route : GetUserShoppingCarts/userId ; Time: " + DateTime.Now + "\n";
            _logger.Info(message);

            ShoppingCart shoppingCart = new ShoppingCart();
            try
            {
                shoppingCart = (from sp in _context.ShoppingCarts
                                where sp.UserId == userId
                                select sp).FirstOrDefault();
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

                if (shoppingCart == null || userId == null)
                {
                    return NotFound();
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                }
            }

            return shoppingCart;
        }

        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // GET : Get User's ShoppingCarts 
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        [Route("GetShoppingCartUser/{id}")]
        public async Task<ActionResult<ShoppingCart>> GetShoppingCartUser(int? id)
        {
            // NLog 
            string message = $"(API Server) -Try to GET User's ShoppingCarts " + id + "(id)  - Controller name: ShoppingCartsController; " +
                "Actionname: GetShoppingCartUser(id); HTTP method : HttpGet; Route : GetShoppingCartUser/id ; Time: " + DateTime.Now + "\n";
            _logger.Info(message);

            ShoppingCart shoppingCart = new ShoppingCart();
            try
            {
                shoppingCart = await _context.ShoppingCarts.FindAsync(id);
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

                if (shoppingCart == null || id == null)
                {
                    return NotFound();
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                }
            }

            return shoppingCart;
        }

        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // GET the Users List
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        [Route("Users")]
        public IQueryable<AspNetUser> GetAllUsers()
        {
            // NLog 
            string message = $"(API Server) - Try to GET ALL Users - Controller: ShoppingCartsController; " +
                $"Actionname: GetAllUsers(); HTTP method : HttpGet; Route .../Users ; Time: " + DateTime.Now + "\n";
            _logger.Info(message);

            IQueryable<AspNetUser> users = null;
            try
            {
                users =
                    (from i in _context.AspNetUsers
                     select new AspNetUser()
                     {
                         Id = i.Id,
                         IdCustomer = i.IdCustomer,
                         Username = i.Username,
                         Email = i.Email,
                         EmailConfirmed = i.EmailConfirmed,
                         PasswordHash = i.PasswordHash,
                         PhoneNumber = i.PhoneNumber,
                         TwoFactorEnabled = i.TwoFactorEnabled,
                         LockoutEnabled = i.LockoutEnabled,
                         LockoutEnd = i.LockoutEnd,
                         Orders = (from o in _context.Orders where o.UserId == i.Id select o).ToList(),
                         Payments = (from p in _context.Payments where p.UserId == i.Id select p).ToList(),
                         ShoppingCarts = (from s in _context.ShoppingCarts where s.UserId == i.Id select s).ToList(),
                         //IdCustomerNavigation = (from c in _context.Customers where c.Id == i.IdCustomer select c).FirstOrDefault()
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

                return null;
            }
            return users;

        }

        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // GET User 
        /// ////////////////////////////////////////////////////////////////////////////////////////////////////////

        [Route("User/{id}")]
        public ActionResult<IEnumerable<AspNetUser>> GetOneUser(string id)
        {
            // NLog 
            string message = $"(API Server) - Try to GET a User by its Id - Controller: ShoppingCartsController; " +
                $"Actionname: GetOneUser(); HTTP method : HttpGet; Route .../User/id ; Time: " + DateTime.Now + "\n";
            _logger.Info(message);

            List<AspNetUser> users = new List<AspNetUser>();
            AspNetUser user = new AspNetUser();
            try
            {
                user = (from i in _context.AspNetUsers
                        where i.Id == id
                        select new AspNetUser()
                        {
                            Id = i.Id,
                            IdCustomer = i.IdCustomer,
                            Username = i.Username,
                            Email = i.Email,
                            EmailConfirmed = i.EmailConfirmed,
                            PasswordHash = i.PasswordHash,
                            PhoneNumber = i.PhoneNumber,
                            TwoFactorEnabled = i.TwoFactorEnabled,
                            LockoutEnabled = i.LockoutEnabled,
                            LockoutEnd = i.LockoutEnd,
                            Orders = (from o in _context.Orders where o.UserId == i.Id select o).ToList(),
                            Payments = (from p in _context.Payments where p.UserId == i.Id select p).ToList(),
                            ShoppingCarts = (from s in _context.ShoppingCarts where s.UserId == i.Id select s).ToList(),
                            IdCustomerNavigation = (from c in _context.Customers where c.Id == i.IdCustomer select c).FirstOrDefault()
                        }).FirstOrDefault();

                users.Add(user);
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

                return null;
            }

            return users;
        }

        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // POST: api/ShoppingCarts/S
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        [HttpPost]
        [Route("CreateShoppingCart")]
        public async Task<ActionResult<ShoppingCart>> PostShoppingCart(ShoppingCart shoppingCart)
        {
            // NLog 
            string message = $"(API Server) -Try to POST ShoppingCart " + shoppingCart.Id + " (Id) - Controller : ShoppingCartsController; " +
                "Actionname: PostShoppingCart(...); HTTP method : HttpPost; Time: " + DateTime.Now + "\n";
            _logger.Info(message);

            try
            {
                _context.ShoppingCarts.Add(shoppingCart);
                await _context.SaveChangesAsync();

                _context.Entry(shoppingCart).GetDatabaseValues();

                return CreatedAtAction("GetShoppingCarts", new { id = shoppingCart.Id }, shoppingCart);
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
        }

    }// END CLASS
}
