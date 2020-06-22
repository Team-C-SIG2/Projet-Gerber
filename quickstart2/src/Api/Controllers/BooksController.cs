namespace Api.Controllers
{

    using Api.Models;
    using Api.ViewModel;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using NLog;
    using System;

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BooksController : ControllerBase
    {
        // NLog 
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        // //////////////////////////////////////////////////////////////////////////////////////////////////////// 
        // Initialize the Database Context  
        // //////////////////////////////////////////////////////////////////////////////////////////////////////// 
        private readonly ESBookshopContext _context;

        public BooksController(ESBookshopContext context)
        {
            _context = context;
        }


        // _______________________________________________________________________________________________________
        // COMMON PART 
        // _______________________________________________________________________________________________________

        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // GET: api/Books
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetAll()
        {
            // NLog 
            string message = $"(API Server) - Try to GET ALL books - Controller name: BooksController; Actionname: GetAll(); HTTP method : HttpGet; Time: " + DateTime.Now + "\n";
            _logger.Info(message);

            IQueryable<Book> books = null;
            try
            {
                books =
                    (from i in _context.Books
                     orderby i.Title ascending
                     select new Book()
                     {
                         Id = i.Id,
                         Isbn = i.Isbn,
                         IdEditor = i.IdEditor,
                         DatePublication = i.DatePublication,
                         Price = i.Price,
                         Subtitle = i.Subtitle,
                         Summary = i.Summary,
                         Title = i.Title,
                         Stock = i.Stock,
                         StockInitial = i.StockInitial,
                         IdEditorNavigation = (from e in _context.Editors where e.Id == i.IdEditor select e).FirstOrDefault(),
                         LineItems = (from l in _context.LineItems where l.IdBook == i.Id select l).ToList(),
                         StockHistories = (from s in _context.StockHistories where s.IdBook == i.Id select s).ToList(),
                         Ranks = (from r in _context.Ranks
                                  where r.IdBook == i.Id
                                  select new Rank()
                                  {
                                      IdBook = r.IdBook,
                                      IdCategorie = r.IdCategorie,
                                      IdGenre = r.IdGenre,
                                      IdFormat = r.IdFormat,
                                      IdLanguage = r.IdLanguage,
                                      IdCategorieNavigation = (from ca in _context.Categories where ca.Id == r.IdCategorie select ca).FirstOrDefault(),
                                      IdFormatNavigation = (from fo in _context.Formats where fo.Id == r.IdFormat select fo).FirstOrDefault(),
                                      IdLanguageNavigation = (from la in _context.Languages where la.Id == r.IdLanguage select la).FirstOrDefault(),
                                      IdGenreNavigation = (from ge in _context.Genres where ge.Id == r.IdGenre select ge).FirstOrDefault()
                                  }).ToList(),
                         Cowriters = (from c in _context.Cowriters
                                      where c.IdBook == i.Id
                                      select new Cowriter()
                                      {
                                          IdAuthor = c.IdAuthor,
                                          IdAuthorNavigation = (from a in _context.Authors where a.Id == c.IdAuthor select a).FirstOrDefault()
                                      }).ToList()
                     });

            }
            catch (Exception ex)
            {
                // NLog Framework Call 

                // LOG INFO 
                _logger.Info("INFORMATION DETAILS, Exception occured during operation : " + message);
                _logger.Info("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG WARN
                _logger.Warn("WARNING DETAILS, Exception occured during operation : " + message);
                _logger.Warn("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG ERROR
                _logger.Error("ERROR DETAILS, Exception occured during operation : " + message);
                _logger.Error("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG TRACE 
                _logger.Trace("WARNING DETAILS, Exception occured during operation : " + message);
                _logger.Trace("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG FATAL
                _logger.Fatal("FATAL DETAILS, Exception occured during operation : " + message);
                _logger.Fatal("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG DEGUG 
                _logger.Debug("DEGUG DETAILS, Exception occured during operation : " + message);
                _logger.Debug("EXCEPTION DETAILS: " + ex.Message + "\n");

                if (books == null)
                {
                    return NotFound();
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                }

            }

            return await books.ToListAsync();

        }

        // //////////////////////////////////////////////////////////////////////////////////////////////////////// 
        // GET: api/Books/5 
        // //////////////////////////////////////////////////////////////////////////////////////////////////////// 
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            // NLog Framework Call 
            string message = $"Log Information(API Server) -Try to get book " + id + "(Id) - Controller name : BooksController; Actionname: GetBook(...); HTTP method : HttpGet; Time: " + DateTime.Now + "\n";
            _logger.Info(message);

            Book book = new Book();
            try
            {
                book = (from i in _context.Books
                        where id == i.Id
                        select new Book()
                        {
                            Id = id,
                            Isbn = i.Isbn,
                            IdEditor = i.IdEditor,
                            DatePublication = i.DatePublication,
                            Price = i.Price,
                            Subtitle = i.Subtitle,
                            Summary = i.Summary,
                            Title = i.Title,
                            IdEditorNavigation = (from e in _context.Editors where e.Id == i.IdEditor select e).FirstOrDefault(),
                            LineItems = (from l in _context.LineItems where l.IdBook == i.Id select l).ToList()
                        }).FirstOrDefault();

                if (book == null)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {

                // NLog Framework Call 

                // LOG INFO 
                _logger.Info("INFORMATION DETAILS, Exception occured during operation : " + message);
                _logger.Info("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG WARN
                _logger.Warn("WARNING DETAILS, Exception occured during operation : " + message);
                _logger.Warn("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG ERROR
                _logger.Error("ERROR DETAILS, Exception occured during operation : " + message);
                _logger.Error("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG TRACE 
                _logger.Trace("WARNING DETAILS, Exception occured during operation : " + message);
                _logger.Trace("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG FATAL
                _logger.Fatal("FATAL DETAILS, Exception occured during operation : " + message);
                _logger.Fatal("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG DEGUG 
                _logger.Debug("DEGUG DETAILS, Exception occured during operation : " + message);
                _logger.Debug("EXCEPTION DETAILS: " + ex.Message + "\n");

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

            return book;
        }

        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // GET: api/Books/5
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////

        [Route("GetOneBook/{id}")]
        public async Task<ActionResult<Book>> GetOne(int id)
        {
            // NLog 
            string message = $"(API Server) -Try to GET book " + id + "(Id) - Controller name: BooksController; Actionname: GetBook(...); HTTP method : HttpGet; Time: " + DateTime.Now + "\n";
            _logger.Info(message);

            Book book = new Book();
            try
            {
                book = (from i in _context.Books
                        where id == i.Id
                        select new Book()
                        {
                            Id = i.Id,
                            Isbn = i.Isbn,
                            IdEditor = i.IdEditor,
                            DatePublication = i.DatePublication,
                            Price = i.Price,
                            Subtitle = i.Subtitle,
                            Summary = i.Summary,
                            Title = i.Title,
                            Stock = i.Stock, 
                            StockInitial = i.StockInitial,
                            StockHistories = (from s in _context.StockHistories where s.IdBook == i.Id select s).ToList(),
                            IdEditorNavigation = (from e in _context.Editors where e.Id == i.IdEditor select e).FirstOrDefault(),
                            LineItems = (from l in _context.LineItems where l.IdBook == i.Id select l).ToList(),
                            Ranks = (from r in _context.Ranks
                                     where r.IdBook == i.Id
                                     select new Rank()
                                     {
                                         IdBook = r.IdBook,
                                         IdCategorie = r.IdCategorie,
                                         IdGenre = r.IdGenre,
                                         IdFormat = r.IdFormat,
                                         IdLanguage = r.IdLanguage,
                                         IdCategorieNavigation = (from ca in _context.Categories where ca.Id == r.IdCategorie select ca).FirstOrDefault(),
                                         IdFormatNavigation = (from fo in _context.Formats where fo.Id == r.IdFormat select fo).FirstOrDefault(),
                                         IdLanguageNavigation = (from la in _context.Languages where la.Id == r.IdLanguage select la).FirstOrDefault(),
                                         IdGenreNavigation = (from ge in _context.Genres where ge.Id == r.IdGenre select ge).FirstOrDefault()
                                     }).ToList(),
                            Cowriters = (from c in _context.Cowriters
                                         where c.IdBook == i.Id
                                         select new Cowriter()
                                         {
                                             IdAuthor = c.IdAuthor,
                                             IdAuthorNavigation = (from a in _context.Authors where a.Id == c.IdAuthor select a).FirstOrDefault()
                                         }).ToList()
                        }).FirstOrDefault();
            }
            catch (Exception ex)
            {
                // NLog Framework Call 

                // LOG INFO 
                _logger.Info("INFORMATION DETAILS, Exception occured during operation : " + message);
                _logger.Info("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG WARN
                _logger.Warn("WARNING DETAILS, Exception occured during operation : " + message);
                _logger.Warn("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG ERROR
                _logger.Error("ERROR DETAILS, Exception occured during operation : " + message);
                _logger.Error("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG TRACE 
                _logger.Trace("WARNING DETAILS, Exception occured during operation : " + message);
                _logger.Trace("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG FATAL
                _logger.Fatal("FATAL DETAILS, Exception occured during operation : " + message);
                _logger.Fatal("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG DEGUG 
                _logger.Debug("DEGUG DETAILS, Exception occured during operation : " + message);
                _logger.Debug("EXCEPTION DETAILS: " + ex.Message + "\n");

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

            return book;
        }

        // //////////////////////////////////////////////////////////////////////////////////////////////////////// 
        // GET: .../ api/Books/GetUserShoppingCart/002078C2AB 
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////	 

        [Route("GetUserShoppingCart/{userId?}")]
        public async Task<ShoppingCart> GetUserShoppingCart(/*string? userId*/)
        {
            ShoppingCart shoppingCart = new ShoppingCart();
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // NLog 
            string message = $"(API Server) -Try to get User's shoppingCart - Controller name : BooksController; Actionname: GetUserShoppingCart(); HTTP method : HttpGet; Time: " + DateTime.Now + "\n";
            _logger.Info(message);

            try
            {
                shoppingCart = (from s in _context.ShoppingCarts
                                where userId == s.UserId
                                select new ShoppingCart()
                                {
                                    Id = s.Id,
                                    CreatedDate = s.CreatedDate,
                                    UserId = userId
                                }).FirstOrDefault();
            }
            catch (Exception ex)
            {
                // NLog Framework Call 

                // LOG INFO 
                _logger.Info("INFORMATION DETAILS, Exception occured during operation : " + message);
                _logger.Info("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG WARN
                _logger.Warn("WARNING DETAILS, Exception occured during operation : " + message);
                _logger.Warn("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG ERROR
                _logger.Error("ERROR DETAILS, Exception occured during operation : " + message);
                _logger.Error("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG TRACE 
                _logger.Trace("WARNING DETAILS, Exception occured during operation : " + message);
                _logger.Trace("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG FATAL
                _logger.Fatal("FATAL DETAILS, Exception occured during operation : " + message);
                _logger.Fatal("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG DEGUG 
                _logger.Debug("DEGUG DETAILS, Exception occured during operation : " + message);
                _logger.Debug("EXCEPTION DETAILS: " + ex.Message + "\n");
            }

            return shoppingCart;
        }

        // //////////////////////////////////////////////////////////////////////////////////////////////////////// 
        // POST: api/Books/postLineItem 
        // //////////////////////////////////////////////////////////////////////////////////////////////////////// 
        [HttpPost]
        [Route("AddLine")]
        [Authorize]
        public async Task<ActionResult<LineItem>> PostLineItem(LineItem lineItem)
        {
            // NLog 
            string message = $"(API Server) -Try to POST LineItem " + lineItem.Id + "(Id) - Controller name : BooksController; " +
                "Actionname: PostLineItem(...); HTTP method : HttpPost; Time: " + DateTime.Now + "\n";
            _logger.Info(message);

            LineItem line = null;
            try
            {
                line = new LineItem
                {
                    IdBook = lineItem.IdBook,
                    UnitPrice = lineItem.UnitPrice,
                    IdOrder = null,
                    InsertedDate = lineItem.InsertedDate,
                    Quantity = 1,
                    IdShoppingcart = lineItem.IdShoppingcart,
                    IdWishlist = lineItem.IdWishlist
                };

                _context.LineItems.Add(line);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // NLog Framework Call 

                // LOG INFO 
                _logger.Info("INFORMATION DETAILS, Exception occured during operation : " + message);
                _logger.Info("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG WARN
                _logger.Warn("WARNING DETAILS, Exception occured during operation : " + message);
                _logger.Warn("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG ERROR
                _logger.Error("ERROR DETAILS, Exception occured during operation : " + message);
                _logger.Error("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG TRACE 
                _logger.Trace("WARNING DETAILS, Exception occured during operation : " + message);
                _logger.Trace("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG FATAL
                _logger.Fatal("FATAL DETAILS, Exception occured during operation : " + message);
                _logger.Fatal("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG DEGUG 
                _logger.Debug("DEGUG DETAILS, Exception occured during operation : " + message);
                _logger.Debug("EXCEPTION DETAILS: " + ex.Message + "\n");

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

            return line;
        }

        // //////////////////////////////////////////////////////////////////////////////////////////////////////// 
        // Method for advanced search
        // //////////////////////////////////////////////////////////////////////////////////////////////////////// 
        [HttpPost]
        [Route("find")]
        public List<Book> Find(BookSearch searchedBook)
        {
            // NLog 
            string message = $"(API Server) -Try to FIND book ; Controller name : BooksController; Actionname: Find(...); HTTP method : HttpGet; Time: " + DateTime.Now + "\n\n";
            _logger.Info(message);

            List<Book> q = new List<Book>();
            try
            {
                StringComparison sc = StringComparison.OrdinalIgnoreCase;
                q = _context.Books.ToList();

                if (searchedBook.Isbn != null)
                {
                    q = (from b in q
                         where b.Isbn == searchedBook.Isbn
                         select b).ToList();
                }
                if (searchedBook.authorName != null)
                {
                    var contentCowriters = _context.Cowriters.ToList();
                    var contentAuthors = _context.Authors.ToList();
                    q = (from b in q
                         join cowriter in contentCowriters on b.Id equals cowriter.IdBook
                         join author in contentAuthors on cowriter.IdAuthor equals author.Id
                         where author.Firstname.Contains(searchedBook.authorName, sc)
                         || author.Lastname.Contains(searchedBook.authorName, sc)
                         || (author.Lastname + " " + author.Firstname).Contains(searchedBook.authorName, sc)
                         || (author.Firstname + " " + author.Lastname).Contains(searchedBook.authorName, sc)
                         select b).ToList();
                }
                if (searchedBook.category != 0)
                {
                    var contentRank = _context.Ranks.ToList();
                    q = (from b in q
                         join rank in contentRank on b.Id equals rank.IdBook
                         where rank.IdCategorie == searchedBook.category
                         select b).ToList();
                }
                if (searchedBook.Title != null)
                {
                    q = (from b in q
                         where b.Title.Contains(searchedBook.Title, sc)
                         select b).ToList();
                }
                if (searchedBook.Subtitle != null)
                {
                    q = (from b in q
                         where b.Subtitle.Contains(searchedBook.Subtitle, sc)
                         select b).ToList();
                }
                if (searchedBook.DatePublicationFrom != null)
                {
                    q = (from b in q
                         where b.DatePublication > searchedBook.DatePublicationFrom
                         select b).ToList();
                }
                if (searchedBook.DatePublicationTo != null)
                {
                    q = (from b in q
                         where b.DatePublication < searchedBook.DatePublicationTo
                         select b).ToList();
                }
                if (searchedBook.PriceFrom != null)
                {
                    q = (from b in q
                         where b.Price > searchedBook.PriceFrom
                         select b).ToList();
                }
                if (searchedBook.PriceTo != null)
                {
                    q = (from b in q
                         where b.Price < searchedBook.PriceTo
                         select b).ToList();
                }
                if (searchedBook.Summary != null)
                {
                    q = (from b in q
                         where b.Summary.Contains(searchedBook.Summary)
                         select b).ToList();
                }
                if (searchedBook.IdEditor != 0)
                {
                    q = (from b in q
                         where b.IdEditor == searchedBook.IdEditor
                         select b).ToList();
                }
            }
            catch (Exception ex)
            {
                // NLog Framework Call 

                // LOG INFO 
                _logger.Info("INFORMATION DETAILS, Exception occured during operation : " + message);
                _logger.Info("EXCEPTION DETAILS: " + ex.Message + "\n\n");

                // LOG WARN
                _logger.Warn("WARNING DETAILS, Exception occured during operation : " + message);
                _logger.Warn("EXCEPTION DETAILS: " + ex.Message + "\n\n");

                // LOG ERROR
                _logger.Error("ERROR DETAILS, Exception occured during operation : " + message);
                _logger.Error("EXCEPTION DETAILS: " + ex.Message + "\n\n");

                // LOG TRACE 
                _logger.Trace("WARNING DETAILS, Exception occured during operation : " + message);
                _logger.Trace("EXCEPTION DETAILS: " + ex.Message + "\n\n");

                // LOG FATAL
                _logger.Fatal("FATAL DETAILS, Exception occured during operation : " + message);
                _logger.Fatal("EXCEPTION DETAILS: " + ex.Message + "\n\n");

                // LOG DEGUG 
                _logger.Debug("DEGUG DETAILS, Exception occured during operation : " + message);
                _logger.Debug("EXCEPTION DETAILS: " + ex.Message + "\n\n");
            }

            return q;
        }


        // _______________________________________________________________________________________________________
        // ADMINISTRATION PART 
        // _______________________________________________________________________________________________________

        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Update an existing Book 
        // PUT: api/Books/5
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Book book)
        {
            // NLog 
            string message = $"(API Server) -Try to update book " + id + "(Id) - Controller : BooksController; " +
                "Actionname: Put(...); HTTP method : HttpGet; Time: " + DateTime.Now + "\n";
            _logger.Info(message);

            try
            {
                _context.Entry(book).State = EntityState.Modified;
                await _context.SaveChangesAsync();

            }
            catch (DbUpdateConcurrencyException ex)
            {
                // NLog Framework Call 

                // LOG INFO 
                _logger.Info("INFORMATION DETAILS, Exception occured during operation : " + message);
                _logger.Info("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG WARN
                _logger.Warn("WARNING DETAILS, Exception occured during operation : " + message);
                _logger.Warn("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG ERROR
                _logger.Error("ERROR DETAILS, Exception occured during operation : " + message);
                _logger.Error("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG TRACE 
                _logger.Trace("WARNING DETAILS, Exception occured during operation : " + message);
                _logger.Trace("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG FATAL
                _logger.Fatal("FATAL DETAILS, Exception occured during operation : " + message);
                _logger.Fatal("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG DEGUG 
                _logger.Debug("DEGUG DETAILS, Exception occured during operation : " + message);
                _logger.Debug("EXCEPTION DETAILS: " + ex.Message + "\n");

                if (id != book.Id)
                {
                    return BadRequest();
                }
                else
                {
                    return NotFound();
                }
            }

            return NoContent();
        }

        // //////////////////////////////////////////////////////////////////////////////////////////////////////// 
        // Verify if a Book existe  
        // //////////////////////////////////////////////////////////////////////////////////////////////////////// 
        private bool Exists(int id)
        {
            return _context.Books.Any(e => e.Id == id);
        }


        // //////////////////////////////////////////////////////////////////////////////////////////////////////// 
        // POST — create a new resource Book 
        // POST: api/Books 
        // //////////////////////////////////////////////////////////////////////////////////////////////////////// 
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Book>> Post(Book book)
        {
            // NLog 
            string message = $"Log Information(API Server) -Try to POST book " + book.Id + "(Id) - Controller : BooksController; " +
                "Actionname: Post(...); HTTP method : HttpPost; Time: " + DateTime.Now + "\n";
            _logger.Info(message);

            try
            {
                _context.Books.Add(book);
                await _context.SaveChangesAsync();

                _context.Entry(book).GetDatabaseValues();
                return CreatedAtAction("GetAll", new { id = book.Id }, book);
            }
            catch (Exception ex)
            {
                // NLog Framework Call 

                // LOG INFO 
                _logger.Info("INFORMATION DETAILS, Exception occured during operation : " + message);
                _logger.Info("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG WARN
                _logger.Warn("WARNING DETAILS, Exception occured during operation : " + message);
                _logger.Warn("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG ERROR
                _logger.Error("ERROR DETAILS, Exception occured during operation : " + message);
                _logger.Error("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG TRACE 
                _logger.Trace("WARNING DETAILS, Exception occured during operation : " + message);
                _logger.Trace("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG FATAL
                _logger.Fatal("FATAL DETAILS, Exception occured during operation : " + message);
                _logger.Fatal("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG DEGUG 
                _logger.Debug("DEGUG DETAILS, Exception occured during operation : " + message);
                _logger.Debug("EXCEPTION DETAILS: " + ex.Message + "\n");

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Delete a Book
        // DELETE: api/Books/5
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        [HttpDelete("{id}")]
        public async Task<ActionResult<Book>> Delete(int id)
        {
            // NLog 
            string message = $"(API Server) -Try to DELETE book " + id + "(Id) - Controller : BooksController; " +
                "Actionname: Delete(...); HTTP method : HttpDelete; Time: " + DateTime.Now + "\n";
            _logger.Info(message);

            Book book = null;
            try
            {
                // FIND Book 
                book = await _context.Books.FindAsync(id);

                // REMOVE Book
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();

                // GET UPDATED DB VALUES 
                _context.Entry(book).GetDatabaseValues();
            }
            catch (Exception ex)
            {
                // NLog Framework Call 

                // LOG INFO 
                _logger.Info("INFORMATION DETAILS, Exception occured during operation : " + message);
                _logger.Info("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG WARN
                _logger.Warn("WARNING DETAILS, Exception occured during operation : " + message);
                _logger.Warn("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG ERROR
                _logger.Error("ERROR DETAILS, Exception occured during operation : " + message);
                _logger.Error("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG TRACE 
                _logger.Trace("WARNING DETAILS, Exception occured during operation : " + message);
                _logger.Trace("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG FATAL
                _logger.Fatal("FATAL DETAILS, Exception occured during operation : " + message);
                _logger.Fatal("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG DEGUG 
                _logger.Debug("DEGUG DETAILS, Exception occured during operation : " + message);
                _logger.Debug("EXCEPTION DETAILS: " + ex.Message + "\n");

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

            }

            return book;
        }

        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // To Manage Editor(s)  of a selected Book 
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////	

        // ________________________________
        // Get Editor List 
        // ________________________________
        [Route("GetEditors")]
        public async Task<ActionResult<IEnumerable<Editor>>> GetEditors()
        {
            // NLog 
            string message = $"(API Server) -Try to GET Editors LIST - Controller : BooksController; Actionname: GetEditors(); HTTP method : HttpGet; Time: " + DateTime.Now + "\n";
            _logger.Info(message);

            IQueryable<Editor> editors = null;
            try
            {
                editors = (from e in _context.Editors select e);
            }
            catch (Exception ex)
            {

                // NLog Framework Call 

                // LOG INFO 
                _logger.Info("INFORMATION DETAILS, Exception occured during operation : " + message);
                _logger.Info("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG WARN
                _logger.Warn("WARNING DETAILS, Exception occured during operation : " + message);
                _logger.Warn("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG ERROR
                _logger.Error("ERROR DETAILS, Exception occured during operation : " + message);
                _logger.Error("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG TRACE 
                _logger.Trace("WARNING DETAILS, Exception occured during operation : " + message);
                _logger.Trace("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG FATAL
                _logger.Fatal("FATAL DETAILS, Exception occured during operation : " + message);
                _logger.Fatal("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG DEGUG 
                _logger.Debug("DEGUG DETAILS, Exception occured during operation : " + message);
                _logger.Debug("EXCEPTION DETAILS: " + ex.Message + "\n");

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

            }


            return await editors.ToListAsync();
        }

        // ________________________________
        // Get Editor E
        // ________________________________
        [Route("GetEditor")]
        public async Task<ActionResult<Editor>> GetEditor(string name)
        {
            // NLog 
            string message = $"(API Server) -Try to get Editor by its name (" + name + ") - Controller : BooksController; Actionname: GetEditor(...); HTTP method : HttpGet; Time: " + DateTime.Now + "\n";
            _logger.Info(message);


            Editor editor = new Editor();
            try
            {
                editor = (from e in _context.Editors where e.Name == name select e).FirstOrDefault();

            }
            catch (Exception ex)
            {
                // NLog Framework Call 

                // LOG INFO 
                _logger.Info("INFORMATION DETAILS, Exception occured during operation : " + message);
                _logger.Info("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG WARN
                _logger.Warn("WARNING DETAILS, Exception occured during operation : " + message);
                _logger.Warn("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG ERROR
                _logger.Error("ERROR DETAILS, Exception occured during operation : " + message);
                _logger.Error("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG TRACE 
                _logger.Trace("WARNING DETAILS, Exception occured during operation : " + message);
                _logger.Trace("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG FATAL
                _logger.Fatal("FATAL DETAILS, Exception occured during operation : " + message);
                _logger.Fatal("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG DEGUG 
                _logger.Debug("DEGUG DETAILS, Exception occured during operation : " + message);
                _logger.Debug("EXCEPTION DETAILS: " + ex.Message + "\n");

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

            return editor;
        }


        // ________________________________
        // Post Editor 
        // ________________________________
        [Route("PostEditor")]
        [HttpPost]
        public async Task<ActionResult<int>> PostEditor(Editor editor)
        {
            int id = 0;
            // NLog 
            string message = $"(API Server) -Try to POST Edidor " + editor.Name + " - Controller : BooksController; Actionname: PostEditor(...); HTTP method : HttpPost; Time: " + DateTime.Now + "\n";
            _logger.Info(message);


            try
            {
                if (editor != null)
                {
                    _context.Editors.Add(editor);
                    await _context.SaveChangesAsync();
                }

                _context.Entry(editor).GetDatabaseValues();
                id = editor.Id;

            }
            catch (Exception ex)
            {
                // NLog Framework Call 

                // LOG INFO 
                _logger.Info("INFORMATION DETAILS, Exception occured during operation : " + message);
                _logger.Info("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG WARN
                _logger.Warn("WARNING DETAILS, Exception occured during operation : " + message);
                _logger.Warn("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG ERROR
                _logger.Error("ERROR DETAILS, Exception occured during operation : " + message);
                _logger.Error("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG TRACE 
                _logger.Trace("WARNING DETAILS, Exception occured during operation : " + message);
                _logger.Trace("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG FATAL
                _logger.Fatal("FATAL DETAILS, Exception occured during operation : " + message);
                _logger.Fatal("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG DEGUG 
                _logger.Debug("DEGUG DETAILS, Exception occured during operation : " + message);
                _logger.Debug("EXCEPTION DETAILS: " + ex.Message + "\n");

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

            }

            return id;
        }


        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // To manage Authors of a selected Book 
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////	
        [Route("ManageCowriters/{id}")]
        public async Task<ActionResult<IEnumerable<Cowriter>>> ManageCowriters(int? id)
        {
            // NLog 
            string message = $"(API Server) -Try to GET Cowriters " + id + "(Id) - Controller : BooksController; Actionname: ManageCowriters(...); HTTP method : HttpGet; Time: " + DateTime.Now + "\n";
            _logger.Info(message);

            IQueryable<Cowriter> cowriters = null;
            try
            {

                cowriters =
                    (from c in _context.Cowriters
                     where c.IdBook == id
                     select new Cowriter()
                     {
                         IdBook = c.IdBook,
                         IdAuthor = c.IdAuthor,
                         IdAuthorNavigation = (from a in _context.Authors where a.Id == c.IdAuthor select a).FirstOrDefault(),
                         IdBookNavigation = (from b in _context.Books where b.Id == c.IdBook select b).FirstOrDefault()
                     }

                     );
            }
            catch (Exception ex)
            {

                // NLog Framework Call 

                // LOG INFO 
                _logger.Info("INFORMATION DETAILS, Exception occured during operation : " + message);
                _logger.Info("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG WARN
                _logger.Warn("WARNING DETAILS, Exception occured during operation : " + message);
                _logger.Warn("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG ERROR
                _logger.Error("ERROR DETAILS, Exception occured during operation : " + message);
                _logger.Error("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG TRACE 
                _logger.Trace("WARNING DETAILS, Exception occured during operation : " + message);
                _logger.Trace("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG FATAL
                _logger.Fatal("FATAL DETAILS, Exception occured during operation : " + message);
                _logger.Fatal("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG DEGUG 
                _logger.Debug("DEGUG DETAILS, Exception occured during operation : " + message);
                _logger.Debug("EXCEPTION DETAILS: " + ex.Message + "\n");

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

            }

            return await cowriters.ToListAsync();
        }

        // ________________________________
        // Post Cowriter 
        // ________________________________
        [Route("PostCowriter")]
        [HttpPost]
        public async Task<ActionResult<int>> PostCowriter(Cowriter cowriter)
        {
            // NLog 
            string message = $"(API Server) -Try to POST Cowriter " + cowriter.IdAuthor + " (Id)  for book " + cowriter.IdBook + "(Id) - Controller : BooksController; Actionname: PostCowriter(...); HTTP method : HttpPost; Time: " + DateTime.Now + "\n";
            _logger.Info(message);

            int id = 0;
            try
            {
                if (cowriter != null)
                {
                    _context.Cowriters.Add(cowriter);
                    await _context.SaveChangesAsync();
                }

                // GET UPDATED DB VALUES 
                _context.Entry(cowriter).GetDatabaseValues();

                id = cowriter.IdBook;

            }
            catch (Exception ex)
            {
                // NLog Framework Call 

                // LOG INFO 
                _logger.Info("INFORMATION DETAILS, Exception occured during operation : " + message);
                _logger.Info("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG WARN
                _logger.Warn("WARNING DETAILS, Exception occured during operation : " + message);
                _logger.Warn("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG ERROR
                _logger.Error("ERROR DETAILS, Exception occured during operation : " + message);
                _logger.Error("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG TRACE 
                _logger.Trace("WARNING DETAILS, Exception occured during operation : " + message);
                _logger.Trace("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG FATAL
                _logger.Fatal("FATAL DETAILS, Exception occured during operation : " + message);
                _logger.Fatal("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG DEGUG 
                _logger.Debug("DEGUG DETAILS, Exception occured during operation : " + message);
                _logger.Debug("EXCEPTION DETAILS: " + ex.Message + "\n");

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

            return id;
        }

        // ________________________________
        // Get Cowriter  
        // ________________________________
        [Route("GetCowriter/{id}")]
        public async Task<ActionResult<Cowriter>> GetCowriter(int? id)
        {
            // NLog 
            string message = $"(API Server) -Try to get Cowriter " + id + "(Id) - Controller : BooksController; Actionname: GetCowriter(...); HTTP method : HttpGet; Time: " + DateTime.Now + "\n";
            _logger.Info(message);

            Cowriter cowriter = new Cowriter();
            try
            {
                cowriter =
                    (from c in _context.Cowriters
                     where c.IdAuthor == id
                     select new Cowriter()
                     {
                         IdBook = c.IdBook,
                         IdAuthor = c.IdAuthor,
                         IdAuthorNavigation = (from a in _context.Authors where a.Id == c.IdAuthor select a).FirstOrDefault(),
                         IdBookNavigation = (from b in _context.Books where b.Id == c.IdBook select b).FirstOrDefault()
                     }

                     ).FirstOrDefault();

            }
            catch (Exception ex)
            {
                // NLog Framework Call 

                // LOG INFO 
                _logger.Info("INFORMATION DETAILS, Exception occured during operation : " + message);
                _logger.Info("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG WARN
                _logger.Warn("WARNING DETAILS, Exception occured during operation : " + message);
                _logger.Warn("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG ERROR
                _logger.Error("ERROR DETAILS, Exception occured during operation : " + message);
                _logger.Error("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG TRACE 
                _logger.Trace("WARNING DETAILS, Exception occured during operation : " + message);
                _logger.Trace("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG FATAL
                _logger.Fatal("FATAL DETAILS, Exception occured during operation : " + message);
                _logger.Fatal("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG DEGUG 
                _logger.Debug("DEGUG DETAILS, Exception occured during operation : " + message);
                _logger.Debug("EXCEPTION DETAILS: " + ex.Message + "\n");

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }


            return cowriter;
        }

        // ________________________________
        // Delete Cowriter  
        // ________________________________
        [HttpDelete]
        [Route("DeleteCowriter/{idAuthor:int}/{idBook:int}")]
        public async Task<ActionResult<Cowriter>> DeleteCowriter(int? idAuthor, int? idBook)
        {
            // NLog 
            string message = $"(API Server) -Try to DELETE Cowriter " + idAuthor + " (Id)  for book " + idBook + "(Id) - Controller : BooksController; Actionname: DeleteCowriter(...); HTTP method : HttpDelete; Time: " + DateTime.Now + "\n";
            _logger.Info(message);

            Cowriter cowriter = new Cowriter();
            try
            {
                // LINQ Query Syntax to find out teenager students
                cowriter = (from c in _context.Cowriters
                            where c.IdAuthor == idAuthor && c.IdBook == idBook
                            select c).FirstOrDefault();

                if (cowriter != null)
                {
                    // REMOVE Book
                    _context.Cowriters.Remove(cowriter);
                    await _context.SaveChangesAsync();


                    // GET UPDATED DB VALUES 
                    _context.Entry(cowriter).GetDatabaseValues();

                }
            }
            catch (Exception ex)
            {
                // NLog Framework Call 

                // LOG INFO 
                _logger.Info("INFORMATION DETAILS, Exception occured during operation : " + message);
                _logger.Info("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG WARN
                _logger.Warn("WARNING DETAILS, Exception occured during operation : " + message);
                _logger.Warn("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG ERROR
                _logger.Error("ERROR DETAILS, Exception occured during operation : " + message);
                _logger.Error("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG TRACE 
                _logger.Trace("WARNING DETAILS, Exception occured during operation : " + message);
                _logger.Trace("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG FATAL
                _logger.Fatal("FATAL DETAILS, Exception occured during operation : " + message);
                _logger.Fatal("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG DEGUG 
                _logger.Debug("DEGUG DETAILS, Exception occured during operation : " + message);
                _logger.Debug("EXCEPTION DETAILS: " + ex.Message + "\n");

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

            return cowriter;
        }

        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // GET Authors List for DropDownList / SelectList (View MVC : CreateCowriter)
        // GET: AdminBooks/GetAuthors
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        [Route("GetAuthors")]
        public async Task<ActionResult<IEnumerable<Author>>> GetAuthors()
        {
            // NLog 
            string message = $"(API Server) -Try to GET Authors LIST - Controller : BooksController; Actionname: GetAuthors(...); HTTP method : HttpGet; Time: " + DateTime.Now + "\n";
            _logger.Info(message);

            IQueryable<Author> authors = null;
            try
            {
                authors =
                    (from c in _context.Authors
                     select new Author()
                     {
                         Id = c.Id,
                         Firstname = c.Firstname,
                         Lastname = c.Lastname
                     }

                     );
            }
            catch (Exception ex)
            {
                // NLog Framework Call 

                // LOG INFO 
                _logger.Info("INFORMATION DETAILS, Exception occured during operation : " + message);
                _logger.Info("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG WARN
                _logger.Warn("WARNING DETAILS, Exception occured during operation : " + message);
                _logger.Warn("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG ERROR
                _logger.Error("ERROR DETAILS, Exception occured during operation : " + message);
                _logger.Error("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG TRACE 
                _logger.Trace("WARNING DETAILS, Exception occured during operation : " + message);
                _logger.Trace("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG FATAL
                _logger.Fatal("FATAL DETAILS, Exception occured during operation : " + message);
                _logger.Fatal("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG DEGUG 
                _logger.Debug("DEGUG DETAILS, Exception occured during operation : " + message);
                _logger.Debug("EXCEPTION DETAILS: " + ex.Message + "\n");

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

            return await authors.ToListAsync();
        }

        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Manage Categories
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // ____________________________________________
        // Delete Book's Categorie (from Ranks Table)  
        // ____________________________________________
        [HttpDelete]
        [Route("DeleteCategorie/{IdCategorie:int}/{idBook:int}")]
        public async Task<ActionResult<Rank>> DeleteCategorie(int? IdCategorie, int? idBook)
        {
            // NLog 
            string message = $"(API Server) -Try to DELETE Categorie " + IdCategorie + " (Id)  for book " + idBook + "(Id) - Controller : BooksController; " +
                "Actionname: DeleteCategorie(...); HTTP method : HttpDelete; Time: " + DateTime.Now + "\n";
            _logger.Info(message);

            Rank rank = new Rank();
            try
            {
                // LINQ Query Syntax to find out teenager students
                rank = (from c in _context.Ranks
                        where c.IdCategorie == IdCategorie && c.IdBook == idBook
                        select c).FirstOrDefault();

                if (rank != null)
                {
                    // REMOVE Book
                    _context.Ranks.Remove(rank);
                    await _context.SaveChangesAsync();


                    // GET UPDATED DB VALUES 
                    _context.Entry(rank).GetDatabaseValues();

                }
            }
            catch (Exception ex)
            {
                // NLog Framework Call 

                // LOG INFO 
                _logger.Info("INFORMATION DETAILS, Exception occured during operation : " + message);
                _logger.Info("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG WARN
                _logger.Warn("WARNING DETAILS, Exception occured during operation : " + message);
                _logger.Warn("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG ERROR
                _logger.Error("ERROR DETAILS, Exception occured during operation : " + message);
                _logger.Error("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG TRACE 
                _logger.Trace("WARNING DETAILS, Exception occured during operation : " + message);
                _logger.Trace("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG FATAL
                _logger.Fatal("FATAL DETAILS, Exception occured during operation : " + message);
                _logger.Fatal("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG DEGUG 
                _logger.Debug("DEGUG DETAILS, Exception occured during operation : " + message);
                _logger.Debug("EXCEPTION DETAILS: " + ex.Message + "\n");

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

            return rank;
        }

        // ________________________________
        // Post Categorie 
        // ________________________________

        // [HttpPost, Route("~/api/tests/save/{id}")]
        [Route("PostCategorie/{idBook}")]
        [HttpPost]
        public async Task<ActionResult<bool>> PostCategorie(int? idBook, Rank rank)
        {
            // NLog 
            string message = $"(API Server) -Try to POST a Categorie (Rank) for selected book - Controller : BooksController; " +
                "Actionname: PostCategorie(...); HTTP method : HttpPost; Time: " + DateTime.Now + "\n";
            _logger.Info(message);

            bool resultat = false;
            try
            {
                //, Category categorie) 
                if (rank.IdBook == idBook)
                {
                    _context.Ranks.Add(rank);
                    await _context.SaveChangesAsync();
                    // GET UPDATED DB VALUES 
                    _context.Entry(rank).GetDatabaseValues();

                    resultat = true;
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                // NLog Framework Call 

                // LOG INFO 
                _logger.Info("INFORMATION DETAILS, Exception occured during operation : " + message);
                _logger.Info("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG WARN
                _logger.Warn("WARNING DETAILS, Exception occured during operation : " + message);
                _logger.Warn("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG ERROR
                _logger.Error("ERROR DETAILS, Exception occured during operation : " + message);
                _logger.Error("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG TRACE 
                _logger.Trace("WARNING DETAILS, Exception occured during operation : " + message);
                _logger.Trace("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG FATAL
                _logger.Fatal("FATAL DETAILS, Exception occured during operation : " + message);
                _logger.Fatal("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG DEGUG 
                _logger.Debug("DEGUG DETAILS, Exception occured during operation : " + message);
                _logger.Debug("EXCEPTION DETAILS: " + ex.Message + "\n");

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

            return resultat;
        }

        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // BOOL : Exists?
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        [Route("booksReviews/{id}")]
        public async Task<List<BookReviews>> GetBookReviews(int id)
        {
            // NLog 
            string message = $"(API Server) -Try to GET Reviews for book " + id + " (Id) - Controller : BooksController; " +
                "Actionname: GetBookReviews(...); HTTP method : HttpGet; Time: " + DateTime.Now + "\n";
            _logger.Info(message);

            List<BookReviews> reviews;
            try
            {
                reviews = await (from i in _context.Books
                                 join j in _context.Reviews on i.Id equals j.BookId
                                 join k in _context.AspNetUsers on j.UserId equals k.Id
                                 where i.Id == id
                                 select new BookReviews { Id = j.Id, BookId = i.Id, UserId = k.Id, Description = j.Description, Note = j.Note, Date = j.Date, Username = k.Username }).ToListAsync();
            }
            catch (Exception ex)
            {
                // NLog Framework Call 

                // LOG INFO 
                _logger.Info("INFORMATION DETAILS, Exception occured during operation : " + message);
                _logger.Info("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG WARN
                _logger.Warn("WARNING DETAILS, Exception occured during operation : " + message);
                _logger.Warn("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG ERROR
                _logger.Error("ERROR DETAILS, Exception occured during operation : " + message);
                _logger.Error("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG TRACE 
                _logger.Trace("WARNING DETAILS, Exception occured during operation : " + message);
                _logger.Trace("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG FATAL
                _logger.Fatal("FATAL DETAILS, Exception occured during operation : " + message);
                _logger.Fatal("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG DEGUG 
                _logger.Debug("DEGUG DETAILS, Exception occured during operation : " + message);
                _logger.Debug("EXCEPTION DETAILS: " + ex.Message + "\n");

                return reviews = null;
            }
            return reviews;
        }

        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // BOOL : Exists?
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////

        [Route("ratingReviews/{id}")]
        public async Task<float> GetRatingReviews(int id)
        {
            // NLog 
            string message = $"(API Server) -Try to GET Review's rating for book " + id + " (Id) - Controller : BooksController; " +
                "Actionname: GetBookReviews(...); HTTP method : HttpGet; Time: " + DateTime.Now + "\n";
            _logger.Info(message);
            float moyenne = 0;
            int somme = 0;
            try
            {
                var listNotes = await (from i in _context.Books
                                       join j in _context.Reviews on i.Id equals j.BookId
                                       where i.Id == id
                                       select j.Note).ToListAsync();

                if (listNotes.Count() == 0)
                {
                    somme = 0;
                }
                else
                {
                    for (int i = 0; i < listNotes.Count(); i++)
                    {
                        somme += listNotes[i];
                    }
                    moyenne = (float)somme / (float)listNotes.Count();
                }
            }
            catch (Exception ex)
            {
                // NLog Framework Call 

                // LOG INFO 
                _logger.Info("INFORMATION DETAILS, Exception occured during operation : " + message);
                _logger.Info("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG WARN
                _logger.Warn("WARNING DETAILS, Exception occured during operation : " + message);
                _logger.Warn("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG ERROR
                _logger.Error("ERROR DETAILS, Exception occured during operation : " + message);
                _logger.Error("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG TRACE 
                _logger.Trace("WARNING DETAILS, Exception occured during operation : " + message);
                _logger.Trace("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG FATAL
                _logger.Fatal("FATAL DETAILS, Exception occured during operation : " + message);
                _logger.Fatal("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG DEGUG 
                _logger.Debug("DEGUG DETAILS, Exception occured during operation : " + message);
                _logger.Debug("EXCEPTION DETAILS: " + ex.Message + "\n");

                return moyenne = 0;
            }
            return moyenne;
        }

    }// End Class  
}
