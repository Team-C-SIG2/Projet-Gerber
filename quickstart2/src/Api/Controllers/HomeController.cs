using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;


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