﻿using AppWebClient.Models;
using AppWebClient.Tools;
using AppWebClient.ViewModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
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
using System.Threading.Tasks;

namespace AppWebClient.Controllers
{
    public class BooksController : Controller
    {

        // HTTPCLIENT 
        private HttpClient _client = new HttpClient();

        // URL 
        private string _url = "api/books/";


        //TO GET DATA FROM JSON FILE CONFIGURATION  
        private readonly IConfiguration _configuration;


        // CONSTRUCTOR 
        public BooksController(IConfiguration configuration)
        {
            _configuration = configuration;
        }



        // _______________________________________________________________________________________________________
        // COMMON PART 
        // _______________________________________________________________________________________________________



        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // READ: Return the User ShoppingCart
        // GET: .../api/ShoppingCarts/5
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<IActionResult> Index(string bookSearch)
        {
            string accessToken = await HttpContext.GetTokenAsync("access_token");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            string content = await _client.GetStringAsync(_configuration["URLApi"] + _url);

            List<Book> books = JsonConvert.DeserializeObject<List<Book>>(content);
            List<Book> bookList = books;

            ViewData["GETBOOKDETTAILS"] = bookSearch;

            if (!string.IsNullOrEmpty(bookSearch))
            {
                bookList = new List<Book>();

                foreach (var book in books)
                {
                    if (book.Title.Contains(bookSearch))
                    {
                        bookList.Add(book);
                    }
                }
            }


            if (books == null)
            {
                return NotFound();
            }


            // GET ACCESS RIGHT 
            string accessRight = await GetRole();
            ViewData["ACCESSRIGHT"] = accessRight;

            return View(bookList);
        }


        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Get the Details of a resource Book (by id) 
        // GET : Books/Details/5
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<IActionResult> Details(int? id)
        {
            string accessToken = await HttpContext.GetTokenAsync("access_token");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            string content = await _client.GetStringAsync(_configuration["URLApi"] + _url+ "GetOneBook/" + id);

            Book book = JsonConvert.DeserializeObject<Book>(content);

            if (book == null)
            {
                return NotFound();
            }


            // GET ACCESS RIGHT 
            string accessRight = await GetRole();
            ViewData["ACCESSRIGHT"] = accessRight;

            return View(book);
        }// END 





        // _______________________________________________________________________________________________________
        // USER/CLIENT PART 
        // _______________________________________________________________________________________________________


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

            HttpResponseMessage response = await _client.PostAsJsonAsync("api/Books/AddToShoppingCart/", b);

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

            HttpResponseMessage responseShoppingcart;
            ShoppingCart shoppingcart = new ShoppingCart();

            // GET ACCESS TOKEN & AUTHORIZATION REQUEST 
            string accessToken = await HttpContext.GetTokenAsync("access_token");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            // GET USER ID 
            string idUser = await _client.GetStringAsync(_configuration["URLApi"] + "api/AspNetUsers/UserId/");

            // GET SHOPPINGCARTS LIST 
            string responseSP = await _client.GetStringAsync(_configuration["URLApi"] + "api/ShoppingCarts/");
            IEnumerable<ShoppingCart> shopcarts = JsonConvert.DeserializeObject<IEnumerable<ShoppingCart>>(responseSP);

            // GET USER SHOPPINGCART 
            ShoppingCart shopcart = (from sp in shopcarts
                                     where sp.User.Id == idUser
                                     select sp).FirstOrDefault();

            if (shopcart == null)
            {
                // CREATE NEW SHOPPING CART FOR CONNECTED USER 
                ShoppingCart sp = new ShoppingCart
                {
                    UserId = idUser,
                    CreatedDate = DateTime.Now
                };

                // SEND THE NEW CREATED SHOPPINGCART TO THE SERVER API 
                responseShoppingcart = await _client.PostAsJsonAsync(_configuration["URLApi"] + "api/ShoppingCarts/CreateShoppingCart/", sp);
            }
            else
            {
                // SHOPPINGCART ALREADY EXIST : GET THE SHOPPINGCART OF CONNECTED USER 
                responseShoppingcart = await _client.GetAsync(_configuration["URLApi"] + "api/ShoppingCarts/GetUserShoppingCarts/" + idUser);
            }

            if (responseShoppingcart.IsSuccessStatusCode)
            {
                // ACCESS THE SHOPPING CART CONTENT (BOOK LIST)
                shoppingcart = await responseShoppingcart.Content.ReadAsAsync<ShoppingCart>();
            }


