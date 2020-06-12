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
    public class PaymentsController : Controller
    {
        private readonly IConfiguration _configuration;
        HttpClient client = new HttpClient();
        private string _url;

        public PaymentsController(IConfiguration configuration)
        {
            _configuration = configuration;
            _url = _configuration["URLApi"] + "api/Payments/";
        }

        public async Task<IActionResult> Index(int? id)
        {
            string accessToken = await HttpContext.GetTokenAsync("access_token");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            string content = await client.GetStringAsync(_url + "DetailsPaiement/" + id);

            /*
            string userId = await client.GetStringAsync(_configuration["URLApi"] + "api/AspNetUsers/UserId/");
            string uriOrder = _configuration["URLApi"] + "api/Orders/Commandes/" + userId;
            IEnumerable<Order> orders;
            string contentOrders = await client.GetStringAsync(uriOrder);
            if (contentOrders != "[]")
            {
                orders = JsonConvert.DeserializeObject<IEnumerable<Order>>(contentOrders);
                // Récupérer l'ID de la commande séléctionnée par le user
            }

            string content = await client.GetStringAsync(_url + "DetailsPaiement/" + id);
            */


            Payment payment = JsonConvert.DeserializeObject<Payment>(content);

            if (payment == null)
            {
                return NotFound();
            }

            return View(payment);
        }
    }
}