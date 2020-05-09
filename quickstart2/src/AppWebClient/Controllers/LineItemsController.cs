


namespace AppWebClient.Controllers
{

    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;
    using System.Net.Http;
    using Newtonsoft.Json;

    using AppWebClient.Models;
    using AppWebClient.Tools;
    using Microsoft.AspNetCore.Authentication;
    using System.Net.Http.Headers;
    using Microsoft.Extensions.Configuration;

    public class LineItemsController : Controller
    {
        // Var USERID 
        private readonly string UserID = "002078C2AB";

        // HTTPCLIENT 
        private HttpClient _client = ApiHttpClient.ConnectClient();

        // URL   
        private string _url = $"api/LineItems/";

        private readonly IConfiguration _configuration;

        public LineItemsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // READ: Return the LineItems list
        // GET: .../ api/LineItems/
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////


        // GET: LineItems
        public async Task<IActionResult> Index(int? id)
        {
            
            ViewBag.USERID = UserID;

            string accessToken = await HttpContext.GetTokenAsync("access_token");

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            string content = await client.GetStringAsync(_configuration["URLApi"] + "api/LineItems/Items/" + id);

            // ___________________________________________________
            // To get LineItems list 
            // ___________________________________________________
            //string uri = _url + "Items/" + id;

            List<LineItem> lineItems;

            HttpResponseMessage response = await client.GetAsync(content);

            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                lineItems = JsonConvert.DeserializeObject<List<LineItem>>(result);
            }
            else
            {
                // View ERROR
                return NotFound();
            }

            // ___________________________________________________
            // Calculate the total amount of the shoppingcart 
            // ___________________________________________________
            
            decimal total = 0;

            foreach (var item in lineItems)
                {
                    total += (item.UnitPrice * item.Quantity);
                }




            // ___________________________________________________
            // Calculate the total amount of charge 
            // ___________________________________________________

            // Tdodo  Récupérer dans lineItems
            decimal? decimalAmount = total;
            var centsAmount = (decimalAmount * 100);


            ViewBag.MONTANT = centsAmount;
            ViewBag.MONTANTAFFICHE = total.ToString("F");
            
            
            // Récupère le numéro (ID) du panier 
            ViewBag.PANIER = id;




            // ___________________________________________________
            // To get public key 
            // Set your secret key. Remember to switch to your live secret key in production!
            // ___________________________________________________

            //  private string _url = $"api/StripePay/";

            string uriPkey = $"api/StripePay/PKey";
            string pKey = null;
            List<string> stripePKeys;

            HttpResponseMessage responsePKey = await client.GetAsync(uriPkey);
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




            return View(lineItems);

        }




        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // READ: Return a Categorie  
        // GET: .../ api/Categories/
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<LineItem> GetLineItem(int? id)
        {
            ViewBag.USER = UserID;

            string accessToken = await HttpContext.GetTokenAsync("access_token");

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            LineItem lineItem = null;
            HttpResponseMessage response = await _client.GetAsync(_configuration["URLApi"] + "api/LineItems/LineItem/" + id);

            if (response.IsSuccessStatusCode)
            {
                lineItem = await response.Content.ReadAsAsync<LineItem>();
            }
            return lineItem;
        }



    }// End Class 
}
