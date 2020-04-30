using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AppWebClient.Models;
using Microsoft.AspNetCore.Authentication;
using System.Net.Http;
using System.Net.Http.Headers;

namespace AppWebClient.Controllers
{
    public class UserProfileController : Controller
    {
        public async Task<IActionResult> IndexAsync()
        {
            Customer Model = new Customer();
            var accessToken = await HttpContext.GetTokenAsync("access_token");

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var content = await client.GetStringAsync("http://localhost:5001/api/Customer/" + 2); // Faire controller API + liaison avec la vue pour récupérer données
            return View();
        }
    }
}