


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
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;
    using System.Text;
    public class LineItemsController : Controller
    {
        // HTTPCLIENT 
        private HttpClient client = new HttpClient();

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
            string accessToken = await HttpContext.GetTokenAsync("access_token");

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            string content = await client.GetStringAsync(_configuration["URLApi"] + "api/LineItems/Items/" + id);

            // ___________________________________________________
            // To get LineItems list 
            // ___________________________________________________

            IEnumerable<LineItem> lineItems;


            if (content != null)
            {
                lineItems = JsonConvert.DeserializeObject<IEnumerable<LineItem>>(content);
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

            string uriPkey = _configuration["URLApi"] + "api/StripePay/PKey/";
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
            string accessToken = await HttpContext.GetTokenAsync("access_token");

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            LineItem lineItem = null;
            HttpResponseMessage response = await client.GetAsync(_configuration["URLApi"] + "api/LineItems/LineItem/" + id);

            if (response.IsSuccessStatusCode)
            {
                lineItem = await response.Content.ReadAsAsync<LineItem>();
            }
            return lineItem;
        }

        public async Task<IActionResult> Delete(int? id)
        {
            string accessToken = await HttpContext.GetTokenAsync("access_token");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            string content = await client.GetStringAsync(_configuration["URLApi"] + "api/LineItems/LineItem/" + id);

            LineItem line = JsonConvert.DeserializeObject<LineItem>(content);

            if (line == null)
            {
                return NotFound();
            }

            return View(line);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            string accessToken = await HttpContext.GetTokenAsync("access_token");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            string content = await client.GetStringAsync(_configuration["URLApi"] + "api/LineItems/LineItem/" + id);
            LineItem line = JsonConvert.DeserializeObject<LineItem>(content);
            var tempId = line.IdShoppingcart;
            HttpResponseMessage response;

            if (line.IdWishlist == null)
            {
                response = await client.DeleteAsync(_configuration["URLApi"] + "api/LineItems/" + id);
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    return BadRequest();
                }
            }
            else
            {
                line.IdShoppingcart = null;
                line.InsertedDate = DateTime.Now;
                string jsonString = System.Text.Json.JsonSerializer.Serialize<LineItem>(line);
                StringContent httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");
                response = await client.PutAsync(_configuration["URLApi"] + "api/LineItems/" + line.Id, httpContent);

                if (response.StatusCode != HttpStatusCode.NoContent)
                {
                    return BadRequest();
                }
            }

            line.IdShoppingcart = tempId;
            return RedirectToAction("Index", "LineItems", new { id = line.IdShoppingcart });
        }

    }// End Class 
}
