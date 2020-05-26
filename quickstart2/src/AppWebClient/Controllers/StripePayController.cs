
namespace AppWebClient.Controllers
{

    using AppWebClient.Tools;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Newtonsoft.Json;
    using Stripe;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Net.Http.Headers;
    using Microsoft.AspNetCore.Authentication;
    using AppWebClient.Models;
    using System.Net;

    public class StripePayController : Controller
    {

        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // CONSTRUCTOR
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////

        private readonly IConfiguration _configuration;

        public StripePayController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // CLASS ATTRIBUTS 
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////

        // HTTPCLIENT 
        private HttpClient _client = ApiHttpClient.ConnectClient();

        // URL 
        private string _url = $"api/StripePay/";

        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // HELP STRIPE ONLINE PAYMENT
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        public IActionResult About()
        {
            return View();
        }



        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // HELP STRIPE ONLINE PAYMENT
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<IActionResult> Charge(string stripeEmail, string StripeToken, decimal amount)
        {
            // ___________________________________________________
            // To get public key 
            // Set your secret key. Remember to switch to your live secret key in production!
            // ___________________________________________________
            string uriPkey = _configuration["URLApi"] + "api/stripePay/PKey/" ;
            string pKey = null; 
            List<string> stripePKeys;
            string accessToken = await HttpContext.GetTokenAsync("access_token");
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            string idUser = await client.GetStringAsync(_configuration["URLApi"] + "api/AspNetUsers/UserId/");

            string content = await client.GetStringAsync(uriPkey);
            if (content != null)
            {
                stripePKeys = JsonConvert.DeserializeObject<List<string>>(content);
            }
            else
            {
                // View ERROR
                return NotFound();
            }

            // LineItems total amount 
            foreach (var item in stripePKeys)
            {
                if (item != null)
                {
                    pKey = item;
                }
            }

            string publickey = pKey;
            ViewBag.PUBLICKEY = publickey;

            // ___________________________________________________
            // To get ApiKey
            // ___________________________________________________

            string uriApiKey = _configuration["URLApi"] + "api/stripePay/ApiKey";
            string apiKey = null;
            List<string> stripeApiKeys;

            string contentApikey = await client.GetStringAsync(uriApiKey);
            if (contentApikey != null)
            {
                stripeApiKeys = JsonConvert.DeserializeObject<List<string>>(contentApikey);
            }
            else
            {
                // View ERROR
                return NotFound();
            }

            // LineItems total amount 
            foreach (var item in stripeApiKeys)
            {
                if (item != null)
                {
                    apiKey = item;
                }
            }

            string returnedApiKey = apiKey;
            ViewBag.APIKEY = returnedApiKey;
            StripeConfiguration.ApiKey = returnedApiKey;


            // ___________________________________________________
            // Calculate the total amount of charge 
            // ___________________________________________________

            // Tdodo  Récupérer dans lineItems
            long chargeAmount = Convert.ToInt64(amount);
            decimal montant = amount / 100;
            ViewBag.MONTANT = montant;



            // ___________________________________________________
            // Create Stripe Environnement
            // ___________________________________________________

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

            // ___________________________________________________
            // Verify the payment 
            // ___________________________________________________

            if (charge.Status == "succeeded")
            {
                // string BalanceTransactionId = charge.BalanceTransaction.Id; 

                Payment payment = new Payment
                {
                    UserId = idUser,
                    PaidDate = DateTime.Now,
                    PriceTotal = montant,
                    Details = publickey
                };
                HttpResponseMessage response = await client.PostAsJsonAsync(_configuration["URLApi"] + "api/Payments/", payment);

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    return BadRequest();
                }

                return View();
            }
            else
            {
                return View("Error");
            }


        }// End 



    }// End Class 
}