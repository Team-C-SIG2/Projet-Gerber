namespace Api.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Api.Models;
    using NLog;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.Data.SqlClient;

    [Route("api/[controller]")]
    [ApiController]
    public class StockHistoriesController : ControllerBase
    {
        // NLog 
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        // //////////////////////////////////////////////////////////////////////////////////////////////////////// 
        // Initialize the Database Context  
        // //////////////////////////////////////////////////////////////////////////////////////////////////////// 
        private readonly ESBookshopContext _context;

        public StockHistoriesController(ESBookshopContext context)
        {
            _context = context;
        }

        // //////////////////////////////////////////////////////////////////////////////////////////////////////// 
        // GET: api/StockHistories
        // //////////////////////////////////////////////////////////////////////////////////////////////////////// 

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StockHistory>>> GetStockHistories()
        {
            // NLog 
            string message = $"(API Server) - Try to GET ALL StockHistories - Controller name: StockHistoriesController; " +
                $"Actionname: GetStockHistories(); HTTP method : HttpGet; Time: " + DateTime.Now + "\n";
            _logger.Info(message);

            IQueryable<StockHistory> stockHistories = null;
            try
            {
                stockHistories = _context.StockHistories;
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

                if (stockHistories == null)
                {
                    return NotFound();
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                }

            }

            return await stockHistories.ToListAsync();
        }

        // //////////////////////////////////////////////////////////////////////////////////////////////////////// 
        // GET: api/StockHistories/5
        // //////////////////////////////////////////////////////////////////////////////////////////////////////// 
        [HttpGet("{id}")]
        public async Task<ActionResult<StockHistory>> GetStockHistory(int id)
        {
            // NLog 
            string message = $"(API Server) -Try to GET StockHistory " + id + "(Id) - Controller name: StockHistoriesController; " +
                "Actionname: GetStockHistory(id); HTTP method : HttpGet; Time: " + DateTime.Now + "\n";
            _logger.Info(message);

            StockHistory stockHistory = new StockHistory();
            try
            {
                stockHistory = await _context.StockHistories.FindAsync(id);
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

                if (stockHistory == null)
                {
                    return NotFound();
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                }
            }

            return stockHistory;
        }

        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // GET: api/StockHistories/bookstockhistory/5
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        [Route("bookstockhistory/{bookId}")]
        public ActionResult<List<StockHistory>> GetBookStockHistory(int bookId)
        {
            // NLog 
            string message = $"(API Server) - Try to GET ALL StockHistories - Controller name: StockHistoriesController; " +
                $"Actionname: GetBookStockHistory(); HTTP method : HttpGet; Time: " + DateTime.Now + "\n";
            _logger.Info(message);

            List<StockHistory> stockHistory = new List<StockHistory>();
            try
            {
                stockHistory = (from q in _context.StockHistories
                                where q.IdBook == bookId
                                select q).ToList();
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

                if (stockHistory == null)
                {
                    return NotFound();
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                }
            }
            return stockHistory;
        }


        // //////////////////////////////////////////////////////////////////////////////////////////////////////// 
        // PUT: api/StockHistories/5
        // //////////////////////////////////////////////////////////////////////////////////////////////////////// 
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStockHistory(int id, StockHistory stockHistory)
        {
            // NLog 
            string message = $"(API Server) -Try to PUT (update) StockHistory " + id + "(Id) - Controller : StockHistoriesController; " +
                "Actionname: PutStockHistory(...); HTTP method : HttpPut; Time: " + DateTime.Now + "\n";
            _logger.Info(message);

            try
            {
                _context.Entry(stockHistory).State = EntityState.Modified;
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

                if (id != stockHistory.Id)
                {
                    return BadRequest();
                }
                else if (!StockHistoryExists(id))
                {
                    return NotFound();
                }

                return NotFound();
            }

            return NoContent();
        }

        // //////////////////////////////////////////////////////////////////////////////////////////////////////// 
        // POST: api/StockHistories
        // //////////////////////////////////////////////////////////////////////////////////////////////////////// 
        [HttpPost]
        public async Task<ActionResult<StockHistory>> PostStockHistory(StockHistory stockHistory)
        {
            // NLog 
            string message = $"(API Server) -Try to POST StockHistory " + stockHistory.Id + " (Id) - Controller : StockHistoriesController; " +
                "Actionname: PostStockHistory(...); HTTP method : HttpPost; Time: " + DateTime.Now + "\n";
            _logger.Info(message);

            try
            {
                _context.StockHistories.Add(stockHistory);
                await _context.SaveChangesAsync();

                _context.Entry(stockHistory).GetDatabaseValues();

                return CreatedAtAction("GetStockHistory", new { id = stockHistory.Id }, stockHistory);

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

                if (StockHistoryExists(stockHistory.Id))
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
        // DELETE: api/StockHistories/5
        // //////////////////////////////////////////////////////////////////////////////////////////////////////// 
        [HttpDelete("{id}")]
        public async Task<ActionResult<StockHistory>> DeleteStockHistory(int id)
        {
            // NLog 
            string message = $"(API Server) -Try to DELETE StockHistory " + id + "(Id) - Controller : StockHistoriesController; " +
                "Actionname: DeleteStockHistory(id); HTTP method : HttpDelete; Time: " + DateTime.Now + "\n";
            _logger.Info(message);

            StockHistory stockHistory = null;
            try
            {
                // Find StockHistory 
                stockHistory = await _context.StockHistories.FindAsync(id);

                // Remove StockHistory 
                _context.StockHistories.Remove(stockHistory);
                await _context.SaveChangesAsync();

                // GET UPDATED DB VALUES 
                _context.Entry(stockHistory).GetDatabaseValues();

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

                if (stockHistory == null)
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

            return stockHistory;
        }

        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // BOOL : StockHistoryExists?
        // //////////////////////////////////////////////////////////////////////////////////////////////////////// 
        private bool StockHistoryExists(int id)
        {
            // NLog 
            string message = $"(API Server) - Verify if the Stock History " + id + "(Id) EXISTS - Controller : StockHistoriesController; " +
                "Actionname: StockHistoryExists(id); Return: bool; Time: " + DateTime.Now + "\n";
            _logger.Info(message);

            bool exist = false;
            try
            {
                exist = _context.StockHistories.Any(e => e.Id == id);
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
