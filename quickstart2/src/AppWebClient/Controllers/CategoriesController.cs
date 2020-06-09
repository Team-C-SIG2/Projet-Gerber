using AppWebClient.Models;
using AppWebClient.Tools;
using AppWebClient.ViewModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace AppWebClient.Controllers
{
    public class CategoriesController : Controller
    {

        // HTTPCLIENT 
        private readonly HttpClient _client;

        // URL   
        private string _url = $"api/categories/";

        private IConfiguration _configuration;

        public CategoriesController(IConfiguration configuration) {
            _configuration = configuration;
            _client = new HttpClient();
        }


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
            List<Categorie> categories = new List<Categorie>();

            string accessToken = await HttpContext.GetTokenAsync("access_token");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            HttpResponseMessage response = await _client.GetAsync(_configuration["URLApi"]+_url);

            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                categories = JsonConvert.DeserializeObject<List<Categorie>>(result);
            }
            else
            {
                return NotFound();
            }

            return View(categories);
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
            Categorie categorie = new Categorie();
            string uri = _configuration["URLApi"] + _url + id;
            string accessToken = await HttpContext.GetTokenAsync("access_token");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
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
        public IActionResult Create(Categorie categorie)
        {
            return View("Create");
        }

        // ________________________________________________________
        // Post (send) the new Ressource Categorie to the API Server 
        // POST: Categories/Create
        // ________________________________________________________
        public async Task<IActionResult> PostCategorie(Categorie categorie)
        {
            string accessToken = await HttpContext.GetTokenAsync("access_token");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            HttpResponseMessage response = await _client.PostAsJsonAsync(_configuration["URLApi"] + "api/categories", categorie);
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
            Categorie categorie = new Categorie();
            string uri = _configuration["URLApi"] + _url + id;
            Genre genre = new Genre();

            string accessToken = await HttpContext.GetTokenAsync("access_token");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
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
            string uri = _configuration["URLApi"] + _url + id;

            string accessToken = await HttpContext.GetTokenAsync("access_token");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
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

            ErrorViewModel e = new ErrorViewModel
            {
                RequestId = ""
            };

            if (id == null)
            {
                return NotFound();
            }

            // HTTP DELETE
            string uri = _configuration["URLApi"] + _url + id;

            string accessToken = await HttpContext.GetTokenAsync("access_token");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            HttpResponseMessage response = await _client.DeleteAsync(uri);
            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                e.RequestId = "Suppression impossible car l'objet est utilisé par une autre entité";
                return View("Error", e);
            }
            else if (!response.IsSuccessStatusCode)
            {
                e.RequestId = response.ReasonPhrase;
                return View("Error", e);
            }

            // return RedirectToAction(nameof(Index));
            return RedirectToAction("Index", "Categories");
        }



        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Verify if a categorie existe 
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////

        private async Task<bool> CategorieExistsAsync(int id)
        {
            bool exist = false;
            string accessToken = await HttpContext.GetTokenAsync("access_token");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            HttpResponseMessage response = await _client.GetAsync(_configuration["URLApi"] + _url);
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                var genres = JsonConvert.DeserializeObject<List<Categorie>>(result);
                foreach (var genre in genres)
                {
                    if (genre.Id == id)
                    {
                        exist = true;
                    }
                }
            }
            else
            {
                return false;
            }

            return exist;
        }



    }// End class
}
