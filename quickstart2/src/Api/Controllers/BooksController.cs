


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

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BooksController : ControllerBase
    {


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
        // Return the list of all Books 
        // GET: api/Books
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetAll()
        {
            var books =
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
                     IdEditorNavigation = (from e in _context.Editors where e.Id == i.IdEditor select e).FirstOrDefault(),
                     Cowriters = (from c in _context.Cowriters
                                  where c.IdBook == i.Id
                                  select new Cowriter()
                                  {
                                      IdAuthor = c.IdAuthor,
                                      IdAuthorNavigation = (from a in _context.Authors where a.Id == c.IdAuthor select a).FirstOrDefault()
                                  }).ToList()
                 });

            if (books == null)
            {
                return NotFound();
            }

            return await books.ToListAsync();

        }


        // //////////////////////////////////////////////////////////////////////////////////////////////////////// 
        // Return a Book (id) 
        // GET: api/Books/5 
        // //////////////////////////////////////////////////////////////////////////////////////////////////////// 

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            var book = (from i in _context.Books
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

            return book;
        }

        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Return a Book (id)
        // GET: api/Books/5
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////

        [Route("GetOneBook/{id}")]
        public async Task<ActionResult<Book>> GetOne(int id)
        {
            var book = (from i in _context.Books
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
                            LineItems = (from l in _context.LineItems where l.IdBook == i.Id select l).ToList(),
                            Cowriters = (from c in _context.Cowriters
                                         where c.IdBook == i.Id
                                         select new Cowriter()
                                         {
                                             IdAuthor = c.IdAuthor,
                                             IdAuthorNavigation = (from a in _context.Authors where a.Id == c.IdAuthor select a).FirstOrDefault()
                                         }).ToList()
                        }).FirstOrDefault();

            if (book == null)
            {
                return NotFound();
            }

            return book;
        }


        // //////////////////////////////////////////////////////////////////////////////////////////////////////// 
        // GET the shoppingcart by UserID 
        // GET: .../ api/Books/GetUserShoppingCart/002078C2AB 
        // https://localhost:44318/api/Books/GetUserShoppingCart/002078C2AB 
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////	 

        [Route("GetUserShoppingCart/{userId?}")]
        public async Task<ShoppingCart> GetUserShoppingCart(/*string? userId*/)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            ShoppingCart shoppingCart = (from s in _context.ShoppingCarts
                                         where userId == s.UserId
                                         select new ShoppingCart()
                                         {
                                             Id = s.Id,
                                             CreatedDate = s.CreatedDate,
                                             UserId = userId
                                         }).FirstOrDefault();

            return shoppingCart;
        }



        // //////////////////////////////////////////////////////////////////////////////////////////////////////// 
        // POST — Add a Book to a new resource LineItem 
        // POST: api/Books/postLineItem 
        // //////////////////////////////////////////////////////////////////////////////////////////////////////// 


        [HttpPost]
        [Route("AddLine")]
        [Authorize]
        public async Task<ActionResult<LineItem>> PostLineItem(LineItem lineItem)
        {

            LineItem line = new LineItem
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

            return line;
            // return CreatedAtAction("AddItem", new { id = lineItem.Id }, line); 


        }



        // //////////////////////////////////////////////////////////////////////////////////////////////////////// 
        // Method for advanced search
        // //////////////////////////////////////////////////////////////////////////////////////////////////////// 

        [HttpPost]
        [Route("find")]
        public List<Book> Find(BookSearch searchedBook)
        {
            StringComparison sc = StringComparison.OrdinalIgnoreCase;
            var q = _context.Books.ToList();

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
            if (id != book.Id)
            {
                return BadRequest();
            }

            _context.Entry(book).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Exists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
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
            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            _context.Entry(book).GetDatabaseValues();
            return CreatedAtAction("GetAll", new { id = book.Id }, book);
        }


        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Delete a Book
        // DELETE: api/Books/5
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////

        [HttpDelete("{id}")]
        public async Task<ActionResult<Book>> Delete(int id)
        {

            // FIND Book 
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            // REMOVE Book
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            // GET UPDATED DB VALUES 
            _context.Entry(book).GetDatabaseValues();


            return book;

        }


        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // To Manage Editor(s)  of a selected Book 
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////	

        [Route("GetEditors")]
        public async Task<ActionResult<IEnumerable<Editor>>> GetEditors()
        {
            var editors = (from e in _context.Editors select e).ToListAsync();
            return await editors;
        }


        [Route("GetEditor")]
        public async Task<ActionResult<Editor>> GetEditor(string name)
        {
            Editor editor = (from e in _context.Editors where e.Name == name select e).FirstOrDefault();
            return editor;
        }


        [Route("PostEditor")]
        [HttpPost]
        public async Task<ActionResult<int>> PostEditor(Editor editor)
        {
            if (editor != null)
            {
                _context.Editors.Add(editor);
                await _context.SaveChangesAsync();
            }

            _context.Entry(editor).GetDatabaseValues();
            int id = editor.Id;

            return id;
        }

        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // To manage Authors of a selected Book 
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////	
        [Route("ManageCowriters/{id}")]
        public async Task<ActionResult<IEnumerable<Cowriter>>> ManageCowriters(int? id)
        {

            var cowriters =
                (from c in _context.Cowriters
                 where c.IdBook == id
                 select new Cowriter()
                 {
                     IdBook = c.IdBook,
                     IdAuthor = c.IdAuthor,
                     IdAuthorNavigation = (from a in _context.Authors where a.Id == c.IdAuthor select a).FirstOrDefault(),
                     IdBookNavigation = (from b in _context.Books where b.Id == c.IdBook select b).FirstOrDefault()
                 }

                 ).ToListAsync();

            return await cowriters;
        }


        // [HttpPost, Route("~/api/tests/save/{id}")]
        [Route("PostCowriter")]
        [HttpPost]
        public async Task<ActionResult<int>> PostCowriter(Cowriter cowriter)
        {
            if (cowriter != null)
            {
                _context.Cowriters.Add(cowriter);
                await _context.SaveChangesAsync();
            }

            // GET UPDATED DB VALUES 
            _context.Entry(cowriter).GetDatabaseValues();

            int id = cowriter.IdBook;

            return id;
        }



        [Route("GetCowriter/{id}")]
        public async Task<ActionResult<Cowriter>> GetCowriter(int? id)
        {
            var cowriter =
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


            return cowriter;
        }



        [HttpDelete]
        [Route("DeleteCowriter/{idAuthor:int}/{idBook:int}")]
        public async Task<ActionResult<Cowriter>> DeleteCowriter(int? idAuthor, int? idBook) 
        {
            // LINQ Query Syntax to find out teenager students
            var cowriter = (from c in _context.Cowriters
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
            else
            {
                return NotFound();
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
            var authors =
                (from c in _context.Authors
                 select new Author()
                 {
                     Id = c.Id,
                     Firstname = c.Firstname,
                     Lastname = c.Lastname
                 }

                 ).ToListAsync();

            return await authors;
        }



    }// End Class  
}
