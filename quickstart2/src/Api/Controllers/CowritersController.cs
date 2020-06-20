
namespace Api.Controllers
{
    using Api.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using NLog;
    using System;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Data.SqlClient;

    [Route("api/[controller]")]
    [ApiController]
    public class CowritersController : ControllerBase
    {
        // NLog 
        private static Logger _logger = LogManager.GetCurrentClassLogger();


        // //////////////////////////////////////////////////////////////////////////////////////////////////////// 
        // Initialize the Database Context  
        // //////////////////////////////////////////////////////////////////////////////////////////////////////// 
        private readonly ESBookshopContext _context;

        public CowritersController(ESBookshopContext context)
        {
            _context = context;
        }

        // //////////////////////////////////////////////////////////////////////////////////////////////////////// 
        // GET: api/Cowriters
        // //////////////////////////////////////////////////////////////////////////////////////////////////////// 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cowriter>>> GetCowriters()
        {
            // NLog 
            string message = $"(API Server) - Try to GET ALL Cowriters - Controller: CowritersController; " +
                $"Actionname: GetCowriters(); HTTP method : HttpGet; Time: " + DateTime.Now + "\n";
            _logger.Info(message);

            IQueryable<Cowriter> items;
            try
            {
                items = _context.Cowriters;
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

            return await items.ToListAsync();

        }

        // //////////////////////////////////////////////////////////////////////////////////////////////////////// 
        // GET: api/Cowriters/5
        // //////////////////////////////////////////////////////////////////////////////////////////////////////// 
        [HttpGet("{id}")]
        public async Task<ActionResult<Cowriter>> GetCowriters(int id)
        {
            // NLog 
            string message = $"(API Server) - Try to GET Cowriter " + id + " (id) - Controller: CowritersController; " +
                $"Actionname: GetCowriters(id); HTTP method : HttpGet; Time: " + DateTime.Now + "\n";
            _logger.Info(message);

            Cowriter cowriters = null;
            try
            {
                cowriters = await _context.Cowriters.FindAsync(id);
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

                if (cowriters == null)
                {
                    return NotFound();
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                }
            }

            return cowriters;
        }

        // //////////////////////////////////////////////////////////////////////////////////////////////////////// 
        // PUT: api/Cowriters/5
        // //////////////////////////////////////////////////////////////////////////////////////////////////////// 
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCowriters(int id, Cowriter cowriters)
        {
            // NLog 
            string message = $"(API Server) - Try to PUT Cowriter " + cowriters.IdAuthor + " (IdAuthor) - Controller: CowritersController; " +
                $"Actionname: PutCowriters(...); HTTP method : HttpPut; Time: " + DateTime.Now + "\n";
            _logger.Info(message);

            try
            {
                _context.Entry(cowriters).State = EntityState.Modified;
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

                if (id != cowriters.IdAuthor)
                {
                    return BadRequest();
                }
                else if (!CowritersExists(id))
                {
                    return NotFound();
                }

                return NotFound();
            }

            return NoContent();
        }

        // //////////////////////////////////////////////////////////////////////////////////////////////////////// 
        // POST: api/Cowriters
        // //////////////////////////////////////////////////////////////////////////////////////////////////////// 
        [HttpPost]
        public async Task<ActionResult<Cowriter>> PostCowriters(Cowriter cowriters)
        {
            // NLog 
            string message = $"(API Server) - Try to POST Cowriter " + cowriters.IdAuthor + " (IdAuthor) - Controller: CowritersController; " +
                $"Actionname: PostCowriters(...); HTTP method : HttpPut; Time: " + DateTime.Now + "\n";
            _logger.Info(message);

            try
            {
                _context.Cowriters.Add(cowriters);
                await _context.SaveChangesAsync();
                _context.Entry(cowriters).GetDatabaseValues();

                return CreatedAtAction("GetCowriters", new { id = cowriters.IdAuthor }, cowriters);

            }
            catch (DbUpdateException ex)
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

                if (CowritersExists(cowriters.IdAuthor))
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
        // DELETE: api/Cowriters/5
        // //////////////////////////////////////////////////////////////////////////////////////////////////////// 
        [HttpDelete("{id}")]
        public async Task<ActionResult<Cowriter>> DeleteCowriters(int id)
        {
            // NLog 
            string message = $"(API Server) -Try to DELETE a categorie " + id + "(Id) - Controller : CategoriesController; " +
                "Actionname: DeleteCategorie(...); HTTP method : HttpDelete; Time: " + DateTime.Now + "\n";
            _logger.Info(message);

            Cowriter cowriters = null;
            try
            {
                // Find categorie 
                cowriters = await _context.Cowriters.FindAsync(id);

                // Remove categorie 
                _context.Cowriters.Remove(cowriters);
                await _context.SaveChangesAsync();

                // GET UPDATED DB VALUES 
                _context.Entry(cowriters).GetDatabaseValues();

            }
            catch (Exception ex)
            {
                var sqlException = ex.GetBaseException() as SqlException;

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

                if (cowriters == null)
                {
                    return NotFound();
                }
                else if (sqlException != null)
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

            return cowriters;
        }

        // //////////////////////////////////////////////////////////////////////////////////////////////////////// 
        // BOOL : CowritersExists? 
        // //////////////////////////////////////////////////////////////////////////////////////////////////////// 
        private bool CowritersExists(int id)
        {
            // NLog 
            string message = $"(API Server) - Verify if Cowriter " + id + "(Id) exists - Controller : CowritersController; " +
                "Actionname: CowritersExists(...); Return: bool; Time: " + DateTime.Now + "\n";
            _logger.Info(message);

            bool exist = false;

            try
            {
                exist = _context.Cowriters.Any(e => e.IdAuthor == id);
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

                return exist = false;
            }

            return exist;
        }

    }// END CLASS
}
