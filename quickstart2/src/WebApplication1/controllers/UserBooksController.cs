

namespace WebApplication1.Controllers
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;
    using WebApplication1.Models;
    using System.Net.Http;
    using Newtonsoft.Json;

    using WebApplication1.Tools;


    public class UserBooksController : Controller
    {

        // Var USERID 
        private readonly string UserID = "002078C2AB";

        // HTTPCLIENT 
        private HttpClient _client = ApiHttpClient.ConnectClient();

        // URL 
        private string _url = $"api/books/";


        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // READ: Return the User ShoppingCart
        // GET: .../api/ShoppingCarts/5
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////

        // ________________________________________________________
        // Entry point of the Controller (View)
        // Return Books list 
        // ________________________________________________________  

        // GET: Books
        public async Task<IActionResult> Index()
        {
            // TODO - TRY CATCH 

            List<Book> books = new List<Book>();

            HttpResponseMessage response = await _client.GetAsync(_url);

            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                books = JsonConvert.DeserializeObject<List<Book>>(result);
            }
            else
            {
                // View ERROR
                return NotFound();
            }

            return View(books);

        }


        // ________________________________________________________
        // Return a Book by its Id 
        // GET: .../ api/Books/S
        // ________________________________________________________  

        public async Task<Book> ReadRessource(int? id)
        {
            Book book = null;
            HttpResponseMessage response = await _client.GetAsync(_url + id);

            if (response.IsSuccessStatusCode)
            {
                book = await response.Content.ReadAsAsync<Book>();
            }
            return book;
        }


        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Get the Details of a resource Book (by id)
        // GET : Books/Details/5
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<IActionResult> Details(int? id)
        {
            string uri = _url + id;

            Book book = new Book();

            HttpResponseMessage response = await _client.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                book = JsonConvert.DeserializeObject<Book>(result);
            }
            else
            {
                // View ERROR
                return View();
            }

            return View(book);

        }// END 


        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // To Create a new Book 
        // POST: Books/Create
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////


        // ________________________________________________________
        // Display the "Create" View of Books Controller 
        // GET: Books/Create
        // ________________________________________________________
        public async Task<IActionResult> Create(Book book)
        {
            return View("Create");
        }

        // ________________________________________________________
        // Post (send) the new Ressource Book to the API Server 
        // POST: Books/Create
        // ________________________________________________________
        public async Task<IActionResult> PostRessource(Book book)
        {

            HttpResponseMessage response = await _client.PostAsJsonAsync("api/Books", book);
            response.EnsureSuccessStatusCode();


            return RedirectToAction("Index", "UserBooks");

        }



        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // UPDATE : Update a Book 
        // PUT (HTTP VERB) : api/Books/
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////

        // ________________________________________________________
        // READ: Edit Book for UPDATE
        // GET: api/Books/Edit/5
        // ________________________________________________________

        public async Task<IActionResult> Edit(int? id)
        {
            string uri = _url + id;
            Book book = new Book();

            HttpResponseMessage response = await _client.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                book = JsonConvert.DeserializeObject<Book>(result);
            }
            else
            {
                // View ERROR
                return View();
            }

            string editor = book.IdEditorNavigation.Name;
            ViewBag.EDITOR = editor;

            return View(book);
        }



        // ________________________________________________________
        // UPDATE : Update a Books ->  <form asp-action="PutRessource">
        // PUT: / api/Books/
        // ________________________________________________________
        public async Task<IActionResult> PutRessource(int id, Book book)
        {
            string uri = _url + id;

            Book b = new Book
            {
                Id = book.Id,
                IdEditor = book.IdEditor,
                Title = book.Title,
                Subtitle = book.Subtitle,
                Price = book.Price,
                DatePublication = book.DatePublication,
                Summary = book.Summary,
                Isbn = book.Isbn
            };

            HttpResponseMessage response = await _client.PutAsJsonAsync(uri, b);
            response.EnsureSuccessStatusCode();


            return RedirectToAction("Index", "UserBooks");
        }

        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Delete a Book
        // DELETE: Books/Delete/5
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////


        public async Task<IActionResult> Delete(int id)
        {
            // HTTP DELETE
            string uri = _url + id;


            HttpResponseMessage response = await _client.DeleteAsync(uri);

            response.EnsureSuccessStatusCode();

            // return RedirectToAction(nameof(Index));
            return RedirectToAction("Index", "UserBooks");
        }



        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Verify if a categorie existe 
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////

        private bool BookExists(int id)
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


    }// End Class 
}
