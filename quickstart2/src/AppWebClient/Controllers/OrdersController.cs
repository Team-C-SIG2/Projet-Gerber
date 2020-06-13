using AppWebClient.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace AppWebClient.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IConfiguration _configuration;
        HttpClient client = new HttpClient();
        private string _url;

        public OrdersController(IConfiguration configuration)
        {
            _configuration = configuration;
            _url = _configuration["URLApi"] + "api/Orders/";
        }

        public async Task<IActionResult> Index()
        {
            string accessToken = await HttpContext.GetTokenAsync("access_token");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            string userId = await client.GetStringAsync(_configuration["URLApi"] + "api/AspNetUsers/UserId/");
            string uriOrder = _url + "Commandes/" + userId;
            IEnumerable<Order> orders;
            string content = await client.GetStringAsync(uriOrder);
            if (content != "[]")
            {
                orders = JsonConvert.DeserializeObject<IEnumerable<Order>>(content);
            }
            else
            {
                return View("Empty");
            }

            return View(orders);
        }
    }
}