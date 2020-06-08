using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AppWebClient.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

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

            // Changer l'API Orders comme dans l'API LineItems !

            Order order;
            HttpResponseMessage response = await client.GetAsync(uriOrder);
            if (response.IsSuccessStatusCode && response.ReasonPhrase != "No Content")
            {
                string result = response.Content.ReadAsStringAsync().Result;
                order = JsonConvert.DeserializeObject<Order>(result);
                string content = await client.GetStringAsync(_configuration["URLApi"] + "api/LineItems/Wishlist/" + order.Id);
                if (content != null)
                {
                    lineItems = JsonConvert.DeserializeObject<IEnumerable<LineItem>>(content);
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                return View("Empty");
            }

            return View();
        }
    }
}