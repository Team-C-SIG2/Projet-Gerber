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
    public class RanksController : ControllerBase
    {
        // NLog 
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Initialize the Database Context 
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        private readonly ESBookshopContext _context;

        public RanksController(ESBookshopContext context)
        {
            _context = context;
        }

        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // GET: api/Ranks
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rank>>> GetRanks()
        {
            // NLog 
            string message = $"(API Server) - Try to GET ALL Ranks - Controller name: RanksController; " +
                $"Actionname: GetRanks(); HTTP method : HttpGet; Time: " + DateTime.Now + "\n";
            _logger.Info(message);

            IQueryable<Rank> ranks = null;
            try
            {
                ranks = _context.Ranks;
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

                if (ranks == null)
                {
                    return NotFound();
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                }

            }

            return await ranks.ToListAsync();
        }

        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // GET: api/Ranks
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        [Route("GetAllRanks/")]
        public async Task<ActionResult<IEnumerable<Rank>>> GetAllRanks()
        {
            // NLog 
            string message = $"(API Server) - Try to GET ALL Ranks - Controller name: RanksController; " +
                $"Actionname: GetRanks(); HTTP method : HttpGet; Time: " + DateTime.Now + "\n";
            _logger.Info(message);

            IQueryable<Rank> ranks = null;
            try
            {
                // ranks = _context.Ranks;
                ranks =
                    (from i in _context.Ranks
                     select new Rank()
                     {
                         IdBook = i.IdBook,
                         IdCategorie = i.IdCategorie,
                         IdGenre = i.IdGenre,
                         IdFormat = i.IdFormat,
                         IdLanguage = i.IdLanguage,

                         IdBookNavigation = (from b in _context.Books where b.Id == i.IdBook select b).FirstOrDefault(),
                         IdCategorieNavigation = (from c in _context.Categories where c.Id == i.IdCategorie select c).FirstOrDefault(),
                         IdFormatNavigation = (from f in _context.Formats where f.Id == i.IdFormat select f).FirstOrDefault(),
                         IdLanguageNavigation = (from l in _context.Languages where l.Id == i.IdLanguage select l).FirstOrDefault(),
                         IdGenreNavigation = (from g in _context.Genres where g.Id == i.IdGenre select g).FirstOrDefault()
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

                if (ranks == null)
                {
                    return NotFound();
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                }

            }

            return await ranks.ToListAsync();
        }

        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // GET: api/Ranks/5
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        [HttpGet("{id}")]
        public async Task<ActionResult<Rank>> GetRank(int id)
        {
            // NLog 
            string message = $"(API Server) -Try to GET Rank " + id + "(Id) - Controller name: RanksController; " +
                "Actionname: GetRank(id); HTTP method : HttpGet; Time: " + DateTime.Now + "\n";
            _logger.Info(message);

            Rank rank = new Rank();
            try
            {
                rank = await _context.Ranks.FindAsync(id);
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


                if (rank == null)
                {
                    return NotFound();
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                }
            }

            return rank;
        }
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // PUT: api/Ranks/5
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRank(int id, Rank rank)
        {
            // NLog 
            string message = $"(API Server) -Try to PUT (update) Rank " + id + "(Id) - Controller : RanksController; " +
                "Actionname: PutRank(...); HTTP method : HttpPut; Time: " + DateTime.Now + "\n";
            _logger.Info(message);

            try
            {
                _context.Entry(rank).State = EntityState.Modified;
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

                if (id != rank.IdBook)
                {
                    return BadRequest();
                }
                else if (!RankExists(id))
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
        // POST: api/Ranks
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        [HttpPost]
        public async Task<ActionResult<Rank>> PostRank(Rank rank)
        {
            // NLog 
            string message = $"(API Server) -Try to POST a Rank - Controller : RanksController; " +
                "Actionname: PostRank(...); HTTP method : HttpPost; Time: " + DateTime.Now + "\n";
            _logger.Info(message);

            try
            {
                ; _context.Ranks.Add(rank);
                await _context.SaveChangesAsync();

                _context.Entry(rank).GetDatabaseValues();

                return CreatedAtAction("GetRank", new { id = rank.IdBook }, rank);
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
        // DELETE: api/Ranks/5
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        [HttpDelete("{id}")]
        public async Task<ActionResult<Rank>> DeleteRank(int id)
        {
            // NLog 
            string message = $"(API Server) -Try to DELETE a Rank " + id + "(Id) - Controller : RanksController; " +
                "Actionname: DeleteRank(id); HTTP method : HttpDelete; Time: " + DateTime.Now + "\n";
            _logger.Info(message);

            Rank rank = null;
            try
            {
                // Find rank 
                rank = await _context.Ranks.FindAsync(id);

                // Remove rank 
                _context.Ranks.Remove(rank);
                await _context.SaveChangesAsync();

                // GET UPDATED DB VALUES 
                _context.Entry(rank).GetDatabaseValues();

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

                if (rank == null)
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

            return rank;
        }

        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // BOOL : RankExists? 
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        private bool RankExists(int id)
        {
            // NLog 
            string message = $"(API Server) - Verify if the Rank " + id + " (Id) EXISTS - Controller : RanksController; " +
                "Actionname: RankExists(id); Return: bool; Time: " + DateTime.Now + "\n";
            _logger.Info(message);

            bool exist = false;
            try
            {
                exist = _context.Ranks.Any(e => e.IdBook == id);
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
