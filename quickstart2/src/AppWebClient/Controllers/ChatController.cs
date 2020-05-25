using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AppWebClient.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace AppWebClient.Controllers
{
    [Authorize]
    public class ChatController : Controller
    {
        private readonly IConfiguration _configuration;

        public ChatController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<IActionResult> Index()
        {
            string accessToken = await HttpContext.GetTokenAsync("access_token");

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            ///*
            //string idUser = UserID;
            //string uriShoppingcart = _url + "GetUserShoppingCart/";
            //*/

            string idUser = await client.GetStringAsync(_configuration["URLApi"] + "api/AspNetUsers/UserId/"); // HTTP GET
            string users = await client.GetStringAsync(_configuration["URLApi"] + "api/AspNetUsers");
            List<AspNetUser> CurrentUsers = JsonConvert.DeserializeObject<List<AspNetUser>>(users);
            var user = (from a in CurrentUsers
                        where a.Id == idUser
                        select a.Username).FirstOrDefault();
            ViewBag.user = user;
            //ViewBag.user = User.FindFirstValue(ClaimTypes.NameIdentifier);
            //return View(CurrentUser);
            return View();
        }
    }
}