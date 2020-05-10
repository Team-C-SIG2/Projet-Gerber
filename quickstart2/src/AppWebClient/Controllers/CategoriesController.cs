namespace AppWebClient.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using System.Net.Http;
    using Newtonsoft.Json;

    using AppWebClient.Models;
    using AppWebClient.Tools;


    public class CategoriesController : Controller
    {

        // HTTPCLIENT 
        private readonly HttpClient _client = ApiHttpClient.ConnectClient();

        // URL   
        private string _url = $"api/categories/";



        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // READ: Return the Categories list
        // GET: .../ api/Categories/
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
       
        // ________________________________________________________
        // Entry point of the Controller (View)
        // Return all Categories 
        // ________________________________________________________       
        public async Task<IActionResult> Index()
        {

            // TODO - TRY CATCH 
            /*
            List<Categorie> categories = new List<Categorie>();
            
            HttpResponseMessage response = await _client.GetAsync(_url);

            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                categories = JsonConvert.DeserializeObject<List<Categorie>>(result);
            }
            else
            {
                // View ERROR
                return NotFound();
            }

            return View(categories);
            */
            return View();
        }

        // ________________________________________________________
        // Return a Categorie by its Id 
        // GET: .../ api/Categories/S
        // ________________________________________________________  

        public async Task<Categorie> ReadOne(int? id)
        {
            Categorie categorie = null;
            HttpResponseMessage response = await _client.GetAsync(_url + id);

            if (response.IsSuccessStatusCode)
            {
                categorie = await response.Content.ReadAsAsync<Categorie>();
            }
            return categorie;
        }


        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Get the Details of a resource Categorie (by id)
        // GET : Categories/Details/5
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<IActionResult> Details(int? id)
        {
            string uri = _url + id;

            Categorie categorie = new Categorie();

            HttpResponseMessage response = await _client.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                categorie = JsonConvert.DeserializeObject<Categorie>(result);
            }
            else
            {
                // View ERROR
                return View();
            }

            return View(categorie);

        }// END 



        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // To Create a new Categorie 
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////

        // ________________________________________________________
        // Display the "Create" View of CategoriesController 
        // GET: Categories/Create
        // ________________________________________________________
        public async Task<IActionResult> Create(Categorie categorie)
        {
            return View("Create");
        }

        // ________________________________________________________
        // Post (send) the new Ressource Categorie to the API Server 
        // POST: Categories/Create
        // ________________________________________________________
        public async Task<IActionResult> PostCategorie(Categorie categorie)
        {
            HttpResponseMessage response = await _client.PostAsJsonAsync("api/categories", categorie);
            response.EnsureSuccessStatusCode();
            return RedirectToAction("Index", "Categories");
        }



        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // UPDATE : Update a Categorie 
        // PUT (HTTP VERB) : api/Categories/
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////


        // ________________________________________________________
        // READ: Edit Categorie for UPDATE
        // GET: api/Categories/Edit/5
        // ________________________________________________________

        public async Task<IActionResult> Edit(int? id)
        {
            string uri = _url + id; 
            Categorie categorie = new Categorie();

            HttpResponseMessage response = await _client.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                categorie = JsonConvert.DeserializeObject<Categorie>(result);
            }
            else
            {
                // View ERROR
                return View();
            }

            return View(categorie);
        }


        // ________________________________________________________
        // UPDATE : Update a categorie ->  <form asp-action="PutCategorie">
        // PUT: / api/Categories/
        // ________________________________________________________
        public async Task<IActionResult> PutCategorie(int id, Categorie categorie)
        {
            string uri = _url + id;
            HttpResponseMessage response = await _client.PutAsJsonAsync(uri, categorie);
            response.EnsureSuccessStatusCode();

            return RedirectToAction("Index", "Categories");
        }



        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Delete a Categorie
        // DELETE: Categories/Delete/5
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////

       
            // GET: Movies/Delete/5
            public async Task<IActionResult> Delete(int? id)
            {

                if (id == null)
                {
                    return NotFound();
                }

                // HTTP DELETE
                string uri = _url + id;

                 HttpResponseMessage response = await _client.DeleteAsync(uri);
                 response.EnsureSuccessStatusCode(); 

                 // return RedirectToAction(nameof(Index));
                return RedirectToAction("Index", "Categories");
            }



        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Verify if a categorie existe 
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////

        private bool CategorieExists(int id)
        {
            bool exist = false;
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
