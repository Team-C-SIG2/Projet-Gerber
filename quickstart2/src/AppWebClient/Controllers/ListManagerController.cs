using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AppWebClient.Controllers
{
    public class ListManagerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
