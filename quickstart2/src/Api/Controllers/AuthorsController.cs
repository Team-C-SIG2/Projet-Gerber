namespace Api.Controllers
{
    using Api.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Data.SqlClient;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using NLog;
    using System;
    using Microsoft.AspNetCore.Http;

    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {

        // NLog 
        private static Logger _logger = LogManager.GetCurrentClassLogger();


        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Initialize the Database Context 
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        private readonly ESBookshopContext _context;

        public AuthorsController(ESBookshopContext context)
        {
            _context = context;
        }

        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // GET: api/Authors
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Author>>> GetAuthors()
        {

            // NLog 
            string message = $"(API Server) - Try to GET ALL Authors - Controller name: AuthorsController; " +
                $"Actionname: GetAuthors(); HTTP method : HttpGet; Time: " + DateTime.Now + "\n";
            _logger.Info(message);

            IQueryable<Author> authors = null;
            try
            {
                authors = _context.Authors;
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

                if (authors == null)
                {
                    return NotFound();
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                }
            }

            return await authors.ToListAsync();
        }

        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // GET: api/Authors/5
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        [HttpGet("{id}")]
        public async Task<ActionResult<Author>> GetAuthors(int id)
        {


            // NLog 
            string message = $"(API Server) -Try to GET Author " + id + "(Id) - Controller name: AuthorsController; " +
                "Actionname: GetAuthors(...); HTTP method : HttpGet; Time: " + DateTime.Now + "\n\n";
            _logger.Info(message);


            Author author = new Author();
            try
            {
                author = await _context.Authors.FindAsync(id);
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

                if (author != null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                }
                else
                {
                    return NotFound();
                }
            }

            return author;
        }

        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // GET: api/Authors/5
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        [Route("authorBooks/{id}")]
        public async Task<List<AuthorBooks>> GetAuthorBooks(int id)
        {

            // NLog 
            string message = $"(API Server) - Try to GET ALL Books of Author " + id + " (id) - Controller name: AuthorsController; " +
                $"Actionname: GetAuthorBooks(); HTTP method : HttpGet; Time: " + DateTime.Now + "\n";
            _logger.Info(message);

            IQueryable<AuthorBooks> books = null;
            try
            {
                books = (from i in _context.Authors
                         join j in _context.Cowriters on i.Id equals j.IdAuthor
                         join k in _context.Books on j.IdBook equals k.Id
                         join l in _context.Editors on k.IdEditor equals l.Id
                         where i.Id == id
                         select new AuthorBooks { Title = k.Title, BookId = k.Id, EditorName = l.Name, EditorUrl = l.Url, EditorEmail = l.Email });

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


            return await books.ToListAsync();
        }

        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // PUT: api/Authors/5
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuthors(int id, Author authors)
        {
            // NLog 
            string message = $"(API Server) -Try to PUT (update) Author " + authors.Id + "(Id) - Controller : AuthorsController; " +
                "Actionname: PutAuthors(...); HTTP method : HttpPut; Time: " + DateTime.Now + "\n";
            _logger.Info(message);

            try
            {
                _context.Entry(authors).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
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

                if (id != authors.Id)
                {
                    return BadRequest();
                }
                else if (!AuthorsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                }
            }

            return NoContent();
        }

        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // POST: api/Authors
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        [HttpPost]
        public async Task<ActionResult<Author>> PostAuthors(Author authors)
        {
            // NLog 
            string message = $"Log Information(API Server) -Try to POST Author " + authors.Id + "(Id) - Controller : AuthorsController; " +
                "Actionname: PostAuthors(...); HTTP method : HttpPost; Time: " + DateTime.Now + "\n\n";
            _logger.Info(message);

            try
            {
                _context.Authors.Add(authors);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetAuthors", new { id = authors.Id }, authors);
            }
            catch (DbUpdateException ex)
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

                if (AuthorsExists(authors.Id))
                {
                    return Conflict();
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                }
            }

        }

        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // DELETE: api/Authors/5
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        [HttpDelete("{id}")]
        public async Task<ActionResult<Author>> DeleteAuthors(int id)
        {
            // NLog 
            string message = $"(API Server) -Try to DELETE Author " + id + "(Id) - Controller : AuthorsController; " +
                "Actionname: DeleteAuthors(...); HTTP method : HttpDelete; Time: " + DateTime.Now + "\n\n";
            _logger.Info(message);

            Author authors = new Author();

            try
            {
                authors = await _context.Authors.FindAsync(id);
                _context.Authors.Remove(authors);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                var sqlException = ex.GetBaseException() as SqlException;

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

                if (sqlException != null)
                {
                    var number = sqlException.Number;
                    if (number == 547)
                    {
                        return ValidationProblem(sqlException.Message);
                    }
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                }
            }

            return authors;
        }


        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // BOOL : AuthorsExists()
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        private bool AuthorsExists(int id)
        {

            // NLog 
            string message = $"(API Server) - Verify if an Author " + id + "(Id) exists - Controller : AuthorsController; " +
                "Actionname: AuthorsExists(...); Return: bool; Time: " + DateTime.Now + "\n\n";
            _logger.Info(message);

            bool exist = false;
            try
            {
                exist = _context.Authors.Any(e => e.Id == id);
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

                return exist = false;
            }

            return exist;
        }


    }
}
