using AppWebClient.Models;
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
    public class AuthorsController : Controller
    {

        // HTTPCLIENT 
        private readonly HttpClient _client;

        // URL   
        private string _url = $"api/authors/";

        private IConfiguration _configuration;

        public AuthorsController(IConfiguration configuration) {
            _configuration = configuration;
            _client = new HttpClient();
        }


        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // READ: Return the Authors list
        // GET: .../ api/Authors/
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////

        // ________________________________________________________
        // Entry point of the Controller (View)
        // Return all Authors 
        // ________________________________________________________       
        public async Task<IActionResult> Index()
        {
            List<Author> authors = new List<Author>();

            string accessToken = await HttpContext.GetTokenAsync("access_token");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            HttpResponseMessage response = await _client.GetAsync(_configuration["URLApi"]+_url);

            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                authors = JsonConvert.DeserializeObject<List<Author>>(result);
            }
            else
            {
                return NotFound();
            }

            return View(authors);
        }

        // ________________________________________________________
        // Return a Author by its Id 
        // GET: .../ api/Authors/S
        // ________________________________________________________  

        public async Task<Author> ReadOne(int? id)
        {
            Author author = null;
            HttpResponseMessage response = await _client.GetAsync(_url + id);

            if (response.IsSuccessStatusCode)
            {
                author = await response.Content.ReadAsAsync<Author>();
            }
            return author;
        }


        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Get the Details of a resource Author (by id)
        // GET : Authors/Details/5
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<IActionResult> Details(int? id)
        {
            Author author = new Author();
            string uri = _configuration["URLApi"] + _url + id;
            string accessToken = await HttpContext.GetTokenAsync("access_token");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            HttpResponseMessage response = await _client.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                author = JsonConvert.DeserializeObject<Author>(result);
            }
            else
            {
                // View ERROR
                return View();
            }

            return View(author);

        }// END 



        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // To Create a new Author 
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////

        // ________________________________________________________
        // Display the "Create" View of AuthorsController 
        // GET: Authors/Create
        // ________________________________________________________
        public IActionResult Create(Author author)
        {
            return View("Create");
        }

        // ________________________________________________________
        // Post (send) the new Ressource Author to the API Server 
        // POST: Authors/Create
        // ________________________________________________________
        public async Task<IActionResult> PostAuthor(Author author)
        {
            string accessToken = await HttpContext.GetTokenAsync("access_token");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            HttpResponseMessage response = await _client.PostAsJsonAsync(_configuration["URLApi"] + "api/authors", author);
            response.EnsureSuccessStatusCode();
            return RedirectToAction("Index", "Authors");
        }



        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // UPDATE : Update a Author 
        // PUT (HTTP VERB) : api/Authors/
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////


        // ________________________________________________________
        // READ: Edit Author for UPDATE
        // GET: api/Authors/Edit/5
        // ________________________________________________________

        public async Task<IActionResult> Edit(int? id)
        {
            Author author = new Author();
            string uri = _configuration["URLApi"] + _url + id;
            Genre genre = new Genre();

            string accessToken = await HttpContext.GetTokenAsync("access_token");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            HttpResponseMessage response = await _client.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                author = JsonConvert.DeserializeObject<Author>(result);
            }
            else
            {
                // View ERROR
                return View();
            }

            return View(author);
        }


        // ________________________________________________________
        // UPDATE : Update a author ->  <form asp-action="PutAuthor">
        // PUT: / api/Authors/
        // ________________________________________________________
        public async Task<IActionResult> PutAuthor(int id, Author author)
        {
            string uri = _configuration["URLApi"] + _url + id;

            string accessToken = await HttpContext.GetTokenAsync("access_token");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            HttpResponseMessage response = await _client.PutAsJsonAsync(uri, author);
            response.EnsureSuccessStatusCode();

            return RedirectToAction("Index", "Authors");
        }



        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Delete a Author
        // DELETE: Authors/Delete/5
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
            return RedirectToAction("Index", "Authors");
        }



        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Verify if a author existe 
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////

        private async Task<bool> AuthorExistsAsync(int id)
        {
            bool exist = false;
            string accessToken = await HttpContext.GetTokenAsync("access_token");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            HttpResponseMessage response = await _client.GetAsync(_configuration["URLApi"] + _url);
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                var genres = JsonConvert.DeserializeObject<List<Author>>(result);
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
