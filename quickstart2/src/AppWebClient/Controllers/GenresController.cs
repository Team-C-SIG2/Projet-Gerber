using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AppWebClient.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace AppWebClient.Controllers
{
    public class GenresController : Controller
    {
        private readonly HttpClient _client;

        // URL   
        private string _url = $"api/genres/";

        private IConfiguration _configuration;

        public GenresController(IConfiguration configuration)
        {
            _configuration = configuration;
            _client = new HttpClient();
        }


        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // READ: Return the Genres list
        // GET: .../ api/Genres/
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////

        // ________________________________________________________
        // Entry point of the Controller (View)
        // Return all Genres 
        // ________________________________________________________       
        public async Task<IActionResult> Index()
        {
            List<Genre> genres = new List<Genre>();

            string accessToken = await HttpContext.GetTokenAsync("access_token");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            HttpResponseMessage response = await _client.GetAsync(_configuration["URLApi"] + _url);

            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                genres = JsonConvert.DeserializeObject<List<Genre>>(result);
            }
            else
            {
                return NotFound();
            }

            return View(genres);
        }

        // ________________________________________________________
        // Return a Genre by its Id 
        // GET: .../ api/Genres/S
        // ________________________________________________________  

        public async Task<Genre> ReadOne(int? id)
        {
            Genre genre = null;
            string accessToken = await HttpContext.GetTokenAsync("access_token");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            HttpResponseMessage response = await _client.GetAsync(_configuration["URLApi"] + _url + id);

            if (response.IsSuccessStatusCode)
            {
                genre = await response.Content.ReadAsAsync<Genre>();
            }
            return genre;
        }


        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Get the Details of a resource genre (by id)
        // GET : genres/Details/5
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<IActionResult> Details(int? id)
        {
            string uri = _configuration["URLApi"] + _url + id;

            Genre genre = new Genre();
            string accessToken = await HttpContext.GetTokenAsync("access_token");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            HttpResponseMessage response = await _client.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                genre = JsonConvert.DeserializeObject<Genre>(result);
            }
            else
            {
                // View ERROR
                return View();
            }

            return View(genre);

        }// END 



        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // To Create a new genre 
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////

        // ________________________________________________________
        // Display the "Create" View of genresController 
        // GET: genres/Create
        // ________________________________________________________
        public IActionResult Create(Genre genre)
        {
            return View("Create");
        }

        // ________________________________________________________
        // Post (send) the new Ressource Genre to the API Server 
        // POST: Genres/Create
        // ________________________________________________________
        public async Task<IActionResult> PostGenre(Genre genre)
        {

            string accessToken = await HttpContext.GetTokenAsync("access_token");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            HttpResponseMessage response = await _client.PostAsJsonAsync(_configuration["URLApi"] +"api/genres", genre);
            response.EnsureSuccessStatusCode();
            return RedirectToAction("Index", "Genres");
        }



        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // UPDATE : Update a Genre 
        // PUT (HTTP VERB) : api/Genres/
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////


        // ________________________________________________________
        // READ: Edit Genre for UPDATE
        // GET: api/Genres/Edit/5
        // ________________________________________________________

        public async Task<IActionResult> Edit(int? id)
        {
            string uri = _configuration["URLApi"] + _url + id;
            Genre genre = new Genre();

            string accessToken = await HttpContext.GetTokenAsync("access_token");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            HttpResponseMessage response = await _client.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                genre = JsonConvert.DeserializeObject<Genre>(result);
            }
            else
            {
                // View ERROR
                return View();
            }

            return View(genre);
        }


        // ________________________________________________________
        // UPDATE : Update a genre ->  <form asp-action="PutGenre">
        // PUT: / api/Genres/
        // ________________________________________________________
        public async Task<IActionResult> PutGenre(int id, Genre genre)
        {
            string uri = _configuration["URLApi"] + _url + id;

            string accessToken = await HttpContext.GetTokenAsync("access_token");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            HttpResponseMessage response = await _client.PutAsJsonAsync(uri, genre);
            response.EnsureSuccessStatusCode();

            return RedirectToAction("Index", "Genres");
        }



        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Delete a Genre
        // DELETE: Genres/Delete/5
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////


        // GET: Movies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {

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
            return RedirectToAction("Index", "Genres");
        }



        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Verify if a genre existe 
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////

        private async Task<bool> GenreExistsAsync(int id)
        {
            bool exist = false;
            string accessToken = await HttpContext.GetTokenAsync("access_token");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            HttpResponseMessage response = await _client.GetAsync(_configuration["URLApi"] + _url);
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                var genres = JsonConvert.DeserializeObject<List<Genre>>(result);
                foreach (var genre in genres) {
                    if (genre.Id == id) {
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