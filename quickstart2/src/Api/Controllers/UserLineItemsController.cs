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
    public class UserLineItemsController : ControllerBase
    {


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


            var users =
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
                     ShoppingCarts = (from s in _context.ShoppingCarts where s.UserId == i.Id select s).ToList()
                 });


            return users;

        }


        // __________________________________________________________________________
        // Search and return a user in the user List
        // __________________________________________________________________________


        // [HttpGet("{id}")]   // GET /api/Controller/S
        // public IActionResult GetProduct(string id)

        // 0012988355

        [Route("User/{id?}")]
        public AspNetUser GeUserById(string id)
        {
            var users = GetAllUsers();
            AspNetUser asp = new AspNetUser();

            // if users list empty 
            if (users == null)
            {
                return null;
            }
            else
            {
                // Looking for user shopping cart
                foreach (var user in users)
                {
                    if (user.Id == id)
                    {
                        asp = user;
                    }

                }
            }

            return asp;
        }


        // __________________________________________________________________________
        // To  get the shopping cart of user (id) & send  to MVC View (in a ViewBag)
        // __________________________________________________________________________

        [Route("Cart/{id?}")]
        public ActionResult<ShoppingCart> GetShoppingCartByUserId(string id)
        {
            // Execut the SQL query to get the users list 
            var users = GetAllUsers();

            // Create un shoppingcart to save it 
            ShoppingCart shoppingCart = new ShoppingCart();

            // if users list empty 
            if (users == null)
            {
                return null;
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
                        }
                    }
                }
            }

            // Return value
            return shoppingCart;
        }

        // __________________________________________________________________________
        // To get LineItems List of a ShoppingCart (Id) and send it to View (ViewBag)
        // __________________________________________________________________________

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
        // Return the list of all resources AspNetUsers 
        // GET (HTTP VERB): api/UserLineItems	
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////

        /*
        // Original Method

                [HttpGet]
                public async Task<ActionResult<IEnumerable<AspNetUser>>> GetAspNetUsers()
                {
                    return await _context.AspNetUsers.ToListAsync();
                }
        */

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AspNetUser>>> GetAspNetUsers()
        {
            var users = GetAllUsers();

            if (users == null)
            {
                return NotFound();
            }
            return await users.ToListAsync();
        }


        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Return a the User of the LineItems (id)
        // GET: api/UserLineItems/5
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////

        // GET: api/UserLineItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AspNetUser>> GetAspNetUser(string id)
        {
            var aspNetUser = await _context.AspNetUsers.FindAsync(id);

            if (aspNetUser == null)
            {
                return NotFound();
            }

            return aspNetUser;
        }



    }// End Class
}