            // _________________________________________________________________
            // GET The Article (Book) of the LineItems  
            // _________________________________________________________________

            string uriBook = _configuration["URLApi"] + "api/Books/" + id;
            Book book = new Book();

            HttpResponseMessage responseBook = await _client.GetAsync(uriBook);

            if (responseBook.IsSuccessStatusCode)
            {
                string result = responseBook.Content.ReadAsStringAsync().Result;
                book = JsonConvert.DeserializeObject<Book>(result);
            }


            // _________________________________________________________________
            // GET The Wishlist of the LineItems  
            // _________________________________________________________________

            string responseWL = await _client.GetStringAsync(_configuration["URLApi"] + "api/Wishlists/Wishlist/");
            IEnumerable<Wishlist> wishlists = JsonConvert.DeserializeObject<IEnumerable<Wishlist>>(responseWL);

            Wishlist wishlist = (from w in wishlists
                                 where w.User.Id == idUser
                                 select w).FirstOrDefault();


            // _________________________________________________________________
            // CREATE a LineItems  
            // _________________________________________________________________

            // GET SHOPPING CART CONTENT (LINEITMES : BOOKS) 
            string contentSC = await _client.GetStringAsync(_configuration["URLApi"] + "api/LineItems/Items/" + shoppingcart.Id);

            // GET WHISHLIST (BOOKS) 
            string contentWL = "[]";
            if (shopcart != null)
            {
                contentWL = await _client.GetStringAsync(_configuration["URLApi"] + "api/LineItems/Wishlist/" + wishlist.Id);
            }

            IEnumerable<LineItem> SC_LineItems;
            IEnumerable<LineItem> WL_LineItems;

