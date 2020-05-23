using AppWebClient.Tools;
using AppWebClient.ViewModel;
using AppWebClient.Models; 

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using Stripe;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace AppWebClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;

        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // HTTPCLIENT 
        private HttpClient _client = ApiHttpClient.ConnectClient();

        // URL 
        private string _url = $"api/Home/";





        public async Task<IActionResult> Index()
        {
            // Retourner le ID de l'utilisateur 
            // ________________________________________________________
            // To obtain the User Id
            // ________________________________________________________

            AspNetUser user = new AspNetUser();


            // To obtain the shopping cart of User (id) 
            string accessToken = await HttpContext.GetTokenAsync("access_token");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            string uri1 = _configuration["URLApi"] + "api/AspNetUsers/" + "UserId";
            string id = await _client.GetStringAsync(uri1); // Error 401 :  Unauthorized


            ViewBag.USER = id;
            ViewBag.USERID = id;


            return View();
        }




        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }



        public void PageAdmin()
        {
            Response.Redirect(_configuration["URLIdentity"] + "administration/listroles");
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



        public async Task<IActionResult> CallApi()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var content = await client.GetStringAsync(_configuration["URLApi"] + "api/Books");

            ViewBag.Json = JArray.Parse(content).ToString();
            return View("json");
        }



        public IActionResult Logout()
        {
            return SignOut("Cookies", "oidc");
        }
    }
}