using Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;


namespace Api.Controllers
{
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



        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Return the list of all Books 
        // GET: api/Books
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            return await _context.Books.ToListAsync();

            /*
            var books =
                (from i in _context.Books
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
                 });

            if (books == null)
            {
                return NotFound();
            }

            return await books.ToListAsync();
            */
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
        // Update an existing Book 
        // PUT: api/Books/5
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////

        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(int id, Book book)
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
                if (!BookExists(id))
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

        [HttpPost]
        public async Task<ActionResult<Book>> PostBook(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBook", new { id = book.Id }, book);
        }


        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Delete a Book
        // DELETE: api/Books/5
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // DELETE: api/Books/5

        [HttpDelete("{id}")]
        public async Task<ActionResult<Book>> DeleteBook(int id)
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
        private bool BookExists(int id)
        {
            return _context.Books.Any(e => e.Id == id);
        }


        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Send the List of Editors for the Create View
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////	

        [Route("GetEditors")]
        public async Task<ActionResult<IEnumerable<Editor>>> GetEditors()
        {
            var editors = (from e in _context.Editors select e).ToListAsync();
            return await editors;
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
            };




            _context.LineItems.Add(line);
            await _context.SaveChangesAsync();

            return line;
            // return CreatedAtAction("AddItem", new { id = lineItem.Id }, line);


        }


    }// End Class 
}
 