            if (contentSC != null)
            {
                HttpResponseMessage response;
                SC_LineItems = JsonConvert.DeserializeObject<IEnumerable<LineItem>>(contentSC);
                WL_LineItems = JsonConvert.DeserializeObject<IEnumerable<LineItem>>(contentWL);

                LineItem SC_lineitem = (from lineItem in SC_LineItems
                                        where lineItem.IdBook == book.Id
                                        select lineItem).FirstOrDefault();

                LineItem WL_lineitem = (from lineItem in WL_LineItems
                                        where lineItem.IdBook == book.Id
                                        select lineItem).FirstOrDefault();

                if (SC_lineitem == null && WL_lineitem == null)
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

                    ViewBag.USERID = idUser;
                    response = await _client.PostAsJsonAsync(_configuration["URLApi"] + "api/Books/AddLine/", line);

                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        return BadRequest();
                    }
                }
                else if (SC_lineitem == null && WL_lineitem != null)
                {
                    ViewBag.USERID = idUser;
                    WL_lineitem.IdShoppingcart = shoppingcart.Id;
                    WL_lineitem.InsertedDate = DateTime.Now;
                    string jsonString = System.Text.Json.JsonSerializer.Serialize<LineItem>(WL_lineitem);
                    StringContent httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");
                    response = await _client.PutAsync(_configuration["URLApi"] + "api/LineItems/" + WL_lineitem.Id, httpContent);

                    if (response.StatusCode != HttpStatusCode.NoContent)
                    {
                        return BadRequest();
                    }
                }
                else
                {
                    SC_lineitem.Quantity++;
                    SC_lineitem.InsertedDate = DateTime.Now;
                    string jsonString = System.Text.Json.JsonSerializer.Serialize<LineItem>(SC_lineitem);
                    StringContent httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");
                    response = await _client.PutAsync(_configuration["URLApi"] + "api/LineItems/" + SC_lineitem.Id, httpContent);
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
        // To Create a new Book 
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////

        // ________________________________________________________
        // Display the "Create" View of Books Controller 
        // GET: Books/Create
        // ________________________________________________________
        public async Task<IActionResult> Create(Book book)
        {
            List<Editor> editors;

            string uriEditors = _url + "GetEditors";

            string accessToken = await HttpContext.GetTokenAsync("access_token");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            HttpResponseMessage responseEditor = await _client.GetAsync(_configuration["URLApi"] + uriEditors);// HTTP GET

            // GET EDITOR SELECTLIST 
            if (responseEditor.IsSuccessStatusCode)
            {
                editors = await responseEditor.Content.ReadAsAsync<List<Editor>>();
                ViewData["EDITEURS"] = new SelectList(editors, "Id", "Name", book.IdEditor);// Add To ViewData
            }

            return View("Create");
        }


        // ________________________________________________________
        // Post (send) the new Ressource Book to the API Server 
        // POST: Books/Create
        // ________________________________________________________
        public async Task<IActionResult> Post(Book book)
        {
            // Recover the Book 
            Book postBook = new Book
            {
                IdEditor = book.IdEditor,
                Title = book.Title,
                Subtitle = book.Subtitle,
                Price = book.Price,
                DatePublication = book.DatePublication,
                Summary = book.Summary,
                Isbn = book.Isbn,
                Stock = book.Stock,
                StockInitial = book.StockInitial
            };


            string accessToken = await HttpContext.GetTokenAsync("access_token");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            HttpResponseMessage response = await _client.PostAsJsonAsync(_configuration["URLApi"] + _url, postBook);
            //  response.EnsureSuccessStatusCode();


            // Message 
            ViewBag.ID = postBook.Id;
            TempData["msg"] = "Nouvelle insertion";

            // Page de nouveau | liste | Auteurs 
            return RedirectToAction("Index", "Books");

        }


        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // UPDATE : Update a Book 
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////

        // ________________________________________________________
        // Edit Book for UPDATE
        // GET: api/Books/Edit/5
        // ________________________________________________________


        public async Task<IActionResult> Edit(int? id, Book book)
        {

            string accessToken = await HttpContext.GetTokenAsync("access_token");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            string uri = _url + "GetOneBook/"+ id;

            string content = await _client.GetStringAsync(_configuration["URLApi"] + uri);
            Book _book = JsonConvert.DeserializeObject<Book>(content);

            if (_book == null)
            {
                return NotFound();
            }

            // Select List (Liste Déroulante) 
            List<Editor> editeurs;
            string uriGetEditeurs = _url + "GetEditors";
            HttpResponseMessage responseEditors = await _client.GetAsync(_configuration["URLApi"] + uriGetEditeurs); // HTTP GET

            if (responseEditors.IsSuccessStatusCode)
            {
                editeurs = await responseEditors.Content.ReadAsAsync<List<Editor>>();
                ViewData["EDITEURS"] = new SelectList(editeurs, "Id", "Name", book.IdEditor);// Add To ViewData
            }

            return View(_book);
        }


        // ________________________________________________________
        // UPDATE : Update Books ->  <form asp-action="Put">
        // PUT (HTTP VERB) : / api/Books/S
        // ________________________________________________________

        public async Task<IActionResult> Put(int id, Book book)
        {
            string uri = _url + id;

            string accessToken = await HttpContext.GetTokenAsync("access_token");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

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

            HttpResponseMessage response = await _client.PutAsJsonAsync(_configuration["URLApi"] + uri, b);
            response.EnsureSuccessStatusCode();

            return RedirectToAction("Index", "Books");
        }


        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Delete a Book
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////

        // ________________________________________________________
        // Display the "Delete" View of Books Controller 
        // GET: Books/Delete
        // ________________________________________________________

        public async Task<IActionResult> Delete(int? id)
        {
            string uri = _url + "GetOneBook/" + id; 
            Book book = new Book();

            string accessToken = await HttpContext.GetTokenAsync("access_token");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            // HTTP DELETE
            HttpResponseMessage response = await _client.GetAsync(_configuration["URLApi"] + uri);

            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                book = JsonConvert.DeserializeObject<Book>(result);
            }
            else
            {
                // ERROR
                return NotFound();
            }

            return View(book);

        }// END 

        // ________________________________________________________
        // Delete a resource Book ->  <form asp-action="ConfirmeDelete">
        // DELETE: / api/Books/s
        // ________________________________________________________

