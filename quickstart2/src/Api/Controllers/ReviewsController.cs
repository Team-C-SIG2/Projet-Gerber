namespace Api.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Api.Models;
    using Microsoft.AspNetCore.Authorization;
    using Api.ViewModel;
    using NLog;
    using System;

    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        // NLog 
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Initialize the Database Context 
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        private readonly ESBookshopContext _context;

        public ReviewsController(ESBookshopContext context)
        {
            _context = context;
        }
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // GET: api/Reviews
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Review>>> GetReviews()
        {
            return await _context.Reviews.ToListAsync();
        }

        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // GET: api/Reviews
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        [HttpGet]
        [Route("signaledReviews")]
        public async Task<List<BookReviews>> GetSignaledReviews()
        {
            // NLog 
            string message = $"(API Server) -Try to GET Signaled Reviews - Controller name: ReviewsController; " +
                "Actionname: GetSignaledReviews(...); HTTP method : HttpGet; Time: " + DateTime.Now + "\n\n";
            _logger.Info(message);

            IQueryable<BookReviews> signaledReviews;
            try
            {
                signaledReviews = (from i in _context.Books
                                   join j in _context.Reviews on i.Id equals j.BookId
                                   join k in _context.AspNetUsers on j.UserId equals k.Id
                                   where j.Signale == true
                                   select new BookReviews { Id = j.Id, BookId = i.Id, UserId = k.Id, Description = j.Description, Note = j.Note, Date = j.Date, Username = k.Username });

                if (signaledReviews == null)
                {
                    return null;
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

                signaledReviews = null;
                return signaledReviews.ToList();
            }

            return await signaledReviews.ToListAsync();
        }

        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // GET: api/Reviews/5
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        [HttpGet("{id}")]
        public async Task<ActionResult<Review>> GetReview(int id)
        {
            // NLog 
            string message = $"(API Server) -Try to GET Reviews " + id + " (id) - Controller name: ReviewsController; " +
                "Actionname: GetReview(id); HTTP method : HttpGet; Time: " + DateTime.Now + "\n";
            _logger.Info(message);

            Review review = new Review();
            try
            {
                review = await _context.Reviews.FindAsync(id);
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

                review = null;
                return NotFound();
            }
            return review;
        }
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // PUT: api/Reviews/5
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReview(int id, Review review)
        {
            // NLog 
            string message = $"(API Server) -Try to PUT (update) Review " + id + "(Id) - Controller : ReviewsController; " +
                "Actionname: PutReview(...); HTTP method : HttpPut; Time: " + DateTime.Now + "\n\n";
            _logger.Info(message);

            try
            {
                _context.Entry(review).State = EntityState.Modified;
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

                if (id != review.Id)
                {
                    return BadRequest();
                }
                else if (!ReviewExists(id))
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
        // POST: api/Reviews
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        [HttpPost]
        public async Task<ActionResult<Review>> PostReview(Review review)
        {
            // NLog 
            string message = $"Log Information(API Server) -Try to POST Review " + review.Id + "(Id) - Controller : ReviewsController; " +
                "Actionname: PostReview(...); HTTP method : HttpPost; Time: " + DateTime.Now + "\n\n";
            _logger.Info(message);

            try
            {
                _context.Reviews.Add(review);
                await _context.SaveChangesAsync();

                _context.Entry(review).GetDatabaseValues();
                return CreatedAtAction("GetReview", new { id = review.Id }, review);
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

                if (ReviewExists(review.Id))
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
        // DELETE: api/Reviews/5
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        [HttpDelete("{id}")]
        public async Task<ActionResult<Review>> DeleteReview(int id)
        {
            // NLog 
            string message = $"(API Server) -Try to DELETE Review " + id + "(Id) - Controller : ReviewsController; " +
                "Actionname: DeleteReview(...); HTTP method : HttpDelete; Time: " + DateTime.Now + "\n\n";
            _logger.Info(message);


            Review review = new Review();
            try
            {
                // Find Review 
                review = await _context.Reviews.FindAsync(id);

                // Remove Review 
                _context.Reviews.Remove(review);
                await _context.SaveChangesAsync();

                // GET UPDATED DB VALUES 
                _context.Entry(review).GetDatabaseValues();

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


                if (review == null)
                {
                    return NotFound();
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                }

            }

            return review;
        }

        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // BOOL : Exists? 
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        private bool ReviewExists(int id)
        {
            // NLog 
            string message = $"(API Server) - Verify if  Review " + id + "(Id) exists - Controller : ReviewsController; " +
                "Actionname: ReviewExists(...); Return: bool; Time: " + DateTime.Now + "\n\n";
            _logger.Info(message);

            bool exist = false;
            try
            {
                exist = _context.Reviews.Any(e => e.Id == id);
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

    }// END CLASS 
}
