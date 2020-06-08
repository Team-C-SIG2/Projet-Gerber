using AppWebClient.Models;
using AppWebClient.Tools;
using AppWebClient.ViewModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Net;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.Threading.Tasks;

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

            string content = await client.GetStringAsync(_configuration["URLApi"] + _url+"GetOneBook/" + id);

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

            ShoppingCart shoppingcart = new ShoppingCart();

            string idUser = await client.GetStringAsync(_configuration["URLApi"] + "api/AspNetUsers/UserId/"); 

            string responseSP = await client.GetStringAsync(_configuration["URLApi"] + "api/ShoppingCarts/");
            IEnumerable<ShoppingCart> shopcarts = JsonConvert.DeserializeObject<IEnumerable<ShoppingCart>>(responseSP);

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
            }


            // _________________________________________________________________
            // GET The Article (Book) of the LineItems  
            // _________________________________________________________________

            string uriBook = _configuration["URLApi"] + "api/Books/" + id;
            Book book = new Book();

            HttpResponseMessage responseBook = await client.GetAsync(uriBook);

            if (responseBook.IsSuccessStatusCode)
            {
                string result = responseBook.Content.ReadAsStringAsync().Result;
                book = JsonConvert.DeserializeObject<Book>(result);
            }


            // _________________________________________________________________
            // GET The Wishlist of the LineItems  
            // _________________________________________________________________

            string responseWL = await client.GetStringAsync(_configuration["URLApi"] + "api/Wishlists/Wishlist/");
            IEnumerable<Wishlist> wishlists = JsonConvert.DeserializeObject<IEnumerable<Wishlist>>(responseWL);

            Wishlist wishlist = (from w in wishlists
                                 where w.User.Id == idUser
                                 select w).FirstOrDefault();


            // _________________________________________________________________
            // CREATE a LineItems  
            // _________________________________________________________________

            string content = await client.GetStringAsync(_configuration["URLApi"] + "api/LineItems/Items/" + shoppingcart.Id);
            string content2 = "[]";
            if (shopcart != null)
            {
                content2 = await client.GetStringAsync(_configuration["URLApi"] + "api/LineItems/Wishlist/" + wishlist.Id);
            }

            IEnumerable<LineItem> lineItems;
            IEnumerable<LineItem> lineItems2;

            if (content != null)
            {
                HttpResponseMessage response;
                lineItems = JsonConvert.DeserializeObject<IEnumerable<LineItem>>(content);
                lineItems2 = JsonConvert.DeserializeObject<IEnumerable<LineItem>>(content2);

                LineItem q = (from lineItem in lineItems
                              where lineItem.IdBook == book.Id
                              select lineItem).FirstOrDefault();

                LineItem q2 = (from lineItem in lineItems2
                               where lineItem.IdBook == book.Id
                               select lineItem).FirstOrDefault();

                if (q == null && q2 == null)
                {
                    LineItem line = new LineItem
                    {
                        IdBook = book.Id,
                        UnitPrice = book.Price,
                        IdOrder = null,
                        InsertedDate = DateTime.Now,
                        Quantity = 1,
                        IdShoppingcart = shoppingcart.Id
                    };
                    ViewBag.USERID = UserID;
                    response = await client.PostAsJsonAsync(_configuration["URLApi"] + "api/Books/AddLine/", line);

                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        return BadRequest();
                    }
                }
                else if (q == null && q2 != null)
                {
                    ViewBag.USERID = UserID;
                    q2.IdShoppingcart = shoppingcart.Id;
                    q2.InsertedDate = DateTime.Now;
                    string jsonString = System.Text.Json.JsonSerializer.Serialize<LineItem>(q2);
                    StringContent httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");
                    response = await client.PutAsync(_configuration["URLApi"] + "api/LineItems/" + q2.Id, httpContent);

                    if (response.StatusCode != HttpStatusCode.NoContent)
                    {
                        return BadRequest();
                    }
                }
                else
                {
                    q.Quantity++;
                    q.InsertedDate = DateTime.Now;
                    string jsonString = System.Text.Json.JsonSerializer.Serialize<LineItem>(q);
                    StringContent httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");
                    response = await client.PutAsync(_configuration["URLApi"] + "api/LineItems/" + q.Id, httpContent);
                    if (response.StatusCode != HttpStatusCode.NoContent)
                    {
                        return BadRequest();
                    }
                }
            }
            else
            {
                return View("Error");
            }

            return RedirectToAction("");
        }



        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // ADD: A NEW lineItems to Wishlist of A User 
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        public async Task<IActionResult> AddToWishlist(int? id)
        {
            string accessToken = await HttpContext.GetTokenAsync("access_token");

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            Wishlist wishlist = new Wishlist();

            string idUser = await client.GetStringAsync(_configuration["URLApi"] + "api/AspNetUsers/UserId/"); 

            string responseWL = await client.GetStringAsync(_configuration["URLApi"] + "api/Wishlists/Wishlist/");
            IEnumerable<Wishlist> wishlists = JsonConvert.DeserializeObject<IEnumerable<Wishlist>>(responseWL);

            Wishlist wl = (from w in wishlists
                           where w.User.Id == idUser
                           select w).FirstOrDefault();

            HttpResponseMessage responseWishlist; ;

            if (wl == null)
            {
                Wishlist wish = new Wishlist
                {
                    UserId = idUser,
                    CreatedDate = DateTime.Now
                };

                responseWishlist = await client.PostAsJsonAsync(_configuration["URLApi"] + "api/Wishlists/", wish);
            }
            else
            {
                responseWishlist = await client.GetAsync(_configuration["URLApi"] + "api/Wishlists/Wishlist/" + idUser);
            }
            
            if (responseWishlist.IsSuccessStatusCode)
            {
                wishlist = await responseWishlist.Content.ReadAsAsync<Wishlist>();
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
            // GET The Shoppingcart of the LineItems  
            // _________________________________________________________________

            string responseSP = await client.GetStringAsync(_configuration["URLApi"] + "api/ShoppingCarts/");
            IEnumerable<ShoppingCart> shopcarts = JsonConvert.DeserializeObject<IEnumerable<ShoppingCart>>(responseSP);

            ShoppingCart shopcart = (from sp in shopcarts
                                     where sp.User.Id == idUser
                                     select sp).FirstOrDefault();


            // _________________________________________________________________
            // CREATE a LineItems  
            // _________________________________________________________________

            string content = await client.GetStringAsync(_configuration["URLApi"] + "api/LineItems/Wishlist/" + wishlist.Id);
            string content2 = "[]";
            if (shopcart != null)
            {
                content2 = await client.GetStringAsync(_configuration["URLApi"] + "api/LineItems/Items/" + shopcart.Id);
            }

            IEnumerable<LineItem> lineItems;
            IEnumerable<LineItem> lineItems2;

            if (content != null)
            {
                HttpResponseMessage response;
                lineItems = JsonConvert.DeserializeObject<IEnumerable<LineItem>>(content);
                lineItems2 = JsonConvert.DeserializeObject<IEnumerable<LineItem>>(content2);

                LineItem q = (from lineItem in lineItems
                              where lineItem.IdBook == book.Id
                              select lineItem).FirstOrDefault();

                LineItem q2 = (from lineItem in lineItems2
                               where lineItem.IdBook == book.Id
                               select lineItem).FirstOrDefault();

                if (q == null && q2 == null)
                {
                    LineItem line = new LineItem
                    {
                        IdBook = book.Id,
                        UnitPrice = book.Price,
                        IdOrder = null,
                        InsertedDate = DateTime.Now,
                        Quantity = 1,
                        IdWishlist = wishlist.Id
                    };
                    response = await client.PostAsJsonAsync(_configuration["URLApi"] + "api/Books/AddLine/", line);
                    
                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        return BadRequest();
                    }
                }
                else if (q == null && q2 != null)
                {
                    q2.IdWishlist = wishlist.Id;
                    q2.InsertedDate = DateTime.Now;
                    string jsonString = System.Text.Json.JsonSerializer.Serialize<LineItem>(q2);
                    StringContent httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");
                    response = await client.PutAsync(_configuration["URLApi"] + "api/LineItems/" + q2.Id, httpContent);

                    if (response.StatusCode != HttpStatusCode.NoContent)
                    {
                        return BadRequest();
                    }
                }
                else
                {
                    return RedirectToAction("");
                }
            }
            else
            {
                return View("Error");
            }

            return RedirectToAction("");
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
            bool searched = true;
            string jsonString = System.Text.Json.JsonSerializer.Serialize(searchedBook);
            StringContent httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

            //  Pour joindre l'API
            string uri = _configuration["URLApi"] + "api/Books/Find";
            string accessToken = await HttpContext.GetTokenAsync("access_token");
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = client.PostAsync(uri, httpContent);
            var foundbooks = await response.Result.Content.ReadAsAsync<IEnumerable<Book>>();
            if (searched)
            {
                return View(foundbooks);
            }
            else
            {
                return RedirectToAction("Search", "Books");
            }
        }

    }// End Class 
}