        public async Task<IActionResult> ConfirmeDelete(int? id)
        {
            // HTTP DELETE
            string uri = _url + id;

            string accessToken = await HttpContext.GetTokenAsync("access_token");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            HttpResponseMessage response = await _client.DeleteAsync(_configuration["URLApi"] + uri);
            // response.EnsureSuccessStatusCode(); 

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


        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Methods for ADVANCED SEARCH 
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////

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



        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // To Create a new Editor 
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////


        // ________________________________________________________
        // Display the "CreateEditor" View for createing new Editor 
        // GET: AdminBooks/CreateEditor
        // ________________________________________________________
        public async Task<IActionResult> CreateEditor(int? id)
        {
            ViewBag.ID = id;
            TempData["msg"] = "AdminBooks : Editor inserted";

            return View("CreateEditor");
        }



        // ________________________________________________________
        // Post (send) the new Editor to the API Server 
        // POST: AdminBooks/PostEditor
        // ________________________________________________________
        public async Task<IActionResult> PostEditor(int? id, Editor editor, Book? book)
        {
            string uri = _url + id;
            Book b = null;

            string accessToken = await HttpContext.GetTokenAsync("access_token");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            // Recover the Editor
            Editor postEditor = new Editor
            {
                Email = editor.Email,
                Url = editor.Url,
                CountryCode = editor.CountryCode,
                Name = editor.Name

            };

            // HTTP POST Editor 
            HttpResponseMessage responsePostEditor = await _client.PostAsJsonAsync(_configuration["URLApi"] + _url + "PostEditor", postEditor);

            // GET Editor ID 
            var resultPostEditor = responsePostEditor.Content.ReadAsStringAsync().Result;
            int EditorID = JsonConvert.DeserializeObject<int>(resultPostEditor);

            // HTTP GET and PUT Book 
            HttpResponseMessage responseGetBook = await _client.GetAsync(_configuration["URLApi"] + uri);
            // Update book's Editor 
            var resultGetBook = responseGetBook.Content.ReadAsStringAsync().Result;
            book = JsonConvert.DeserializeObject<Book>(resultGetBook);

            b = new Book
            {
                Id = book.Id,
                IdEditor = EditorID,
                Title = book.Title,
                Subtitle = book.Subtitle,
                Price = book.Price,
                DatePublication = book.DatePublication,
                Summary = book.Summary,
                Isbn = book.Isbn,
                IdEditorNavigation = postEditor
            };

            uri = _url + b.Id;
            HttpResponseMessage responsePutBook = await _client.PutAsJsonAsync(_configuration["URLApi"] + uri, b);// HTTP PUT (UPDATE)
            responsePutBook.EnsureSuccessStatusCode();

            // http://localhost:5002/AdminBooks/Edit/208
            return RedirectToAction("Index", "Books");

        }



        // ------------------------------------------------------------------
        // To get View of action AdminAccess() 
        // ------------------------------------------------------------------

        public IActionResult AdminAccess()
        {
            return View();
        }


        // ------------------------------------------------------------------
        // To Manage the Authors of selected book () 
        // ------------------------------------------------------------------
        public async Task<IActionResult> ManageCowriters(int? id, string title) // Id = Book's Id
        {
            string isbn = null;
            string accessToken = await HttpContext.GetTokenAsync("access_token");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            string content = await _client.GetStringAsync(_configuration["URLApi"] + _url + "ManageCowriters/" + id);
            List<Cowriter> cowriters = JsonConvert.DeserializeObject<List<Cowriter>>(content);

            if (cowriters == null)
            {
                return NotFound();
            }

            foreach (var item in cowriters)
            {
                // Get ISBN 
                isbn = item.IdBookNavigation.Isbn;
            }

            ViewData["ISBN"] = isbn;
            ViewData["BOOKID"] = id;
            ViewData["BOOKTITLE"] = title;

            return View(cowriters);
        }



        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Create a new Cowriter for a book
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<IActionResult> CreateCowriter(int? id)
        {
            string accessToken = await HttpContext.GetTokenAsync("access_token");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);


            // GET BOOK 
            string uri = _url + id;
            string content = await _client.GetStringAsync(_configuration["URLApi"] + uri);
            Book _book = JsonConvert.DeserializeObject<Book>(content);

            if (_book == null)
            {
                return NotFound();
            }


            // GET AUTHORS LIST 
            string contentGetAuthors = await _client.GetStringAsync(_configuration["URLApi"] + _url + "GetAuthors");
            List<Author> authors = JsonConvert.DeserializeObject<List<Author>>(contentGetAuthors);
            if (authors == null)
            {
                return NotFound();
            }


            ViewData["SELECTAUTHORS"] = new SelectList(authors, "Id", "Lastname");
            ViewData["BOOKTITLE"] = _book.Title;
            ViewData["BOOKID"] = _book.Id;

            return View("CreateCowriter");
        }


