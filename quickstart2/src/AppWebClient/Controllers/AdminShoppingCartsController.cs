namespace AppWebClient.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;
    using AppWebClient.Models;
    using AppWebClient.Tools;
    using System.Net.Http;
    using Newtonsoft.Json;
    using System.Net.Http.Headers;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.Win32.SafeHandles;
    using Microsoft.Extensions.Configuration;

    public class AdminShoppingCartsController : Controller
    {


        // HTTPCLIENT 
        private HttpClient _client = ApiHttpClient.ConnectClient();

        // URL 
        
        private IConfiguration _configuration;

        private string _url;

        public AdminShoppingCartsController(IConfiguration configuration) {
            _configuration = configuration;
            _url = _configuration["URLApi"] + "api/ShoppingCarts/";
        }



        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // READ: Return the ShoppingCarts list
        // GET: .../ api/ShoppingCarts/
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////

        // GET: ShoppingCarts
        public async Task<IActionResult> Index()
        {
            // TODO - TRY CATCH 

            List<ShoppingCart> shoppingCarts;

            string uri = _configuration["URLApi"] + "api/ShoppingCarts/";

            var accessToken = await HttpContext.GetTokenAsync("access_token");
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var response = await client.GetStringAsync(uri);

            if (response != null)
            {
                shoppingCarts = JsonConvert.DeserializeObject<List<ShoppingCart>>(response);
            }
            else
            {
                // View ERROR
                return NotFound();
            }

            return View(shoppingCarts);
        }


        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // READ: Return a ShoppingCarts  
        // GET: .../ api/ShoppingCarts/
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<ShoppingCart> GetShoppingCartsSync()
        {
            ShoppingCart shoppingCart = null;
            string uri = _configuration["URLApi"] + "api/ShoppingCarts/";

            var accessToken = await HttpContext.GetTokenAsync("access_token");
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var response = await client.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                shoppingCart = await response.Content.ReadAsAsync<ShoppingCart>();
            }
            return shoppingCart;
        }

        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // UPDATE : Update a Categorie 
        // PUT (HTTP VERB) : api/Categories/
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////


        // ________________________________________________________
        // UPDATE : Update a ShoppingCarts ->  <form asp-action="PutShoppingCarts">
        // PUT: / api/ShoppingCarts/
        // ________________________________________________________
        public async Task<IActionResult> PutShoppingCart(int id, ShoppingCart shoppingCart)
        {
            string uri = _url + id;

            var accessToken = await HttpContext.GetTokenAsync("access_token");
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var response = await client.PutAsJsonAsync(uri, shoppingCart);

            return RedirectToAction("Index", "ShoppingCarts");
        }



        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // To Create a new ShoppingCarts 
        // POST: ShoppingCarts/Create
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////



        // ________________________________________________________
        // Display the "Create" View of ShoppingCarts Controller 
        // ________________________________________________________

        public async Task<IActionResult> Create(ShoppingCart shoppingCart)
        {
            List<AspNetUser> users;
            string uri = _configuration["URLApi"] + "api/AspNetUsers/";

            var accessToken = await HttpContext.GetTokenAsync("access_token");
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            HttpResponseMessage responseUsers = await client.GetAsync(uri); // HTTP GET
            if (responseUsers.IsSuccessStatusCode)
            {
                users = await responseUsers.Content.ReadAsAsync<List<AspNetUser>>();
                ViewData["UserId"] = new SelectList(users, "Id", "Email", shoppingCart.UserId);// Add To ViewData
            }


            return View("Create");
        }



        // ________________________________________________________
        // Post (send) the new Ressource ShoppingCarts to the API Server 
        // ________________________________________________________
        public async Task<IActionResult> PostShoppingCart(ShoppingCart shoppingCart)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            HttpResponseMessage response = await client.PostAsJsonAsync("api/ShoppingCarts", shoppingCart);
            response.EnsureSuccessStatusCode();
            return RedirectToAction("Index", "ShoppingCarts");
        }


        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Delete a ShoppingCarts
        // DELETE: ShoppingCarts/Delete/5
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////


        public async Task<IActionResult> Delete(int? id)
        {
            // HTTP DELETE
            string uri = _url + id;

            var accessToken = await HttpContext.GetTokenAsync("access_token");
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            HttpResponseMessage response = await client.DeleteAsync(uri);
            response.EnsureSuccessStatusCode();

            // return RedirectToAction(nameof(Index));
            return RedirectToAction("Index", "ShoppingCarts");
        }




    }// End Class 
}
