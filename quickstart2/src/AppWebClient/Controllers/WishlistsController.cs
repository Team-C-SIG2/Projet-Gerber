using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
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

        public WishlistsController(IConfiguration configuration)
        {
            _configuration = configuration;
            _url = _configuration["URLApi"] + "api/Wishlists/";
        }

        public async Task<IActionResult> Index(int id)
        {
            string accessToken = await HttpContext.GetTokenAsync("access_token");

            HttpClient client = new HttpClient();
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
                ViewBag.USERID = wishlist.Id;
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
    }
}