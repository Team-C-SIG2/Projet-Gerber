using AppWebClient.ViewModel;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace AppWebClient.Controllers
{
    public class HomeController : Controller
    {
        // HTTPCLIENT 
        private HttpClient _client = new HttpClient();

        // URL 
        private string _url = $"api/Home/";


        // CONSTRUCTOR  
        private readonly IConfiguration _configuration;
        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        // _________________________________________
        // Return Home Index (Home page)
        // _____________________________________________

        public async Task<IActionResult> Index()
        {
            string accessToken = await HttpContext.GetTokenAsync("access_token");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            string accessRight = null;

            // GET CONNECTED USER ID 
            string uriUserId = _configuration["URLApi"] + "api/AspNetUsers/UserId";
            string idUser = await _client.GetStringAsync(uriUserId);


            // GET CONNECTED USER ROLE
            string uriUserRole = _configuration["URLApi"] + "api/AspNetUserRoles/GetUserRole/";
            string userRole = await _client.GetStringAsync(uriUserRole);// HTTP GET


            // GET ACCESS RIGHT ACCESS
            // For displaying or no the admin-links (Administration, Gestion des stocks, Roles, ...) in the Common Navigation Bar. 
            if (userRole.ToUpper() == "ADMIN")
            {
                accessRight = "ADMIN";
            }
            else
            {
                accessRight = "OTHERS";
            }

            // SEND THE ACCESS RIGHT VALUE TO THE VIEW 
            ViewData["ACCESSRIGHT"] = accessRight;

            // Return This View
            return View();


        }// End Method 






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