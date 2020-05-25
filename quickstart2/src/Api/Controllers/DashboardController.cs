
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
    using System.Security.Cryptography.X509Certificates;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DashboardController : ControllerBase
    {

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
        public async Task<ActionResult<IEnumerable<DashbordViewModel>>> GetAppreciations()
        {
            var result = (from ord in _context.Appreciations
                          group ord by ord.EvaluationDate.Date.Year into grp
                          select new DashbordViewModel
                          {
                              EvaluationDate = grp.Key,
                              Evaluation = grp.Count()
                          }).OrderBy(e => e.EvaluationDate).ToListAsync();

            return await result;

        }


        // ---------------------------------------------------
        // -- Total of Orders 
        // ---------------------------------------------------
        [HttpGet]
        [Route("TotalAppreciations")]
        public async Task<ActionResult<int>> GetTotalAppreciations()
        {
            // SELECT COUNT(*) FROM Appreciations;
            var nbAppreciations = (from c in _context.Appreciations select c).Count();
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
        public async Task<ActionResult<IEnumerable<DashbordViewModel>>> GetBestCities()
        {
            var result = (from client in _context.Customers
                          group client by client.City into clientGroup
                          select new DashbordViewModel
                          {
                              City = clientGroup.Key,
                              Clients = clientGroup.Count()
                          }).OrderByDescending(e => e.Clients).Take(10).ToListAsync();

            return await result;
        }


        // ---------------------------------------------------
        // -- Total number of customers 
        // ---------------------------------------------------
        [HttpGet]
        [Route("TotalCustomers")]
        public async Task<ActionResult<int>> GetTotalCustomers()
        {
            // SELECT COUNT(*) FROM Customers;
            var nbClients = (from c in _context.Customers select c).Count();
            return nbClients;

        }

        
        // ---------------------------------------------------
        // -- Top 10 Best Customers 
        // ---------------------------------------------------

        [HttpGet]
        [Route("BestCustomers/{year}")]
        public async Task<ActionResult<IEnumerable<DashbordViewModel>>> BestCustomers(int? year)
        {

            /*
             SELECT cus.Firstname, cus.Lastname, asp.Email, count(ord.UserId) commands
                FROM Orders ord
                INNER JOIN AspNetUsers asp ON ord.UserId = asp.Id 
                INNER JOIN Customers cus ON asp.Id_Customer = cus.Id
                GROUP BY cus.Firstname, cus.Lastname, asp.Email
                ORDER BY commands DESC
            
             */


            var result = (from ord in _context.Orders 
                          join asp in _context.AspNetUsers on ord.UserId equals asp.Id
                          join cus in _context.Customers on asp.IdCustomer equals cus.Id
                          where ord.OrderedDate.Year == year
                          group new {ord, asp, cus} by new {cus.Firstname, cus.Lastname}
                          into grp
                          select new DashbordViewModel
                          {
                              CountOrders = grp.Count(), 
                              Firstname = grp.Key.Firstname, 
                              Lastname = grp.Key.Lastname,
                              // Amount = grp.Key.TotalPrice
                              Amount = grp.Sum(f => f.ord.TotalPrice), 

                          }).OrderByDescending(e => e.Amount).Take(10).ToListAsync();

            return await result;
        }



        // ---------------------------------------------------
        // -- Total of Order Amount  
        // ---------------------------------------------------
        [HttpGet]
        [Route("TotalAmount/{year}")]
        public async Task<ActionResult<decimal>> GetTotalAmount(int? year)
        {
            var amount = (from c in _context.Orders
                          where c.OrderedDate.Year == year
                          select c).Sum(x => x.TotalPrice);
            return amount;

        }


        // ---------------------------------------------------
        // -- Evolution des commandes en années 
        // ---------------------------------------------------

        [HttpGet]
        [Route("ChartOrders")]
        public async Task<ActionResult<IEnumerable<DashbordViewModel>>> ChartOrders()
        {

            var result = (from ord in _context.Orders
                          group ord by ord.OrderedDate.Date.Year into grp
                          select new DashbordViewModel
                          {
                              OrderDate = grp.Key, 
                              CountOrders = grp.Count()
                          }).OrderByDescending(e => e.OrderDate).ToListAsync();

            return await result;

        }

        // ---------------------------------------------------
        // -- Total of Orders 
        // ---------------------------------------------------
        [HttpGet]
        [Route("TotalOrders")]
        public async Task<ActionResult<int>> GetTotalOrders()
        {
            // SELECT COUNT(*) FROM Orders;
            var nbOrders = (from c in _context.Orders select c).Count();
            return nbOrders;

        }


        // ---------------------------------------------------
        // -- Rank states 
        // ---------------------------------------------------

        [HttpGet]
        [Route("RankCategories")]
        public async Task<ActionResult<IEnumerable<DashbordViewModel>>> RankCategories()
        {
            var result = (from rank in _context.Ranks
                          group rank by rank.IdCategorie into grp
                          select new DashbordViewModel
                          {
                              Description = (from i in _context.Categories
                                             where i.Id == grp.Key
                                             select i.Description).First(), 
                              NbLivres = grp.Count()
                          }).OrderByDescending(e => e.NbLivres).Take(10).ToListAsync();


            return await result;

        }


        [HttpGet]
        [Route("RankFormats")]
        public async Task<ActionResult<IEnumerable<DashbordViewModel>>> RankFormats()
        {
            var result = (from rank in _context.Ranks
                          group rank by rank.IdFormat into grp
                          select new DashbordViewModel
                          {
                              Description = (from i in _context.Formats
                                             where i.Id == grp.Key
                                             select i.Description).First(),
                              NbLivres = grp.Count()
                          }).OrderByDescending(e => e.NbLivres).ToListAsync();


            return await result;

        }


        [HttpGet]
        [Route("RankGenres")]
        public async Task<ActionResult<IEnumerable<DashbordViewModel>>> RankGenres()
        {
            var result = (from rank in _context.Ranks
                          group rank by rank.IdGenre into grp
                          select new DashbordViewModel
                          {
                              Description = (from i in _context.Genres
                                             where i.Id == grp.Key
                                             select i.Description).First(),
                              NbLivres = grp.Count()
                          }).OrderByDescending(e => e.NbLivres).ToListAsync();

            return await result;

        }


        // ---------------------------------------------------
        // -- Availability of Stocks
        // ---------------------------------------------------
        /*
                [HttpGet]
                [Route("StockAvailability")]
                public async Task<ActionResult<IEnumerable<DashbordViewModel>>> StockAvailability()
                {
                    var result = (from book in _context.Books
                                  where ((book.StockInitial - book.Stock) < 26)
                                  select new DashbordViewModel
                                  {
                                      InitialStock = book.StockInitial,
                                      CurrentStock = book.Stock,
                                      Description = book.Title,
                                      DifferenceStock = (book.StockInitial - book.Stock)
                                  }).OrderBy(e => e.DifferenceStock).ToListAsync();

                    return await result;

                }

        */
        /*
                [HttpGet]
                [Route("StockAvailability")]
                public async Task<ActionResult<IEnumerable<DashbordViewModel>>> StockAvailability()
                {
                    var result = (from stock in _context.Stocks
                                  join book in _context.Books on stock.IdBook equals book.Id
                                  where ((stock.InitialStock - stock.CurrentStock) < 26)
                                  select new DashbordViewModel
                                  {
                                      InitialStock = stock.InitialStock,
                                      CurrentStock = stock.CurrentStock,
                                      Description = book.Title,
                                      DifferenceStock = (stock.InitialStock - stock.CurrentStock)
                                  }).OrderBy(e => e.DifferenceStock).ToListAsync();

                    return await result;

                }
        */


        // ---------------------------------------------------
        // -- Total of Orders 
        // ---------------------------------------------------
        [HttpGet]
        [Route("TotalStocks")]
        public ActionResult<int> GetTotalStocks()
        {
            // SELECT COUNT(*) FROM Books;
            var nbBooks = (from b in _context.Books select b).Sum(s => s.Stock);
            return nbBooks;

        }


    }// END CLASS 
}
 