namespace Api.Controllers
{

    using Api.Models;
    using System;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;


    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AdminBooksController : ControllerBase
    {

        // //////////////////////////////////////////////////////////////////////////////////////////////////////// 
        // Initialize the Database Context  
        // //////////////////////////////////////////////////////////////////////////////////////////////////////// 
        private readonly ESBookshopContext _context;

        public AdminBooksController(ESBookshopContext context)
        {
            _context = context;
        }


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
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return book;

        }


        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Verify if a Book existe 
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        private bool Exists(int id)
        {
            return _context.Books.Any(e => e.Id == id);
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
        public async Task<ActionResult<Editor>> GetEditor( string name)
        {
            Editor editor = (from e in _context.Editors where e.Name == name select e).FirstOrDefault();
            return  editor;
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
                     IdBookNavigation = (from b in _context.Books where b.Id == c.IdAuthor select b).FirstOrDefault()
                 }
                 
                 ).ToListAsync();

            return await cowriters;
        }



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



        [Route("PostCowriter")]
        [HttpPost]
        public async Task<ActionResult<int>> PostCowriter(Cowriter  cowriter)
        {
            if (cowriter != null)
            {
                _context.Cowriters.Add(cowriter);
                await _context.SaveChangesAsync();
            }

            _context.Entry(cowriter).GetDatabaseValues();
            int id = cowriter.IdBook;

            return id;
        }




    }// End Class 
}

