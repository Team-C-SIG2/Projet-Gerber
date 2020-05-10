using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppWebClient.Models;
using System.Net.Http;
using Newtonsoft.Json;

using AppWebClient.Tools;
using Microsoft.AspNetCore.Authentication;
using System.Net.Http.Headers;
using Microsoft.Extensions.Configuration;
using AppWebClient.ViewModel;
using Stripe.Issuing;
using System.Text;
using System.Net;


namespace AppWebClient.Controllers
{ 
    public class BooksController : Controller
    {

        // Var USERID 
        private readonly string UserID = "002078C2AB";

        // HTTPCLIENT 
        private HttpClient _client = ApiHttpClient.ConnectClient();

        // URL 
        private string _url = "api/books/";

        private readonly IConfiguration _configuration;

        public BooksController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

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

            string accessToken = await HttpContext.GetTokenAsync("access_token");
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            string content = await client.GetStringAsync(_configuration["URLApi"] + "api/Books/");

            List<Book> books = JsonConvert.DeserializeObject<List<Book>>(content);

            if (books == null)
            {
                return NotFound();
            }

            return View(books);
        }

        /*
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
        */

        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Get the Details of a resource Book (by id)
        // GET : Books/Details/5
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<IActionResult> Details(int? id)
        {
            string accessToken = await HttpContext.GetTokenAsync("access_token");
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            string content = await client.GetStringAsync(_configuration["URLApi"] + "api/Books/" + id);

            Book book = JsonConvert.DeserializeObject<Book>(content);

            if (book == null)
            {
                return NotFound();
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

        public async Task<IActionResult> Edit(int? id, Book book)
        {
            string accessToken = await HttpContext.GetTokenAsync("access_token");

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            string content = await client.GetStringAsync(_configuration["URLApi"] + "api/Books/" + id);

            Book _book = JsonConvert.DeserializeObject<Book>(content);

            if (_book == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                string jsonString = System.Text.Json.JsonSerializer.Serialize<Book>(book);

                StringContent httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PutAsync(_configuration["URLApi"] + "api/Books/" + _book.Id, httpContent);
                if (response.StatusCode != HttpStatusCode.NoContent)
                {
                    return BadRequest();
                }
                return RedirectToAction(nameof(Index));
            }

            return View(_book);
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


            string accessToken = await HttpContext.GetTokenAsync("access_token");

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            /*
            string idUser = UserID;
            string uriShoppingcart = _url + "GetUserShoppingCart/";
            */

            ShoppingCart shoppingcart = new ShoppingCart();

            string idUser = await client.GetStringAsync(_configuration["URLApi"] + "api/AspNetUsers/UserId/"); // HTTP GET

            string responseSP = await client.GetStringAsync(_configuration["URLApi"] + "api/ShoppingCarts/");
            var shopcarts = JsonConvert.DeserializeObject<IEnumerable<ShoppingCart>>(responseSP);

            ShoppingCart shopcart = (from sp in shopcarts
                                     where sp.User.Id == idUser
                                     select sp).FirstOrDefault();

            HttpResponseMessage responseShoppingcart;

            if (shopcart == null)
            {
                ShoppingCart sp = new ShoppingCart
                {
                    UserId = idUser,
                    CreatedDate = DateTime.Now
                };

                responseShoppingcart = await client.PostAsJsonAsync(_configuration["URLApi"] + "api/ShoppingCarts/CreateShoppingCart/", sp);
            }
            else
            {
                responseShoppingcart = await client.GetAsync(_configuration["URLApi"] + "api/ShoppingCarts/GetUserShoppingCarts/" + idUser);
            }
            
            if (responseShoppingcart.IsSuccessStatusCode)
            {
                shoppingcart = await responseShoppingcart.Content.ReadAsAsync<ShoppingCart>();
                // ViewData["ShoppingCart"] = shoppingcart ;// Add To ViewData
            }


            // _________________________________________________________________
            // GET The Article (Book) of the LineItems  
            // _________________________________________________________________

            string uriBook = _configuration["URLApi"] + "api/Books/" + id;
            Book book = new Book();

            HttpResponseMessage responseBook = await client.GetAsync(uriBook);

            if (responseBook.IsSuccessStatusCode)
            {
                var result = responseBook.Content.ReadAsStringAsync().Result;
                book = JsonConvert.DeserializeObject<Book>(result);
            }


            // _________________________________________________________________
            // CREATE a LineItems  
            // _________________________________________________________________


            string content = await client.GetStringAsync(_configuration["URLApi"] + "api/LineItems/Items/" + shoppingcart.Id);

            IEnumerable<LineItem> lineItems;

            // Pour incrémenter la quantité lorsque le livre est déjà choisi --> Pas encore fonctionnel, à creuser !
            if (content != null)
            {
                lineItems = JsonConvert.DeserializeObject<IEnumerable<LineItem>>(content);

                var q = (from lineItem in lineItems
                        where lineItem.IdBook == book.Id
                        select lineItem).FirstOrDefault();

                if (q == null)
                {
                    LineItem line = new LineItem
                    {
                        IdBook = book.Id,
                        UnitPrice = book.Price,
                        IdOrder = null,
                        InsertedDate = DateTime.Now,
                        Quantity = 1,
                        IdShoppingcart = shoppingcart.Id,
                    };

                    ViewBag.USERID = UserID;
                    // string jsonLine = JsonConvert.SerializeObject(line);
                    HttpResponseMessage response = await client.PostAsJsonAsync(_configuration["URLApi"] + "api/Books/AddLine/", line);
                    //response.EnsureSuccessStatusCode();
                }
                else
                {
                    q.Quantity++;
                    string jsonString = System.Text.Json.JsonSerializer.Serialize<LineItem>(q);
                    StringContent httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PutAsync(_configuration["URLApi"] + "api/LineItems/" + q.Id, httpContent);
                }
            }
            else
            {
                return View("Error");
            }

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




        // GET: Books/search
        public async Task<IActionResult> SearchAsync()
        {
            string uri = _configuration["URLApi"] + "api/Editors/";
            string accessToken = await HttpContext.GetTokenAsync("access_token");

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var result = await client.GetStringAsync(uri);
            var editorList = JsonConvert.DeserializeObject<IEnumerable<Editor>>(result);
            SelectList slEditor = new SelectList(editorList, "Id", "Name");
            ViewBag.IdEditor = slEditor;

            uri = _configuration["URLApi"] + "api/Categories/";
            result = await client.GetStringAsync(uri);
            var categoryList = JsonConvert.DeserializeObject<IEnumerable<Category>>(result);
            SelectList slCategory = new SelectList(categoryList, "Id", "Description");
            ViewBag.IdCategory = slCategory;

            return View();
        }

        [HttpPost]
        // POST: Books/find
        public async Task<IActionResult> FindAsync(BookSearch searchedBook)
        {
            bool searched = false;
            IEnumerable<Book> books;
            IEnumerable<Book> q = null;
            StringComparison sc = StringComparison.OrdinalIgnoreCase;
            string uri = _configuration["URLApi"] + "api/Books/";
            string accessToken = await HttpContext.GetTokenAsync("access_token");

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var content = await client.GetStringAsync(uri);


            if (content != null)
            {
                var result = content;
                books = JsonConvert.DeserializeObject<IEnumerable<Book>>(result);
                q = books;

                if (searchedBook.Isbn != null)
                {
                    q = (from b in q
                         where b.Isbn == searchedBook.Isbn
                         select b).ToList();
                    searched = true;
                }

                if (searchedBook.authorName != null)
                {
                    uri = _configuration["URLApi"] + "api/Cowriters/";
                    var contentCowriters = await client.GetStringAsync(uri);
                    var cowriters = JsonConvert.DeserializeObject<IEnumerable<Cowriter>>(contentCowriters);
                    uri = _configuration["URLApi"] + "api/Authors/";
                    var contentAuthors = await client.GetStringAsync(uri);
                    var authors = JsonConvert.DeserializeObject<IEnumerable<Author>>(contentAuthors);
                    q = (from b in q
                         join cowriter in cowriters on b.Id equals cowriter.IdBook
                         join author in authors on cowriter.IdAuthor equals author.Id
                         where author.Firstname.Contains(searchedBook.authorName, sc)
                         || author.Lastname.Contains(searchedBook.authorName, sc)
                         || (author.Lastname + " " + author.Firstname).Contains(searchedBook.authorName, sc)
                         || (author.Firstname + " " + author.Lastname).Contains(searchedBook.authorName, sc)
                         select b).ToList();

                    searched = true;
                }

                if (searchedBook.category != 0)
                {
                    uri = _configuration["URLApi"] + "api/Ranks/";
                    var contentRank = await client.GetStringAsync(uri);
                    var ranks = JsonConvert.DeserializeObject<IEnumerable<Rank>>(contentRank);
                    q = (from b in q
                         join rank in ranks on b.Id equals rank.IdBook
                         where rank.IdCategorie == searchedBook.category
                         select b).ToList();
                    searched = true;
                }

                if (searchedBook.Title != null)
                {
                    q = (from b in q
                         where b.Title.Contains(searchedBook.Title, sc)
                         select b).ToList();

                    searched = true;
                }

                if (searchedBook.Subtitle != null)
                {
                    q = (from b in q
                         where b.Subtitle.Contains(searchedBook.Subtitle, sc)
                         select b).ToList();

                    searched = true;
                }

                if (searchedBook.DatePublicationFrom != null)
                {
                    q = (from b in q
                         where b.DatePublication > searchedBook.DatePublicationFrom
                         select b).ToList();

                    searched = true;
                }

                if (searchedBook.DatePublicationTo != null)
                {
                    q = (from b in q
                         where b.DatePublication < searchedBook.DatePublicationTo
                         select b).ToList();

                    searched = true;
                }

                if (searchedBook.PriceFrom != null)
                {
                    q = (from b in q
                         where b.Price > searchedBook.PriceFrom
                         select b).ToList();

                    searched = true;
                }

                if (searchedBook.PriceTo != null)
                {
                    q = (from b in q
                         where b.Price < searchedBook.PriceTo
                         select b).ToList();

                    searched = true;
                }
                if (searchedBook.Summary != null)
                {
                    q = (from b in q
                         where b.Summary.Contains(searchedBook.Summary)
                         select b).ToList();

                    searched = true;
                }
                if (searchedBook.IdEditor != 0)
                {
                    q = (from b in q
                         where b.IdEditor == searchedBook.IdEditor
                         select b).ToList();

                    searched = true;
                }
            }
            if (searched)
            {
                return View(q);
            }
            else
            {
                return RedirectToAction("Search", "Books");
            }
        }

    }// End Class 
}
