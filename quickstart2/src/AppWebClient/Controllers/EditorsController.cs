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
    public class EditorsController : Controller
    {
        private readonly HttpClient _client;
        private string _url = $"api/editors/";
        private IConfiguration _configuration;

        public EditorsController(IConfiguration configuration)
        {
            _configuration = configuration;
            _client = new HttpClient();
        }

        // ________________________________________________________
        // Entry point of the Controller (View)
        // Return all Editors 
        // ________________________________________________________       
        public async Task<IActionResult> Index()
        {
            List<Editor> editors = new List<Editor>();

            string accessToken = await HttpContext.GetTokenAsync("access_token");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            HttpResponseMessage response = await _client.GetAsync(_configuration["URLApi"] + _url);

            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                editors = JsonConvert.DeserializeObject<List<Editor>>(result);
            }
            else
            {
                return NotFound();
            }

            return View(editors);
        }

        // ________________________________________________________
        // Return a Editor by its Id 
        // GET: .../ api/Editors/S
        // ________________________________________________________  

        public async Task<Editor> ReadOne(int? id)
        {
            Editor editor = null;
            HttpResponseMessage response = await _client.GetAsync(_url + id);

            if (response.IsSuccessStatusCode)
            {
                editor = await response.Content.ReadAsAsync<Editor>();
            }
            return editor;
        }


        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Get the Details of a resource Editor (by id)
        // GET : Editors/Details/5
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<IActionResult> Details(int? id)
        {
            Editor editor = new Editor();
            string uri = _configuration["URLApi"] + _url + id;
            string accessToken = await HttpContext.GetTokenAsync("access_token");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            HttpResponseMessage response = await _client.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                editor = JsonConvert.DeserializeObject<Editor>(result);
            }
            else
            {
                return View();
            }

            return View(editor);

        }// END 

        // ________________________________________________________
        // Display the "Create" View of EditorsController 
        // GET: Editors/Create
        // ________________________________________________________
        public IActionResult Create(Editor editor)
        {
            return View("Create");
        }

        // ________________________________________________________
        // Post (send) the new Ressource Editor to the API Server 
        // POST: Editors/Create
        // ________________________________________________________
        public async Task<IActionResult> PostEditor(Editor editor)
        {
            string accessToken = await HttpContext.GetTokenAsync("access_token");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            HttpResponseMessage response = await _client.PostAsJsonAsync(_configuration["URLApi"] + "api/editors", editor);
            response.EnsureSuccessStatusCode();
            return RedirectToAction("Index", "Editors");
        }


        // ________________________________________________________
        // READ: Edit Editor for UPDATE
        // GET: api/Editors/Edit/5
        // ________________________________________________________

        public async Task<IActionResult> Edit(int? id)
        {
            Editor editor = new Editor();
            string uri = _configuration["URLApi"] + _url + id;
            Genre genre = new Genre();

            string accessToken = await HttpContext.GetTokenAsync("access_token");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            HttpResponseMessage response = await _client.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                editor = JsonConvert.DeserializeObject<Editor>(result);
            }
            else
            {
                return View();
            }

            return View(editor);
        }


        // ________________________________________________________
        // UPDATE : Update a editor ->  <form asp-action="PutEditor">
        // PUT: / api/Editors/
        // ________________________________________________________
        public async Task<IActionResult> PutEditor(int id, Editor editor)
        {
            string uri = _configuration["URLApi"] + _url + id;

            string accessToken = await HttpContext.GetTokenAsync("access_token");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            HttpResponseMessage response = await _client.PutAsJsonAsync(uri, editor);
            response.EnsureSuccessStatusCode();

            return RedirectToAction("Index", "Editors");
        }



        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Delete a Editor
        // DELETE: Editors/Delete/5
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
            return RedirectToAction("Index", "Editors");
        }



        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Verify if a editor existe 
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////

        private async Task<bool> EditorExistsAsync(int id)
        {
            bool exist = false;
            string accessToken = await HttpContext.GetTokenAsync("access_token");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            HttpResponseMessage response = await _client.GetAsync(_configuration["URLApi"] + _url);
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                var genres = JsonConvert.DeserializeObject<List<Editor>>(result);
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
    }
}