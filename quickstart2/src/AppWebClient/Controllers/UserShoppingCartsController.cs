namespace AppWebClient.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using AppWebClient.Models;
    using AppWebClient.Tools;
    using System.Net.Http;
    using Newtonsoft.Json;

    using System.Text.Json;
    using System.Security.Claims;
    using Microsoft.Extensions.Configuration;
    using Microsoft.AspNetCore.Authentication;
    using System.Net.Http.Headers;

    public class UserShoppingCartsController : Controller
    {

        // Var USERID 
        private readonly string UserID = "002078C2AB";

        // HTTPCLIENT 
        private HttpClient _client = ApiHttpClient.ConnectClient();

        // URL 
        private string _url;


        private readonly IConfiguration _configuration;

        public UserShoppingCartsController(IConfiguration configuration)
        {
            _configuration = configuration;
            _url = _configuration["URLApi"] + "api/ShoppingCarts/";
        }


        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // READ: Return the User ShoppingCart
        // GET: .../api/ShoppingCarts/5
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////

        // GET: ShoppingCarts
        public async Task<IActionResult> Index()
        {
            

            // To obtain the shopping cart of User (id) 
            string accessToken = await HttpContext.GetTokenAsync("access_token");

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            string uri2 = _configuration["URLApi"] + "api/AspNetUsers/UserId/";
            string id = await client.GetStringAsync(uri2);
            ViewBag.USERID = id;
            string uri = _url + id;
            ShoppingCart shoppingCart;
            HttpResponseMessage response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                shoppingCart = JsonConvert.DeserializeObject<ShoppingCart>(result);
                @ViewBag.USERID = id; 

            }
            else
            {                
                return View();// To do - Go To View ERROR
            }


            // To obtain the data of User (id)

            
            List<AspNetUser> users;
            AspNetUser aspUser; 
            string uriUsers = _url + "User/" + id; 
            HttpResponseMessage responseUsers = await client.GetAsync(uriUsers); // HTTP GET
            if (responseUsers.IsSuccessStatusCode)
            {
                users = await responseUsers.Content.ReadAsAsync<List<AspNetUser>>();

                foreach (var user in users)
                {
                    if (user.Id == id)
                    {
                        aspUser = user; 

                        ViewData["USER"] = aspUser; // Save to ViewData

                    }
                }

            }


            return View(shoppingCart);
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
            ViewBag.USERID = UserID;

            string uri = _url + id;
            HttpResponseMessage response = await _client.PutAsJsonAsync(uri, shoppingCart);
            response.EnsureSuccessStatusCode();

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
            ViewBag.USERID = UserID;

            List<AspNetUser> users;
            string uri = _url + "Users";

            HttpResponseMessage responseUsers = await _client.GetAsync(uri); // HTTP GET
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
            ViewBag.USER = UserID;

            HttpResponseMessage response = await _client.PostAsJsonAsync("api/ShoppingCarts", shoppingCart);
            response.EnsureSuccessStatusCode();
            return RedirectToAction("Index", "ShoppingCarts");
        }


        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Delete a ShoppingCarts
        // DELETE: ShoppingCarts/Delete/5
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////


        public async Task<IActionResult> Delete(int? id)
        {
            ViewBag.USERID = UserID;

            // HTTP DELETE
            string uri = _url + id;
            HttpResponseMessage response = await _client.DeleteAsync(uri);
            response.EnsureSuccessStatusCode();

            // return RedirectToAction(nameof(Index));
            return RedirectToAction("Index", "ShoppingCarts");
        }


        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Verify if a ShoppingCarts existe 
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////

        private bool ShoppingCartExists(int id)
        {
            bool exist;
            if (id > 0)
            {
                exist = true;
            }
            else
            {
                exist = false;
            }

            return exist;
        }





    }// End Class 
}
