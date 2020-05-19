

namespace AppWebClient.Controllers
{

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;
    using AppWebClient.Models;


    public class DashboardController : Controller
    {

        public IActionResult Index()
        {

            // Contenu de Charts/Appreciations 
            // Redirection 
            return View();
        }
    }
}