using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Api.Models;
using System.Security.Claims;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    [Authorize]
    public class ShoppingCartsController : ControllerBase
    {

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
        // Action for Client RestFull API 
        // Route : https://localhost:44318/api/ShoppingCarts/Items/S
        // GET (HTTP VERB): api/ShoppingCarts/Items/S	
        // _____________________________________________________

        [Route("Items/{id}")]
        public async Task<ActionResult<IEnumerable<LineItem>>> GetLineItems(int? id)
        {
            //string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var cartItems = (from c in _context.LineItems where c.IdShoppingcart == id select c).ToListAsync();
            return await cartItems;
        }


        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Get ShoppingCart List
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////

        [Route("ShoppingCarts")]
        public IQueryable<ShoppingCart> GetAll()
        {
            var items =
                (from i in _context.ShoppingCarts
                 select new ShoppingCart()
                 {
                     Id = i.Id,
                     CreatedDate = i.CreatedDate,

                     User = (from user in _context.AspNetUsers
                             where user.Id == i.UserId
                             select user).FirstOrDefault()
                 });

            return items;
        }

        // _____________________________________________________
        // Action for Client RestFull API 
        // Route : https://localhost:44318/api/ShoppingCarts/
        // GET (HTTP VERB): api/ShoppingCarts	
        // _____________________________________________________

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShoppingCart>>> GetShoppingCarts()
        {

            var items = GetAll();

            if (items == null)
            {
                return NotFound();
            }
            return await items.ToListAsync();
        }



        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Return an ShoppingCart (id)
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////

        //[Route("ShoppingCart/{id}")]
        public ShoppingCart GetOne(string id)
        {
            //string id = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var item = (from i in _context.ShoppingCarts
                        where i.UserId == id
                        select new ShoppingCart()
                        {
                            Id = i.Id,
                            CreatedDate = i.CreatedDate,
                            User = (from user in _context.AspNetUsers
                                    where user.Id == i.UserId
                                    select user).FirstOrDefault()
                        }).FirstOrDefault();

            return item;
        }


        // _____________________________________________________
        // Action for Client RestFull API 
        // Get a resouce ShoppingCart 
        // Route : https://localhost:44318/api/ShoppingCarts/002078C2AB
        // GET (HTTP VERB): api/ShoppingCarts/S 
        // _____________________________________________________

        [HttpGet("{id}")]
        public ActionResult<ShoppingCart> GetShoppingCarts(string id) // string UserID
        {
            ShoppingCart shoppingCart = GetOne(id);

            if (shoppingCart == null)
            {
                return NotFound();
            }

            return shoppingCart;
        }


        [HttpGet("{id}")]
        public ActionResult<ShoppingCart> GetUserShoppingCarts() // string UserID
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            ShoppingCart shoppingCart = GetOne(userId);

            if (shoppingCart == null)
            {
                return NotFound();
            }

            return shoppingCart;
        }


        // __________________________________________________________________________
        // GET the Users List
        // __________________________________________________________________________
        [Route("Users")]
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
                     ShoppingCarts = (from s in _context.ShoppingCarts where s.UserId == i.Id select s).ToList(),
                     //IdCustomerNavigation = (from c in _context.Customers where c.Id == i.IdCustomer select c).FirstOrDefault()
                 });


            return users;

        }


        // __________________________________________________________________________
        // GET the User of cart
        // __________________________________________________________________________

        [Route("User/{id}")]
        public ActionResult<IEnumerable<AspNetUser>> GetOneUser(string id)
        {
            // var users = (from a in _context.AspNetUsers where a.Id == id select a).ToListAsync();

            List<AspNetUser> users = new List<AspNetUser>(); 

            var user =
                (from i in _context.AspNetUsers
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

            return  users;
        }

  
    }
}
