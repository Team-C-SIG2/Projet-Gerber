

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


    public class BooksController : Controller
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

            ViewBag.USERID = UserID;

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

            List<Editor> editors;

            string uriEditors = _url + "GetEditors";

            HttpResponseMessage responseLineItem = await _client.GetAsync(uriEditors); // HTTP GET

            if (responseLineItem.IsSuccessStatusCode)
            {
                editors = await responseLineItem.Content.ReadAsAsync<List<Editor>>();
                ViewData["IdEditor"] = new SelectList(editors, "Id", "Name", book.IdEditor);// Add To ViewData
            }


            return View("Create");
        }

        // ________________________________________________________
        // Post (send) the new Ressource Book to the API Server 
        // POST: Books/Create
        // ________________________________________________________
        public async Task<IActionResult> PostRessource(Book book)
        {

            Book b = new Book
            {
                IdEditor = book.IdEditor,
                Title = book.Title,
                Subtitle = book.Subtitle,
                Price = book.Price,
                DatePublication = book.DatePublication,
                Summary = book.Summary,
                Isbn = book.Isbn
            };

            HttpResponseMessage response = await _client.PostAsJsonAsync("api/Books", b);

            response.EnsureSuccessStatusCode();

            return RedirectToAction("Index", "Books");

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

            return RedirectToAction("Index", "Books");
        }

        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Delete a Book
        // DELETE: Books/Delete/5
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////


        // ________________________________________________________
        // Display the "Delete" View of Books Controller 
        // GET: Books/Delete
        // ________________________________________________________

        public async Task<IActionResult> Delete(int? id)
        {
            // HTTP DELETE

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

            // ViewBag.ID = book.Id; 
            return View(book);

        }// END 



        // ________________________________________________________
        // Delete a resource Book ->  <form asp-action="ConfirmeDelete">
        // DELETE: / api/Books/s
        // ________________________________________________________

        public async Task<IActionResult> ConfirmeDelete(int? id)
        {
            var ID = id;
            // HTTP DELETE
            string uri = "api/Books/" + ID;


            HttpResponseMessage response = await _client.DeleteAsync(uri);

            response.EnsureSuccessStatusCode();

            // return RedirectToAction("Index", "Books");
            //  return RedirectToAction(nameof(Index)); 

            return RedirectToAction("Index", "Books");

        }

        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Post (send) the new Ressource Book to the API Server 
        // POST: Books/AddToShoppingCart/S
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<IActionResult> PostToShoppingCart(Book book)
        {

            Book b = new Book
            {
                IdEditor = book.IdEditor,
                Title = book.Title,
                Subtitle = book.Subtitle,
                Price = book.Price,
                DatePublication = book.DatePublication,
                Summary = book.Summary,
                Isbn = book.Isbn
            };

            HttpResponseMessage response = await _client.PostAsJsonAsync("api/Books", b);

            response.EnsureSuccessStatusCode();

            return RedirectToAction("Index", "Books");

        }


        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // ADD: A NEW lineItems to ShoppingCart of A User 
        // POST: .../ api/Books/AddItem/S
        // https://localhost:44302/Books/AddItem/3
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////


        //[Route("AddItem/{id?}")]
        //[HttpPost]

        public async Task<IActionResult> AddItem(int? id)
        {

            // _________________________________________________________________
            // GET The Book for adding to User Shoppingcart
            // _________________________________________________________________

            // https://localhost:44318/api/Books/GetUserShoppingCart/002078C2AB
            string idUser = UserID; 
            string uriShoppingcart = _url+"GetUserShoppingCart/" +idUser; 

            ShoppingCart shoppingcart = new ShoppingCart();

            HttpResponseMessage responseShoppingCart = await _client.GetAsync(uriShoppingcart); // HTTP GET
            if (responseShoppingCart.IsSuccessStatusCode)
            {
                shoppingcart = await responseShoppingCart.Content.ReadAsAsync<ShoppingCart>();
                // ViewData["ShoppingCart"] = shoppingcart ;// Add To ViewData
            }


            // _________________________________________________________________
            // GET The Article (Book) of the LineItems  
            // _________________________________________________________________

            string uriBook = _url + id;
            Book book = new Book();

            HttpResponseMessage responseBook = await _client.GetAsync(uriBook);

            if (responseBook.IsSuccessStatusCode)
            {
                var result = responseBook.Content.ReadAsStringAsync().Result;
                book = JsonConvert.DeserializeObject<Book>(result);
            }


            // _________________________________________________________________
            // CREATE a LineItems  
            // _________________________________________________________________
            
            LineItem line = new LineItem
            {
                IdBook =   book.Id, 
                UnitPrice = book.Price, 
                IdOrder = null, 
                InsertedDate = DateTime.Now, 
                Quantity = 1,
                IdShoppingcart = shoppingcart.Id,
            };


            ViewBag.USERID = UserID; 

            HttpResponseMessage response = await _client.PostAsJsonAsync($"api/Books/AddLine/", line); 
            response.EnsureSuccessStatusCode();
            return RedirectToAction("Index", "Books");


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





        // GET: Books
        public async Task<IActionResult> MessageCrud()
        {
            // TODO - TRY CATCH 

            ViewBag.CRUD = "CRUD";
            return View();

        }


    }// End Class 
}
