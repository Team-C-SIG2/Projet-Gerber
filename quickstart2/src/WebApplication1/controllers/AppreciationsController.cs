

namespace WebApplication1.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using System.Net.Http;
    using Newtonsoft.Json;

    using WebApplication1.Models;
    using WebApplication1.Tools;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Linq;


    public class AppreciationsController : Controller
    {

        // HTTPCLIENT 
        private HttpClient _client = ApiHttpClient.ConnectClient();

        // URL 
        private string _url = $"api/Appreciations/";


        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // READ: Return the Appreciations list
        // GET: .../ api/Categories/
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<IActionResult> Index()
        {
            // TODO - TRY CATCH 

            List<Appreciation> appreciations;

            HttpResponseMessage response = await _client.GetAsync(_url);

            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result; // HTTP GET
                appreciations = JsonConvert.DeserializeObject<List<Appreciation>>(result);
            }
            else
            {
                // View ERROR
                return NotFound();
            }

            return View(appreciations);

        }



        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // READ: Return a Appreciation  
        // GET: .../ api/Appreciations/
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<Appreciation> GetAppreciationSync()
        {
            Appreciation appreciation = null;
            HttpResponseMessage response = await _client.GetAsync(_url); // HTTP GET

            if (response.IsSuccessStatusCode)
            {
                appreciation = await response.Content.ReadAsAsync<Appreciation>();
            }

            ViewData["IdAppreciation"] = appreciation.Id;
            return appreciation;
        }


        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // UPDATE : Update an Appreciation 
        // PUT (HTTP VERB) : api/Appreciations/
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////


        // ________________________________________________________
        // Edit Appreciation for UPDATE
        // GET: api/appreciations/Edit/5
        // ________________________________________________________


        public async Task<IActionResult> Edit(int? id)
        {
            string uri = _url + id;
            Appreciation appreciation;

            HttpResponseMessage response = await _client.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result; // HTTP GET
                appreciation = JsonConvert.DeserializeObject<Appreciation>(result);
            }
            else
            {
                // View ERROR
                return View();
            }

            ViewData["IdAppreciation"] = id;


            return View(appreciation);
        }


        // ________________________________________________________
        // UPDATE : Update an Appreciation ->  <form asp-action="PutAppreciation">
        // PUT: / api/appreciations/
        // ________________________________________________________
        // Update a Appreciation ->  <form asp-action="PutAppreciation">
        public async Task<IActionResult> PutAppreciation(int id, Appreciation appreciation)
        {
            ViewData["IdAppreciation"] = appreciation.Id; 

            string uri = _url + id;
            HttpResponseMessage response = await _client.PutAsJsonAsync(uri, appreciation); // HTTP PUT
            response.EnsureSuccessStatusCode();

            return RedirectToAction("Index", "Appreciations");
        }


        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // To Create a new Appreciation 
        // POST: api/appreciations/Create
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////

        // ________________________________________________________
        // Display the "Create" View of CategoriesController 
        // ________________________________________________________



        public async Task<IActionResult> Create(Appreciation appreciation)
        {
            List<LineItem> lineItems;
            List<Order> orders;

            string uriGetLineItems = _url+ "GetLineItems";
            string uriGetOrders = _url + "GetOrders";


            HttpResponseMessage responseLineItem = await _client.GetAsync(uriGetLineItems); // HTTP GET
            HttpResponseMessage responseorders = await _client.GetAsync(uriGetOrders); 

            if (responseLineItem.IsSuccessStatusCode)
            {
                lineItems = await responseLineItem.Content.ReadAsAsync<List<LineItem>>();     
                ViewData["IdLineItem"] = new SelectList(lineItems, "Id", "Id", appreciation.IdLineItem);// Add To ViewData
            }

            if (responseorders.IsSuccessStatusCode)
            {
                orders = await responseorders.Content.ReadAsAsync<List<Order>>();
                ViewData["IdOrder"] = new SelectList(orders, "Id", "ShippingAddress", appreciation.IdOrder);// Add To ViewData
            }


            ViewData["IdAppreciation"] = appreciation.Id;

            return View("Create");
        }




        // TDDO TODO TODO TODO  TDDO TODO TODO TODO  TDDO TODO TODO TODO  TDDO TODO TODO TODO  TDDO TODO TODO TODO  TDDO TODO TODO TODO 
        // TDDO TODO TODO TODO  TDDO TODO TODO TODO  TDDO TODO TODO TODO  TDDO TODO TODO TODO  TDDO TODO TODO TODO  TDDO TODO TODO TODO 

        // ________________________________________________________
        // Post (Send) the new Ressource Appreciation to the API Server 
        // ________________________________________________________
        public async Task<IActionResult> PostAppreciation(Appreciation appreciation)
        {
            ViewData["IdAppreciation"] = appreciation.Id;

            HttpResponseMessage response = await _client.PostAsJsonAsync("api/appreciations", appreciation); // HTTP POST
            response.EnsureSuccessStatusCode();
            return RedirectToAction("Index", "Appreciations");
        }




        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Get the Details of a resource Appreciation (by id)
        // GET : api/appreciations/Details/5
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////


        // TDDO TODO TODO TODO  TDDO TODO TODO TODO  TDDO TODO TODO TODO  TDDO TODO TODO TODO  TDDO TODO TODO TODO  TDDO TODO TODO TODO 
        // TDDO TODO TODO TODO  TDDO TODO TODO TODO  TDDO TODO TODO TODO  TDDO TODO TODO TODO  TDDO TODO TODO TODO  TDDO TODO TODO TODO 

        public async Task<IActionResult> Details(int? id)
        {
            string uri = _url + id;
           

            Appreciation appreciation;

            HttpResponseMessage response = await _client.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result; // HTTP GET
                appreciation = JsonConvert.DeserializeObject<Appreciation>(result);
            }
            else
            {
                // View ERROR
                return View();
            }
 
            ViewData["IdAppreciation"] = appreciation.Id; 

            return View(appreciation);

        }// END 


        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Get  Delete a Appreciations
        // DELETE: Appreciations/Delete/5
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////


        // TDDO TODO TODO TODO  TDDO TODO TODO TODO  TDDO TODO TODO TODO  TDDO TODO TODO TODO  TDDO TODO TODO TODO  TDDO TODO TODO TODO 
        // TDDO TODO TODO TODO  TDDO TODO TODO TODO  TDDO TODO TODO TODO  TDDO TODO TODO TODO  TDDO TODO TODO TODO  TDDO TODO TODO TODO 

        public async Task<IActionResult> Delete(int? id)
        {

            string uri = _url + id;
            HttpResponseMessage response = await _client.DeleteAsync(uri); // HTTP DELETE
            response.EnsureSuccessStatusCode();

            return RedirectToAction("Index", "Categories");
        }




        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Verify if a Appreciations existe 
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////

        private bool AppreciationExists(int id)
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


    }// End class
}
