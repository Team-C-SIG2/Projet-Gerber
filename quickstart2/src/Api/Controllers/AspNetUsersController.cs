namespace Api.Controllers
{
    using Api.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using NLog;
    using System;


    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AspNetUsersController : ControllerBase
    {
        // NLog 
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        // //////////////////////////////////////////////////////////////////////////////////////////////////////// 
        // Initialize the Database Context  
        // //////////////////////////////////////////////////////////////////////////////////////////////////////// 
        private readonly ESBookshopContext _context;

        public AspNetUsersController(ESBookshopContext context)
        {
            _context = context;
        }


        // //////////////////////////////////////////////////////////////////////////////////////////////////////// 
        // GET: api/AspNetUsers
        // //////////////////////////////////////////////////////////////////////////////////////////////////////// 

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AspNetUser>>> GetAspNetUsers()
        {
            // NLog 
            string message = $"(API Server) - Try to GET ALL Users - Controller name: AspNetUsersController; " +
                $"Actionname: GetAspNetUsers(); HTTP method : HttpGet; Time: " + DateTime.Now + "\n";
            _logger.Info(message);

            IQueryable<AspNetUser> users = null;
            try
            {
                users = _context.AspNetUsers;
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

                if (users == null)
                {
                    return NotFound();
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                }

            }

            return await users.ToListAsync();
        }

        // //////////////////////////////////////////////////////////////////////////////////////////////////////// 
        // GET: api/AspNetUsers/5
        // //////////////////////////////////////////////////////////////////////////////////////////////////////// 

        [HttpGet("{id}")]
        public async Task<ActionResult<AspNetUser>> GetAspNetUser(string id)
        {
            // NLog 
            string message = $"(API Server) - Try to GET ALL Users - Controller name: AspNetUsersController; " +
                $"Actionname: GetAspNetUsers(); HTTP method : HttpGet; Time: " + DateTime.Now + "\n";
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


        // //////////////////////////////////////////////////////////////////////////////////////////////////////// 
        // PUT: api/AspNetUsers/5
        // //////////////////////////////////////////////////////////////////////////////////////////////////////// 
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAspNetUser(string id, AspNetUser aspNetUser)
        {

            // NLog 
            string message = $"(API Server) -Try to PUT (update) AspNetUser " + id + "(Id) - Controller : AspNetUsersController; " +
                "Actionname: Put(...); HTTP method : HttpPut; Time: " + DateTime.Now + "\n";
            _logger.Info(message);

            try
            {
                _context.Entry(aspNetUser).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
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

                if (id != aspNetUser.Id)
                {
                    return BadRequest();
                }
                else if (!AspNetUserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                }
            }

            return NoContent();
        }

        // //////////////////////////////////////////////////////////////////////////////////////////////////////// 
        // POST: api/AspNetUsers
        // //////////////////////////////////////////////////////////////////////////////////////////////////////// 
        [HttpPost]
        public async Task<ActionResult<AspNetUser>> PostAspNetUser(AspNetUser aspNetUser)
        {
            // NLog 
            string message = $"(API Server) -Try to POST AspNetUser " + aspNetUser.Id + "(Id) - Controller : AspNetUsersController; " +
                "Actionname: Post(...); HTTP method : HttpPost; Time: " + DateTime.Now + "\n\n";
            _logger.Info(message);

            try
            {
                _context.AspNetUsers.Add(aspNetUser);
                await _context.SaveChangesAsync();

                _context.Entry(aspNetUser).GetDatabaseValues();
                return CreatedAtAction("GetAspNetUser", new { id = aspNetUser.Id }, aspNetUser);
            }
            catch (DbUpdateException ex)
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

                if (AspNetUserExists(aspNetUser.Id))
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
        // DELETE: api/AspNetUsers/5
        // //////////////////////////////////////////////////////////////////////////////////////////////////////// 

        [HttpDelete("{id}")]
        public async Task<ActionResult<AspNetUser>> DeleteAspNetUser(string id)
        {
            // NLog 
            string message = $"(API Server) -Try to DELETE AspNetUser " + id + "(Id) - Controller : AspNetUsersController; " +
                "Actionname: Delete(...); HTTP method : HttpDelete; Time: " + DateTime.Now + "\n\n";
            _logger.Info(message);

            AspNetUser aspNetUser = new AspNetUser();
            try
            {
                aspNetUser = await _context.AspNetUsers.FindAsync(id);
                _context.AspNetUsers.Remove(aspNetUser);
                await _context.SaveChangesAsync();
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
                    return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                {
                }
            }

            return aspNetUser;
        }


        // //////////////////////////////////////////////////////////////////////////////////////////////////////// 
        // BOOL: AspNetUserExists
        // //////////////////////////////////////////////////////////////////////////////////////////////////////// 
        private bool AspNetUserExists(string id)
        {
            // NLog 
            string message = $"(API Server) - Verify if an AspNetUser " + id + "(Id) exists - Controller : AspNetUsersController; " +
                "Actionname: AppreciationExists(...); Return: bool; Time: " + DateTime.Now + "\n\n";
            _logger.Info(message);

            bool exist = false;
            try
            {
                exist = _context.AspNetUsers.Any(e => e.Id == id);
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

                return exist = false;
            }

            return exist;

        }

        // //////////////////////////////////////////////////////////////////////////////////////////////////////// 
        // STRING : GetUserId()
        // //////////////////////////////////////////////////////////////////////////////////////////////////////// 
        [Route("UserId")]
        public string GetUserId()
        {
            // NLog 
            string message = $"(API Server) - Try to GET ALL LineItems - Controller: AppreciationsController; " +
                $"Actionname: GetLineItems(); HTTP method : HttpGet; Time: " + DateTime.Now + "\n";
            _logger.Info(message);

            string userId = null;
            try
            {
                userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
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

                userId = null;
            }

            return userId;
        }



    }// End Class 

}
