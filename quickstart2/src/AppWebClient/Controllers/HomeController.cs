using AppWebClient.Tools;
using AppWebClient.ViewModel;

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

        // Var USERID 
        private readonly string UserID = "002078C2AB";

        // HTTPCLIENT 
        private HttpClient _client = ApiHttpClient.ConnectClient();

        // URL 
        private string _url = $"api/ShoppingCarts/";

        public IActionResult StripeInfos()
        {
            return View();
        }

        public IActionResult Charge(string stripeEmail, string StripeToken)
        {
            ViewBag.USERID = UserID;

            // Set your secret key. Remember to switch to your live secret key in production!
            StripeConfiguration.ApiKey = "sk_test_6b0nAo59ibXlQbxiOmaDbkgy005fFYaWNc";


            string publickey = _configuration.GetValue<string>("Stripe:PublishableKey");

            ViewBag.PUBLICKEY = publickey;

            // Tdodo  Récupérer dans lineItems
            decimal decimalAmount = 15.00M;
            var centsAmount = (decimalAmount * 100);
            long chargeAmount = Convert.ToInt64(centsAmount);

            var customers = new CustomerService();
            var Charges = new ChargeService();

            var customer = customers.Create(
                new CustomerCreateOptions
                {
                    Email = stripeEmail,
                    Source = StripeToken
                });

            var charge = Charges.Create(
                new ChargeCreateOptions
                {
                    Amount = chargeAmount,

                    Description = "Test Payment",
                    Currency = "chf",
                    Customer = customer.Id,
                    ReceiptEmail = stripeEmail,
                    Metadata = new Dictionary<string, string>()
                    {
                        {"integration_check", "accept_a_payment" },
                        {"OrderId", "111"},
                        {"Postcode", "3100"}
                    }

                });

            if (charge.Status == "succeeded")
            {
                // string BalanceTransactionId = charge.BalanceTransaction.Id;
            }
            else
            {
                return View("Error");
            }

            return View();
        }

        /*
            [Authorize]
             */
        public IActionResult Index()
        {
            /*
            // ENVOYER PAR LE SERVEUR API -> STRING = PublishableKey VALUE

            // string publickey = _configuration.GetValue<string>("Stripe:PublishableKey");
            string publickey = ""; 


            // ENVOYE PAR LE SERVEUR API 
            decimal decimalAmount = 15.00M;
            var centsAmount = (decimalAmount * 100);



            ViewBag.MONTANT = centsAmount;
            ViewBag.MONTANTAFFICHE = decimalAmount;
            ViewBag.PUBLICKEY = publickey;
            */
            return View();
        }

        public IActionResult About()
        {
            ViewBag.USERID = UserID;
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
            ViewBag.USERID = UserID;
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