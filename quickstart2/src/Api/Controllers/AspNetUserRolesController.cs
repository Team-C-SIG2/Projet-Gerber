

namespace Api.Controllers
{
    using Api.ViewModel; 
    using Api.Models;    
    using System;
    using System.Linq;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using System.Security.Claims;





    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AspNetUserRolesController : ControllerBase
    {

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
            // Return the CONNECTED USER ID 


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
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

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

            return currentUserRole;

        }




    }// End Class 
}