namespace Api.Controllers
{
    using Api.Models;
    using Api.ViewModel;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;
    using NLog;
    using System;



    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AspNetUserRolesController : ControllerBase
    {
        // NLog 
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Initialize the Database Context 
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        private readonly ESBookshopContext _context;

        public AspNetUserRolesController(ESBookshopContext context)
        {
            _context = context;
        }


        // ----------------------------------------------------------
        // GET: api/AspNetUserRoles/5
        // TO GET ROLE TYPE OF CONNECTED USER 
        // ----------------------------------------------------------

        [HttpGet]
        [Route("GetUserRole")]
        public async Task<ActionResult<string>> GetUserRole()
        {
            // NLog 
            string message = $"(API Server) -Try to GET Connected User's Role  - Controller : AspNetUserRolesController; Actionname: GetUserRole(...); HTTP method : HttpGet; Time: " + DateTime.Now + "\n";
            _logger.Info(message);


            // Get connected user ROLE by its UserId
            /*
                -- SQL Query

                SELECT roles.Id AS RoleId, users.Id AS UserId, users.Email, users.Username, roles.NormalizedName, roles.Name
                FROM AspNetUserRoles usersRoles
                INNER JOIN AspNetRoles roles ON usersRoles.RoleId =  roles.Id
                INNER JOIN AspNetUsers users ON usersRoles.UserId =  users.Id 
                WHERE usersRoles.UserId = 'c9ec883f-dc10-476f-8d41-a79106fcfde6'

            */

            string currentUserRole = null;
            string userId = null;

            try
            {
                userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                var roles =
                    (from i in _context.AspNetUsers
                     join f in _context.AspNetUserRoles on i.Id equals f.UserId
                     join n in _context.AspNetRoles on f.RoleId equals n.Id
                     where (i.Id == f.UserId) && (n.Id == f.RoleId) || (f.RoleId != n.Id)
                     select new UserRolesViewModel()
                     {
                         UserId = i.Id,
                         Email = i.Email,
                         RoleName = n.Name,
                         NormalizedRoleName = n.NormalizedName,
                         RoleId = n.Id,
                         UserName = i.Username
                     }).ToList();

                if (roles != null)
                {
                    foreach (var role in roles)
                    {
                        if (role.UserId == userId)
                        {
                            currentUserRole = role.RoleName.ToUpper();
                        }
                    }
                }
                else
                {
                    string user = "Client";
                    currentUserRole = user.ToUpper();
                    return NotFound();
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

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

            return currentUserRole;
        }

    }// End Class 
}