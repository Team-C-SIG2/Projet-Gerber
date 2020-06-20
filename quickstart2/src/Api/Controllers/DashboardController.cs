namespace Api.Controllers
{

    using Api.Models;
    using Api.ViewModel;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using System.Security.Claims;
    using NLog;
    using System;

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DashboardController : ControllerBase
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger(); // NLog 

        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Initialize the Database Context 
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        private readonly ESBookshopContext _context;


        public DashboardController(ESBookshopContext context)
        {
            _context = context;
        }

        /*
            ---------------------------------------------------
            -- Evolutions des appréciations en années 
            ---------------------------------------------------

            SELECT YEAR([EvaluationDate]) AS Year
                  , SUM(CONVERT(FLOAT, [Evaluation])) 
            FROM [TEST2].[dbo].[Appreciations]
            GROUP BY  DATEPART(yyyy,  [EvaluationDate])
            ORDER BY Year
            */
        [HttpGet]
        [Route("ChartAppreciations")]
        public async Task<ActionResult<IEnumerable<DashboardViewModel>>> GetAppreciations()
        {

            // NLog 
            string message = $"(API Server) - Try to get ALL Appreciations -Controller name: DashboardController; " +
                $"Actionname: GetAppreciations(); HTTP method : HttpGet; Time: " + DateTime.Now + "\n";
            _logger.Info(message);

            IQueryable<DashboardViewModel> result = null;

            try
            {
                result = (from ord in _context.Appreciations
                          group ord by ord.EvaluationDate.Date.Year into grp
                          select new DashboardViewModel
                          {
                              EvaluationDate = grp.Key,
                              Evaluation = grp.Count()
                          }).OrderBy(e => e.EvaluationDate);
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

            return await result.ToListAsync();

        }


        // ---------------------------------------------------
        // -- Total of Orders 
        // ---------------------------------------------------
        [HttpGet]
        [Route("TotalAppreciations")]
        public async Task<ActionResult<int>> GetTotalAppreciations()
        {
            // NLog 
            string message = $"(API Server) - Try to get Total of Appreciations - Controller name: DashboardController; " +
                $"Actionname: GetTotalAppreciations(); HTTP method : HttpGet; Time: " + DateTime.Now + "\n";
            _logger.Info(message);


            int nbAppreciations = 0;
            try
            {
                // SELECT COUNT(*) FROM Appreciations;
                nbAppreciations = (from c in _context.Appreciations select c).Count();
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

            return nbAppreciations;
        }

        /*

        ---------------------------------------------------
        -- Top Best cities ( whith most clients)
        ---------------------------------------------------
        SELECT TOP (10) 
        [City] , Count(*) as Clients
        FROM [TEST2].[dbo].[Customers]
        Group by City
        having Count(*)  > 50
        Order by Clients desc

        */
        [HttpGet]
        [Route("BestCities")]
        public async Task<ActionResult<IEnumerable<DashboardViewModel>>> GetBestCities()
        {
            // NLog 
            string message = $"(API Server) - Try to get Top 10 Best Cities - Controller name: DashboardController; " +
                $"Actionname: GetBestCities(); HTTP method : HttpGet; Time: " + DateTime.Now + "\n";
            _logger.Info(message);

            IQueryable<DashboardViewModel> result = null;

            try
            {
                result = (from client in _context.Customers
                          group client by client.City into clientGroup
                          select new DashboardViewModel
                          {
                              City = clientGroup.Key,
                              Clients = clientGroup.Count()
                          }).OrderByDescending(e => e.Clients).Take(10);
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

            return await result.ToListAsync();
        }


        // ---------------------------------------------------
        // -- Total number of customers 
        // ---------------------------------------------------
        [HttpGet]
        [Route("TotalCustomers")]
        public async Task<ActionResult<int>> GetTotalCustomers()
        {
            // NLog 
            string message = $"(API Server) - Try to get Total of Customers - Controller name: DashboardController; " +
                $"Actionname: GetTotalCustomers(); HTTP method : HttpGet; Time: " + DateTime.Now + "\n";
            _logger.Info(message);


            int nbClients = 0;
            try
            {
                // SELECT COUNT(*) FROM Customers;
                nbClients = (from c in _context.Customers select c).Count();
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

            return nbClients;

        }


        // ---------------------------------------------------
        // -- Top 10 Best Customers 
        // ---------------------------------------------------

        [HttpGet]
        [Route("BestCustomers/{year?}")]
        public async Task<ActionResult<IEnumerable<DashboardViewModel>>> BestCustomers(int? year)
        {
            // NLog 
            string message = $"(API Server) - Try to get Top 10 Best Customers - Controller name: DashboardController; " +
                $"Actionname: BestCustomers(); HTTP method : HttpGet; Time: " + DateTime.Now + "\n";
            _logger.Info(message);

            IQueryable<DashboardViewModel> result = null;
            try
            {
                result = (from ord in _context.Orders
                          join asp in _context.AspNetUsers on ord.UserId equals asp.Id
                          join cus in _context.Customers on asp.IdCustomer equals cus.Id
                          where ord.OrderedDate.Year == year
                          group new { ord, asp, cus } by new { cus.Firstname, cus.Lastname }
                              into grp
                          select new DashboardViewModel
                          {
                              CountOrders = grp.Count(),
                              Firstname = grp.Key.Firstname,
                              Lastname = grp.Key.Lastname,
                              // Amount = grp.Key.TotalPrice
                              Amount = grp.Sum(f => f.ord.TotalPrice),

                          }).OrderByDescending(e => e.Amount).Take(10);
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

            return await result.ToListAsync();
        }

        // ---------------------------------------------------
        // -- Top 10 Best Customers 
        // ---------------------------------------------------

        [HttpGet]
        [Route("BestOrders")]
        public async Task<ActionResult<IEnumerable<DashboardViewModel>>> BestOrders()
        {
            // NLog 
            string message = $"(API Server) - Try to get Top 10 Best Customers - Controller name: DashboardController; " +
                $"Actionname: BestCustomers(); HTTP method : HttpGet; Time: " + DateTime.Now + "\n";
            _logger.Info(message);

            IQueryable<DashboardViewModel> result = null;

            /*
             SELECT cus.Firstname, cus.Lastname, asp.Email, count(ord.UserId) commands
                FROM Orders ord
                INNER JOIN AspNetUsers asp ON ord.UserId = asp.Id 
                INNER JOIN Customers cus ON asp.Id_Customer = cus.Id
                GROUP BY cus.Firstname, cus.Lastname, asp.Email
                ORDER BY commands DESC
            
             */
            try
            {
                result = (from ord in _context.Orders
                          join asp in _context.AspNetUsers on ord.UserId equals asp.Id
                          join cus in _context.Customers on asp.IdCustomer equals cus.Id
                          group new { asp, cus } by new { cus.Firstname, cus.Lastname }
                              into grp
                          select new DashboardViewModel
                          {
                              CountOrders = grp.Count(),
                              Firstname = grp.Key.Firstname,
                              Lastname = grp.Key.Lastname,
                          }).OrderByDescending(e => e.CountOrders).Take(10);
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

            return await result.ToListAsync();
        }

        // ---------------------------------------------------
        // -- Total of Order Amount  
        // ---------------------------------------------------
        [HttpGet]
        [Route("TotalAmount/{year?}")]
        public async Task<ActionResult<decimal>> GetTotalAmount(int? year)
        {
            // NLog 
            string message = $"(API Server) - Try to get the Total Amount of Orders  - Controller name: DashboardController; " +
                $"Actionname: GetTotalAmount(); HTTP method : HttpGet; Time: " + DateTime.Now + "\n";
            _logger.Info(message);

            decimal amount = 0;
            try
            {
                amount = (from c in _context.Orders
                          where c.OrderedDate.Year == year
                          select c).Sum(x => x.TotalPrice);
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

            return amount;
        }


        // ---------------------------------------------------
        // -- Evolution des commandes en années 
        // ---------------------------------------------------

        [HttpGet]
        [Route("ChartOrders")]
        public async Task<ActionResult<IEnumerable<DashboardViewModel>>> ChartOrders()
        {

            // NLog 
            string message = $"(API Server) - Try to get number of Order by year - Controller name: DashboardController; " +
                $"Actionname: ChartOrders(); HTTP method : HttpGet; Time: " + DateTime.Now + "\n";
            _logger.Info(message);

            IQueryable<DashboardViewModel> result = null;
            try
            {
                result = (from ord in _context.Orders
                          group ord by ord.OrderedDate.Date.Year into grp
                          select new DashboardViewModel
                          {
                              OrderDate = grp.Key,
                              CountOrders = grp.Count()
                          }).OrderByDescending(e => e.OrderDate);

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

            return await result.ToListAsync();

        }

        // ---------------------------------------------------
        // -- Total of Orders 
        // ---------------------------------------------------
        [HttpGet]
        [Route("TotalOrders")]
        public async Task<ActionResult<int>> GetTotalOrders()
        {

            // NLog 
            string message = $"(API Server) - Try to get the Total number of Orders  - Controller name: DashboardController; " +
                $"Actionname: GetTotalOrders(); HTTP method : HttpGet; Time: " + DateTime.Now + "\n";
            _logger.Info(message);

            int nbOrders = 0;
            try
            {
                // SELECT COUNT(*) FROM Orders;
                nbOrders = (from c in _context.Orders select c).Count();
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


            return nbOrders;

        }
        // ---------------------------------------------------
        // -- Rank states 
        // ---------------------------------------------------

        [HttpGet]
        [Route("RankCategories")]
        public async Task<ActionResult<IEnumerable<DashboardViewModel>>> RankCategories()
        {
            // NLog 
            string message = $"(API Server) - Try to get ALL book's categories - Controller name: DashboardController; " +
                $"Actionname: RankCategories(); HTTP method : HttpGet; Time: " + DateTime.Now + "\n";
            _logger.Info(message);

            IQueryable<DashboardViewModel> result = null;
            try
            {

                result = (from rank in _context.Ranks
                          group rank by rank.IdCategorie into grp
                          select new DashboardViewModel
                          {
                              Description = (from i in _context.Categories
                                             where i.Id == grp.Key
                                             select i.Description).First(),
                              NbLivres = grp.Count()
                          }).OrderByDescending(e => e.NbLivres).Take(10);

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

            return await result.ToListAsync();

        }


        [HttpGet]
        [Route("RankFormats")]
        public async Task<ActionResult<IEnumerable<DashboardViewModel>>> RankFormats()
        {

            // NLog 
            string message = $"(API Server) - Try to get ALL book's formats - Controller name: DashboardController; " +
                $"Actionname: RankFormats(); HTTP method : HttpGet; Time: " + DateTime.Now + "\n";
            _logger.Info(message);

            IQueryable<DashboardViewModel> result = null;
            try
            {

                result = (from rank in _context.Ranks
                          group rank by rank.IdFormat into grp
                          select new DashboardViewModel
                          {
                              Description = (from i in _context.Formats
                                             where i.Id == grp.Key
                                             select i.Description).First(),
                              NbLivres = grp.Count()
                          }).OrderByDescending(e => e.NbLivres);

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

            return await result.ToListAsync();

        }

        // ---------------------------------------------------
        // -- Total of Orders 
        // ---------------------------------------------------
        [HttpGet]
        [Route("TotalRanks")]
        public ActionResult<int> GetTotalRanks()
        {

            // NLog 
            string message = $"(API Server) - Try to get the Total number of Ranks  - Controller name: DashboardController; " +
                $"Actionname: GetTotalRanks(); HTTP method : HttpGet; Time: " + DateTime.Now + "\n";
            _logger.Info(message);

            int nbRanks = 0;
            try
            {
                // SELECT COUNT(*) FROM Books;
                nbRanks = (from b in _context.Ranks select b).Count();
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

            return nbRanks;
        }

        [HttpGet]
        [Route("RankGenres")]
        public async Task<ActionResult<IEnumerable<DashboardViewModel>>> RankGenres()
        {

            // NLog 
            string message = $"(API Server) - Try to get ALL book's genres - Controller name: DashboardController; " +
                $"Actionname: RankGenres(); HTTP method : HttpGet; Time: " + DateTime.Now + "\n";
            _logger.Info(message);

            IQueryable<DashboardViewModel> result = null;
            try
            {
                result = (from rank in _context.Ranks
                          group rank by rank.IdGenre into grp
                          select new DashboardViewModel
                          {
                              Description = (from i in _context.Genres
                                             where i.Id == grp.Key
                                             select i.Description).First(),
                              NbLivres = grp.Count()
                          }).OrderByDescending(e => e.NbLivres).Take(10);

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

            return await result.ToListAsync();

        }


        // ---------------------------------------------------
        // -- Availability of Stocks
        // ---------------------------------------------------

        [HttpGet]
        [Route("StockAvailability")]
        public async Task<ActionResult<IEnumerable<DashboardViewModel>>> StockAvailability()
        {
            // NLog 
            string message = $"(API Server) - Try to get stok's availability less then 10 articles - Controller name: DashboardController; " +
                $"Actionname: StockAvailability(); HTTP method : HttpGet; Time: " + DateTime.Now + "\n";
            _logger.Info(message);

            IQueryable<DashboardViewModel> result = null;
            try
            {
                result = (from book in _context.Books
                          where (book.Stock <= 10)
                          select new DashboardViewModel
                          {
                              CurrentStock = book.Stock,
                              Description = book.Title,
                          }).OrderBy(e => e.CurrentStock);
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

            return await result.ToListAsync();
        }


        // ---------------------------------------------------
        // -- Total of Orders 
        // ---------------------------------------------------
        [HttpGet]
        [Route("TotalStocks")]
        public ActionResult<int> GetTotalStocks()
        {
            // NLog 
            string message = $"(API Server) - Try to get the Total number of books in stock - Controller name: DashboardController; " +
                $"Actionname: GetTotalStocks(); HTTP method : HttpGet; Time: " + DateTime.Now + "\n";
            _logger.Info(message);

            int nbStocks = 0;
            try
            {
                // SELECT COUNT(*) FROM Books;
                nbStocks = (from b in _context.Books select b).Sum(s => s.Stock);
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
            return nbStocks;
        }

    }// END CLASS 
}
