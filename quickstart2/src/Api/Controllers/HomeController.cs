using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


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

    }
}