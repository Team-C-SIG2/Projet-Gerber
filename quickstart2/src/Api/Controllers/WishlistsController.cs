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
    using Microsoft.Data.SqlClient;
    using Microsoft.AspNetCore.Http;

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class WishlistsController : ControllerBase
    {

        // NLog 
        private static Logger _logger = LogManager.GetCurrentClassLogger();


        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Initialize the Database Context 
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        private readonly ESBookshopContext _context;

        public WishlistsController(ESBookshopContext context)
        {
            _context = context;
        }
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // GET: api/Wishlists
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Wishlist>>> GetWishlists()
        {
            return await _context.Wishlists.ToListAsync();
        }


        [Route("Wishlist")]
        public IQueryable<Wishlist> GetWishlistsWithUser()
        {
            // NLog 
            string message = $"(API Server) - Try to GET User's Wishlist - Controller: WishlistsController; " +
                $"Actionname: GetWishlistsWithUser(); HTTP method : HttpGet; Route : .../Wishlist ; Time: " + DateTime.Now + "\n";
            _logger.Info(message);

            IQueryable<Wishlist> items;
            try
            {
                items = (from i in _context.Wishlists
                         select new Wishlist()
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

        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // GET: api/Wishlists/5
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        [HttpGet("{id}")]
        public async Task<ActionResult<Wishlist>> GetWishlist(int id)
        {
            // NLog 
            string message = $"(API Server) -Try to GET Wishlist " + id + "(Id) - Controller name: WishlistsController; " +
                "Actionname: GetWishlist(id); HTTP method : HttpGet; Time: " + DateTime.Now + "\n";
            _logger.Info(message);

            Wishlist wishlist = new Wishlist();
            try
            {
                wishlist = await _context.Wishlists.FindAsync(id);
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

                if (wishlist == null)
                {
                    return NotFound();
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                }
            }

            return wishlist;
        }

        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // GET api/Wishlists/5/
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        [Route("Wishlist/{id}")]
        public Wishlist GetUserWishlist(string id)
        {
            // NLog 
            string message = $"(API Server) -Try to GET User Wishlist - Controller name: WishlistsController; " +
                "Actionname: GetUserWishlist(id); HTTP method : HttpGet; Route : .../Wishlist/id ; Time: " + DateTime.Now + "\n";
            _logger.Info(message);

            Wishlist item = new Wishlist();
            try
            {
                item = (from i in _context.Wishlists
                        where i.UserId == id
                        select new Wishlist()
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

            }

            return item;
        }



        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // PUT: api/Wishlists/5
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWishlist(int id, Wishlist wishlist)
        {
            // NLog 
            string message = $"(API Server) -Try to PUT (update) Wishlist " + id + "(Id) - Controller : WishlistsController; " +
                "Actionname: PutWishlist(...); HTTP method : HttpPut; Time: " + DateTime.Now + "\n";
            _logger.Info(message);

            try
            {
                _context.Entry(wishlist).State = EntityState.Modified;
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

                if (id != wishlist.Id)
                {
                    return BadRequest();
                }
                else if (!WishlistExists(id))
                {
                    return NotFound();
                }

                return NotFound();
            }

            return NoContent();
        }



        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // POST: api/Wishlists
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        [HttpPost]
        public async Task<ActionResult<Wishlist>> PostWishlist(Wishlist wishlist)
        {
            // NLog 
            string message = $"(API Server) -Try to POST Wishlist " + wishlist.Id + " (Id) - Controller : WishlistsController; " +
                "Actionname: PostWishlist(...); HTTP method : HttpPost; Time: " + DateTime.Now + "\n";
            _logger.Info(message);

            try
            {
                _context.Wishlists.Add(wishlist);
                await _context.SaveChangesAsync();

                _context.Entry(wishlist).GetDatabaseValues();
                return CreatedAtAction("GetWishlist", new { id = wishlist.Id }, wishlist);
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

                if (WishlistExists(wishlist.Id))
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
        // DELETE: api/Wishlists/5
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        [HttpDelete("{id}")]
        public async Task<ActionResult<Wishlist>> DeleteWishlist(int id)
        {
            // NLog 
            string message = $"(API Server) -Try to DELETE Wishlist " + id + "(Id) - Controller : WishlistsController; " +
                "Actionname: DeleteWishlist(id); HTTP method : HttpDelete; Time: " + DateTime.Now + "\n";
            _logger.Info(message);

            Wishlist wishlist = null;
            try
            {
                // Find categorie 
                wishlist = await _context.Wishlists.FindAsync(id);

                // Remove categorie 
                _context.Wishlists.Remove(wishlist);
                await _context.SaveChangesAsync();

                // GET UPDATED DB VALUES 
                _context.Entry(wishlist).GetDatabaseValues();

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

                if (wishlist == null)
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

            return wishlist;
        }


        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // BOOL : Exists?
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        private bool WishlistExists(int id)
        {
            // NLog 
            string message = $"(API Server) - Verify if the Wishlist " + id + "(Id) EXISTS - Controller : WishlistsController; " +
                "Actionname: WishlistExists(id); Return: bool; Time: " + DateTime.Now + "\n";
            _logger.Info(message);

            bool exist = false;
            try
            {
                exist = _context.Wishlists.Any(e => e.Id == id);
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


    }
}
