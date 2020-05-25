using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using AppWebClient.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace AppWebClient.Controllers
{
    public class WishlistsController : Controller
    {
        private readonly IConfiguration _configuration;
        private string _url;
        HttpClient client = new HttpClient();

        public WishlistsController(IConfiguration configuration)
        {
            _configuration = configuration;
            _url = _configuration["URLApi"] + "api/Wishlists/";
        }

        public async Task<IActionResult> Index()
        {
            string accessToken = await HttpContext.GetTokenAsync("access_token");

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            string uriUserId = _configuration["URLApi"] + "api/AspNetUsers/UserId/";
            string userId = await client.GetStringAsync(uriUserId);
            string uriWishlist = _url + "Wishlist/" + userId;
            Wishlist wishlist;
            IEnumerable<LineItem> lineItems;
            HttpResponseMessage response = await client.GetAsync(uriWishlist);
            if (response.IsSuccessStatusCode && response.ReasonPhrase != "No Content")
            {
                string result = response.Content.ReadAsStringAsync().Result;
                wishlist = JsonConvert.DeserializeObject<Wishlist>(result);
                string content = await client.GetStringAsync(_configuration["URLApi"] + "api/LineItems/Wishlist/" + wishlist.Id);
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

            return View(lineItems);
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
            HttpResponseMessage response;

            if (line.IdShoppingcart == null)
            {
                response = await client.DeleteAsync(_configuration["URLApi"] + "api/LineItems/" + id);
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    return BadRequest();
                }
            }
            else
            {
                line.IdWishlist = null;
                line.InsertedDate = DateTime.Now;
                string jsonString = System.Text.Json.JsonSerializer.Serialize<LineItem>(line);
                StringContent httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");
                response = await client.PutAsync(_configuration["URLApi"] + "api/LineItems/" + line.Id, httpContent);

                if (response.StatusCode != HttpStatusCode.NoContent)
                {
                    return BadRequest();
                }
            }
            
            return RedirectToAction("Index", "Wishlists");
        }
    }
}