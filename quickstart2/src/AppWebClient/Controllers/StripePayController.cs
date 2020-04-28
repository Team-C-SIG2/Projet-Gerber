
namespace AppWebClient.Controllers
{

    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Net.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Newtonsoft.Json;
    using Microsoft.Extensions.Options;

    using Stripe;

    using AppWebClient.Models;
    using AppWebClient.Tools;
    using System.Threading.Tasks;

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

        // Var USERID 
        private readonly string UserID = "002078C2AB";

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

        public async Task<IActionResult> Charge(string stripeEmail, string StripeToken, decimal? amount)
        {
            ViewBag.USERID = UserID;


            // ___________________________________________________
            // To get public key 
            // Set your secret key. Remember to switch to your live secret key in production!
            // ___________________________________________________
            string uriPkey = _url + "PKey" ;
            string pKey = null; 
            List<string> stripePKeys = new List<string>();

            HttpResponseMessage responsePKey = await _client.GetAsync(uriPkey);
            if (responsePKey.IsSuccessStatusCode)
            {
                var result = responsePKey.Content.ReadAsStringAsync().Result;
                stripePKeys = JsonConvert.DeserializeObject<List<string>>(result);
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

            string uriApiKey = _url + "ApiKey";
            string apiKey = null;
            List<string> stripeApiKeys = new List<string>();

            HttpResponseMessage responseApiKey = await _client.GetAsync(uriApiKey);
            if (responseApiKey.IsSuccessStatusCode)
            {
                var result = responseApiKey.Content.ReadAsStringAsync().Result;
                stripeApiKeys = JsonConvert.DeserializeObject<List<string>>(result);
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
            decimal? decimalAmount = amount;
            long chargeAmount = Convert.ToInt64(decimalAmount);


            ViewBag.MONTANT = (amount / 100) ;





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
                return View();
            }
            else
            {
                return View("Error");
            }


        }// End 



    }// End Class 
}