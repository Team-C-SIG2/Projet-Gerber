using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {

        [AllowAnonymous]
        public string Index()
        {
            return "Welcome ! For our RESTFull API Server Documentation, just visite our web page 'www.esbookshop.ch'";
        }


        // _________________________________________________________
        // GET USER ID (EsbookshopDB.AspNetUsers.Id)
        // _________________________________________________________

        [Route("UserId")]
        public string GetUserId()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return userId;
        }



    }
}