        // ________________________________________________________
        // Post (send) the new Cowriter to the API Server 
        // POST: AdminBooks/PostCowriter
        // ________________________________________________________
        public async Task<IActionResult> PostCowriter(int id, Cowriter cowriter)
        {

            string accessToken = await HttpContext.GetTokenAsync("access_token");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            // Recover the Cowriter
            Cowriter postCowriter = new Cowriter
            {
                IdAuthor = cowriter.IdAuthor,
                IdBook = id

            };

            // HTTP POST Cowriter 
            HttpResponseMessage responsePostCowriter = await _client.PostAsJsonAsync(_configuration["URLApi"] + _url + "PostCowriter", postCowriter);

            // http://localhost:5002/AdminBooks/Edit/208
            return RedirectToAction("Index", "Books");

        }





        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Delete a Book
        // DELETE: Books/Delete/5
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////


        // ________________________________________________________
        // HTTP DELETE
        // Display the "Delete" View of Books Controller 
        // GET: Books/Delete
        // ________________________________________________________

        public async Task<IActionResult> DeleteCowriter(int? idAuthor, int? idBook) // id = idAuthor
        {
            // _______________________
            // GET CoWriter 
            // _______________________

            string uriGetCowriter = _url + "GetCowriter/" + idAuthor;
            Cowriter cowriter = new Cowriter();

            string accessToken = await HttpContext.GetTokenAsync("access_token");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);


            HttpResponseMessage responseuriGetCowriter = await _client.GetAsync(_configuration["URLApi"] + uriGetCowriter);

            if (responseuriGetCowriter.IsSuccessStatusCode)
            {
                var resultGetCowriter = responseuriGetCowriter.Content.ReadAsStringAsync().Result;
                cowriter = JsonConvert.DeserializeObject<Cowriter>(resultGetCowriter);
            }
            else
            {
                // ERROR
                return NotFound();
            }


            // _______________________
            // GET Book 
            // _______________________

            string uriGetBook = _url + idBook;
            string contentGetBook = await _client.GetStringAsync(_configuration["URLApi"] + uriGetBook);
            Book book = JsonConvert.DeserializeObject<Book>(contentGetBook);

            if (book == null)
            {
                return NotFound();
            }

            ViewData["BOOKTITLE"] = book.Title;
            ViewData["BOOKID"] = book.Id;
            ViewData["BOOKISBN"] = book.Isbn;
            ViewData["IdAuthor"] = cowriter.IdAuthor;

            return View(cowriter);

        }// END 



        // ________________________________________________________
        // Delete a resource Book ->  <form asp-action="ConfirmeDelete">
        // DELETE: / api/Books/s
        // ________________________________________________________

        public async Task<IActionResult> ConfirmeDeleteCowriter(int? idAuthor, int? idBook)
        {
            Cowriter cowriter = new Cowriter();
            // HTTP DELETE
            string uri = _url + "DeleteCowriter/" + idAuthor+"/"+idBook;

            string accessToken = await HttpContext.GetTokenAsync("access_token");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            HttpResponseMessage response = await _client.DeleteAsync(_configuration["URLApi"] + uri);
            // response.EnsureSuccessStatusCode(); 

            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                cowriter = JsonConvert.DeserializeObject<Cowriter>(result);
            }
            else
            {
                // ERROR
                return NotFound();
            }

            ViewData["IdAuthor"] = cowriter.IdAuthor;
            return RedirectToAction("Index", "Books");
        }




        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // CONTROL CONNECTED USER ROLE (ACCES RIGHTS)
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////

        [Route("VerifyRole")]
        public async Task<IActionResult> VerifyRole()
        {
            string accessToken = await HttpContext.GetTokenAsync("access_token");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            string accessRight = await GetRole();
            ViewData["ACCESSRIGHT"] = accessRight;

            if (accessRight == "ADMIN")
            {
                return RedirectToAction("AdminAccess", "Books");  // ACCESS DASHBOARD
            }
            else
            {
                TempData["ERROR"] = "Droits d'accès refusés";
                return RedirectToAction("Error", "Home");
            }
        }


        public async Task<string> GetRole()
        {
            string accessToken = await HttpContext.GetTokenAsync("access_token");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            string accessRight = null;

            // GET CONNECTED USER ID 
            string uriUserId = _configuration["URLApi"] + "api/AspNetUsers/UserId";
            string idUser = await _client.GetStringAsync(uriUserId);


            // GET CONNECTED USER ROLE
            string uriUserRole = _configuration["URLApi"] + "api/AspNetUserRoles/GetUserRole/";
            string userRole = await _client.GetStringAsync(uriUserRole);// HTTP GET


            if (userRole.ToUpper() == "ADMIN")
            {
                accessRight = "ADMIN";
            }
            else
            {
                accessRight = "OTHERS";
            }

            return accessRight;
        }



    }// End Class 
}
