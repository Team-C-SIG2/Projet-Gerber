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
    public class UserLineItemsController : ControllerBase
    {
        // NLog 
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Initialize the Database Context 
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        private readonly ESBookshopContext _context;

        public UserLineItemsController(ESBookshopContext context)
        {
            _context = context;
        }

        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // LinQ Request - Will return the list of users with shoppingcart and items 
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////


        /*
        // A User JSON structure 

            {
                "id": 24,
                "userId": null,
                "createdDate": "2020-04-18T04:04:00",
                "user": {
                    "id": "0012988355",
                    "idCustomer": 7085,
                    "username": "Mark",
                    "normalizedUsername": null,
                    "email": "Mark.Stenzler@worldmail.com                                                                                                                                                                                                                                    ",
                    "normalizedEmail": null,
                    "emailConfirmed": true,
                    "passwordHash": null,
                    "securityStamp": null,
                    "concurrencyStamp": null,
                    "phoneNumber": "01 940 07 28",
                    "phoneNumberConfirmed": true,
                    "twoFactorEnabled": true,
                    "lockoutEnd": "2020-04-09T22:25:21.4",
                    "lockoutEnabled": true,
                    "accessFailedCount": 0,
                    "idCustomerNavigation": null,
                    "aspNetUserClaims": [],
                    "aspNetUserLogins": [],
                    "aspNetUserRoles": [],
                    "aspNetUserTokens": [],
                    "orders": [],
                    "payments": [],
                    "shoppingCarts": []
            },
                "lineItems": []
        },

        */


        // __________________________________________________________________________
        // REturn the Users List
        // __________________________________________________________________________
        [Route("GetAllUsers")]
        public IQueryable<AspNetUser> GetAllUsers()
        {
            // NLog 
            string message = $"(API Server) - Try to GET ALL AspNetUser - Controller: UserLineItemsController; " +
                $"Actionname: GetAllUsers(); HTTP method : HttpGet; Route .../GetAllUsers/ ; Time: " + DateTime.Now + "\n";
            _logger.Info(message);

            IQueryable<AspNetUser> users;
            try
            {
                users = (from i in _context.AspNetUsers
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
                             ShoppingCarts = (from s in _context.ShoppingCarts where s.UserId == i.Id select s).ToList()
                         });
            }
            catch (Exception ex)
            {
                // NLog Framework Call 

                // LOG INFO 
                _logger.Info("INFORMATION DETAILS, Exception occured during operation : " + message);
                _logger.Info("EXCEPTION DETAILS: " + ex.Message + "\n\n");

                // LOG WARN
                _logger.Warn("WARNING DETAILS, Exception occured during operation : " + message);
                _logger.Warn("EXCEPTION DETAILS: " + ex.Message + "\n\n");

                // LOG ERROR
                _logger.Error("ERROR DETAILS, Exception occured during operation : " + message);
                _logger.Error("EXCEPTION DETAILS: " + ex.Message + "\n\n");

                // LOG TRACE 
                _logger.Trace("WARNING DETAILS, Exception occured during operation : " + message);
                _logger.Trace("EXCEPTION DETAILS: " + ex.Message + "\n\n");

                // LOG FATAL
                _logger.Fatal("FATAL DETAILS, Exception occured during operation : " + message);
                _logger.Fatal("EXCEPTION DETAILS: " + ex.Message + "\n\n");

                // LOG DEGUG 
                _logger.Debug("DEGUG DETAILS, Exception occured during operation : " + message);
                _logger.Debug("EXCEPTION DETAILS: " + ex.Message + "\n\n");

                return null;
            }

            return users;
        }

        // __________________________________________________________________________
        // Search and return a user in the user List
        // __________________________________________________________________________
        [Route("User/{id?}")]
        public AspNetUser GeUserById(string id)
        {
            // NLog 
            string message = $"(API Server) -Try to GET AspNetUser " + id + "(Id) - Controller name: UserLineItemsController; " +
                "Actionname: GeUserById(id); HTTP method : HttpGet; Time: " + DateTime.Now + "\n\n";
            _logger.Info(message);

            AspNetUser aspNetUser = new AspNetUser();
            AspNetUser asp = new AspNetUser();
            bool found = false;
            try
            {
                var users = GetAllUsers();

                // if users list empty 
                if (users == null)
                {
                    found = false;
                }
                else
                {
                    // Looking for user shopping cart
                    foreach (var user in users)
                    {
                        if (user.Id == id)
                        {
                            asp = user;
                            found = true;
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                // NLog Framework Call 

                // LOG INFO 
                _logger.Info("INFORMATION DETAILS, Exception occured during operation : " + message);
                _logger.Info("EXCEPTION DETAILS: " + ex.Message + "\n\n");

                // LOG WARN
                _logger.Warn("WARNING DETAILS, Exception occured during operation : " + message);
                _logger.Warn("EXCEPTION DETAILS: " + ex.Message + "\n\n");

                // LOG ERROR
                _logger.Error("ERROR DETAILS, Exception occured during operation : " + message);
                _logger.Error("EXCEPTION DETAILS: " + ex.Message + "\n\n");

                // LOG TRACE 
                _logger.Trace("WARNING DETAILS, Exception occured during operation : " + message);
                _logger.Trace("EXCEPTION DETAILS: " + ex.Message + "\n\n");

                // LOG FATAL
                _logger.Fatal("FATAL DETAILS, Exception occured during operation : " + message);
                _logger.Fatal("EXCEPTION DETAILS: " + ex.Message + "\n\n");

                // LOG DEGUG 
                _logger.Debug("DEGUG DETAILS, Exception occured during operation : " + message);
                _logger.Debug("EXCEPTION DETAILS: " + ex.Message + "\n\n");

                return null;
            }
            return asp;
        }

        // __________________________________________________________________________
        // To  get the shopping cart of user (id) & send  to MVC View (in a ViewBag)
        // __________________________________________________________________________

        [Route("Cart/{id?}")]
        public ActionResult<ShoppingCart> GetShoppingCartByUserId(string id)
        {
            // NLog 
            string message = $"(API Server) -Try to GET ShoppingCart by User Id " + id + " - Controller name: UserLineItemsController; " +
                "Actionname: GetShoppingCartByUserId(id); HTTP method : HttpGet; Route : .../Cart/id ; Time: " + DateTime.Now + "\n\n";
            _logger.Info(message);

            AspNetUser aspNetUser = new AspNetUser();
            ShoppingCart shoppingCart = new ShoppingCart();
            bool found = false;
            try
            {
                // Execut the SQL query to get the users list 
                var users = GetAllUsers();

                // if users list empty 
                if (users == null)
                {
                    found = false;
                }
                else
                {
                    // Looking for user shopping cart
                    foreach (var user in users)
                    {
                        foreach (var cart in user.ShoppingCarts)
                        {
                            if (cart.UserId == id)
                            {
                                shoppingCart = cart;
                                found = true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // NLog Framework Call 

                // LOG INFO 
                _logger.Info("INFORMATION DETAILS, Exception occured during operation : " + message);
                _logger.Info("EXCEPTION DETAILS: " + ex.Message + "\n\n");

                // LOG WARN
                _logger.Warn("WARNING DETAILS, Exception occured during operation : " + message);
                _logger.Warn("EXCEPTION DETAILS: " + ex.Message + "\n\n");

                // LOG ERROR
                _logger.Error("ERROR DETAILS, Exception occured during operation : " + message);
                _logger.Error("EXCEPTION DETAILS: " + ex.Message + "\n\n");

                // LOG TRACE 
                _logger.Trace("WARNING DETAILS, Exception occured during operation : " + message);
                _logger.Trace("EXCEPTION DETAILS: " + ex.Message + "\n\n");

                // LOG FATAL
                _logger.Fatal("FATAL DETAILS, Exception occured during operation : " + message);
                _logger.Fatal("EXCEPTION DETAILS: " + ex.Message + "\n\n");

                // LOG DEGUG 
                _logger.Debug("DEGUG DETAILS, Exception occured during operation : " + message);
                _logger.Debug("EXCEPTION DETAILS: " + ex.Message + "\n\n");

                if (aspNetUser == null || found == false || shoppingCart == null)
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

        // __________________________________________________________________________
        // To get LineItems List of a ShoppingCart (Id) and send it to View (ViewBag)
        // __________________________________________________________________________

        [Route("Items/{id?}")]
        public async Task<ActionResult<IEnumerable<LineItem>>> GetCartItemByShoppingCartId(int? id)
        {
            // NLog 
            string message = $"(API Server) - Try to GET ALL LineItems By ShoppingCart Id - Controller: UserLineItemsController; " +
                $"Actionname: GetCartItemByShoppingCartId(); HTTP method : HttpGet; Route : .../Items/id ; Time: " + DateTime.Now + "\n";
            _logger.Info(message);

            IQueryable<LineItem> lines;
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
                        IdBook = i.IdBook,
                        IdOrder = i.IdOrder,
                        IdBookNavigation = (from b in _context.Books where b.Id == i.IdBook select b).FirstOrDefault(),
                        IdShoppingcartNavigation = (from s in _context.ShoppingCarts where s.Id == i.IdShoppingcart select s).FirstOrDefault()
                    });
            }
            catch (Exception ex)
            {
                // NLog Framework Call 

                // LOG INFO 
                _logger.Info("INFORMATION DETAILS, Exception occured during operation : " + message);
                _logger.Info("EXCEPTION DETAILS: " + ex.Message + "\n\n");

                // LOG WARN
                _logger.Warn("WARNING DETAILS, Exception occured during operation : " + message);
                _logger.Warn("EXCEPTION DETAILS: " + ex.Message + "\n\n");

                // LOG ERROR
                _logger.Error("ERROR DETAILS, Exception occured during operation : " + message);
                _logger.Error("EXCEPTION DETAILS: " + ex.Message + "\n\n");

                // LOG TRACE 
                _logger.Trace("WARNING DETAILS, Exception occured during operation : " + message);
                _logger.Trace("EXCEPTION DETAILS: " + ex.Message + "\n\n");

                // LOG FATAL
                _logger.Fatal("FATAL DETAILS, Exception occured during operation : " + message);
                _logger.Fatal("EXCEPTION DETAILS: " + ex.Message + "\n\n");

                // LOG DEGUG 
                _logger.Debug("DEGUG DETAILS, Exception occured during operation : " + message);
                _logger.Debug("EXCEPTION DETAILS: " + ex.Message + "\n\n");

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

            return await lines.ToListAsync();

        }

        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // GET (HTTP VERB): api/UserLineItems	
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AspNetUser>>> GetAspNetUsers()
        {
            // NLog 
            string message = $"(API Server) - Try to GET ALL AspNetUser - Controller: UserLineItemsController; " +
                $"Actionname: GetAspNetUsers(); HTTP method : HttpGet; Time: " + DateTime.Now + "\n";
            _logger.Info(message);

            IQueryable<AspNetUser> users;
            try
            {
                users = GetAllUsers();
            }
            catch (Exception ex)
            {
                // NLog Framework Call 

                // LOG INFO 
                _logger.Info("INFORMATION DETAILS, Exception occured during operation : " + message);
                _logger.Info("EXCEPTION DETAILS: " + ex.Message + "\n\n");

                // LOG WARN
                _logger.Warn("WARNING DETAILS, Exception occured during operation : " + message);
                _logger.Warn("EXCEPTION DETAILS: " + ex.Message + "\n\n");

                // LOG ERROR
                _logger.Error("ERROR DETAILS, Exception occured during operation : " + message);
                _logger.Error("EXCEPTION DETAILS: " + ex.Message + "\n\n");

                // LOG TRACE 
                _logger.Trace("WARNING DETAILS, Exception occured during operation : " + message);
                _logger.Trace("EXCEPTION DETAILS: " + ex.Message + "\n\n");

                // LOG FATAL
                _logger.Fatal("FATAL DETAILS, Exception occured during operation : " + message);
                _logger.Fatal("EXCEPTION DETAILS: " + ex.Message + "\n\n");

                // LOG DEGUG 
                _logger.Debug("DEGUG DETAILS, Exception occured during operation : " + message);
                _logger.Debug("EXCEPTION DETAILS: " + ex.Message + "\n\n");

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

            return await users.ToListAsync();
        }


        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // GET: api/UserLineItems/5
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////

        // GET: api/UserLineItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AspNetUser>> GetAspNetUser(string id)
        {
            // NLog 
            string message = $"(API Server) -Try to GET AspNetUser " + id + "(Id) - Controller name: UserLineItemsController; " +
                "Actionname: GetAspNetUser(id); HTTP method : HttpGet; Time: " + DateTime.Now + "\n\n";
            _logger.Info(message);

            AspNetUser aspNetUser = new AspNetUser();
            try
            {
                aspNetUser = await _context.AspNetUsers.FindAsync(id);
            }
            catch (Exception ex)
            {
                // NLog Framework Call 

                // LOG INFO 
                _logger.Info("INFORMATION DETAILS, Exception occured during operation : " + message);
                _logger.Info("EXCEPTION DETAILS: " + ex.Message + "\n\n");

                // LOG WARN
                _logger.Warn("WARNING DETAILS, Exception occured during operation : " + message);
                _logger.Warn("EXCEPTION DETAILS: " + ex.Message + "\n\n");

                // LOG ERROR
                _logger.Error("ERROR DETAILS, Exception occured during operation : " + message);
                _logger.Error("EXCEPTION DETAILS: " + ex.Message + "\n\n");

                // LOG TRACE 
                _logger.Trace("WARNING DETAILS, Exception occured during operation : " + message);
                _logger.Trace("EXCEPTION DETAILS: " + ex.Message + "\n\n");

                // LOG FATAL
                _logger.Fatal("FATAL DETAILS, Exception occured during operation : " + message);
                _logger.Fatal("EXCEPTION DETAILS: " + ex.Message + "\n\n");

                // LOG DEGUG 
                _logger.Debug("DEGUG DETAILS, Exception occured during operation : " + message);
                _logger.Debug("EXCEPTION DETAILS: " + ex.Message + "\n\n");

                if (aspNetUser == null)
                {
                    return NotFound();
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                }
            }

            return aspNetUser;
        }

    }// End Class
}
