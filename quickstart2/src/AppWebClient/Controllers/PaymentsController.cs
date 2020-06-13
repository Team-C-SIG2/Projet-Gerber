using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AppWebClient.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Rotativa.AspNetCore;

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

            Payment payment = JsonConvert.DeserializeObject<Payment>(content);

            if (payment == null)
            {
                return NotFound();
            }

            return View(payment);
        }

        public async Task<IActionResult> Getpdf(int? id)
        {
            string accessToken = await HttpContext.GetTokenAsync("access_token");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            string content = await client.GetStringAsync(_url + "DetailsPaiement/" + id);

            Payment payment = JsonConvert.DeserializeObject<Payment>(content);

            if (payment == null)
            {
                return NotFound();
            }

            ViewAsPdf pdf = new ViewAsPdf(payment)
            {
                PageMargins = { Left = 20, Bottom = 20, Right = 20, Top = 20 },
            };
            return pdf;
;
        }
    }
}