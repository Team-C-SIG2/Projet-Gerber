namespace AppWebClient.Controllers
{

    using AppWebClient.Models;

    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Net;
    using System.Text;


    public class AdminBooksController : Controller
    {
        // HTTPCLIENT 
        private HttpClient _client = new HttpClient();

        // URL 
        private string _url = "api/AdminBooks/";


        //TO GET DATA FROM JSON FILE CONFIGURATION  
        private readonly IConfiguration _configuration;

        public AdminBooksController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // READ: Return the Books list 
        // GET: .../api/AdminBooks
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<IActionResult> Index()
        {
            string accessToken = await HttpContext.GetTokenAsync("access_token");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            string content = await _client.GetStringAsync(_configuration["URLApi"] + _url);

            List<Book> books = JsonConvert.DeserializeObject<List<Book>>(content);

            if (books == null)
            {
                return NotFound();
            }

            return View(books);
        }

        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Get the Details of a resource Book (by id)
        // GET : Books/Details/5
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<IActionResult> Details(int? id)
        {
            string accessToken = await HttpContext.GetTokenAsync("access_token");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            string content = await _client.GetStringAsync(_configuration["URLApi"] + _url + id);

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

            string accessToken = await HttpContext.GetTokenAsync("access_token");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            HttpResponseMessage responseEditor = await _client.GetAsync(_configuration["URLApi"] + uriEditors);// HTTP GET

            // GET EDITOR SELECTLIST 
            if (responseEditor.IsSuccessStatusCode)
            {
                editors = await responseEditor.Content.ReadAsAsync<List<Editor>>();
               ViewData["EDITEURS"]  = new SelectList(editors, "Id", "Name", book.IdEditor);// Add To ViewData
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
            return RedirectToAction("Index", "AdminBooks");

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
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            
            string uri = _url + id;
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
        // UPDATE : Update a Books ->  <form asp-action="Put">
        // PUT: / api/AdminBooks/S
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

            return RedirectToAction("Index", "AdminBooks");
        }



        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // To Create a new Editor 
        // POST: AdminBooks/PostEditor
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
            HttpResponseMessage responsePostEditor = await _client.PostAsJsonAsync(_configuration["URLApi"] + _url+"PostEditor", postEditor);

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
            return RedirectToAction("Index", "AdminBooks");

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
            string uri = _url + id;
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

            response.EnsureSuccessStatusCode();

            return RedirectToAction("Index", "AdminBooks");
        }



        // ------------------------------------------------------------------
        // CONTROL CONNECTED USER ROLE (ACCES RIGHTS)
        // ------------------------------------------------------------------

        [Route("VerifyRole")]
        public async Task<IActionResult> VerifyRole()
        {
            string accessToken = await HttpContext.GetTokenAsync("access_token");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);


            // GET CONNECTED USER ID 
            string uriUserId = _configuration["URLApi"] + "api/AspNetUsers/UserId";
            string idUser = await _client.GetStringAsync(uriUserId);
            ViewBag.USERID = idUser;


            // GET CONNECTED USER ROLE
            string uriUserRole = _configuration["URLApi"] + "api/AspNetUserRoles/GetUserRole/";
            string userRole = await _client.GetStringAsync(uriUserRole);// HTTP GET
            ViewBag.ROLE = userRole;


            if (userRole.ToUpper() == "ADMIN")
            {
                return RedirectToAction("AdminAccess", "AdminBooks");  // ACCESS DASHBOARD
            }
            else
            {
                TempData["ERROR"] = "Droits d'accès refusés"; 
                return RedirectToAction("Error", "Home");

            }

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
        public async Task<IActionResult> ManageCowriters(int? id , string title)
        {
            string accessToken = await HttpContext.GetTokenAsync("access_token");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            string content = await _client.GetStringAsync(_configuration["URLApi"] + _url + "ManageCowriters/" + id);

            List<Cowriter> cowriters = JsonConvert.DeserializeObject<List<Cowriter>>(content);

            if (cowriters == null)
            {
                return NotFound();
            }


            ViewData["BOOKID"] = id;
            ViewData["BOOKTITLE"] = title;

            return View(cowriters);
        }



        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // To Add new Cowriter 
        // POST: AdminBooks/CreateCowriter
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
            return RedirectToAction("Index", "AdminBooks");

        }






    }// End Class 
}
