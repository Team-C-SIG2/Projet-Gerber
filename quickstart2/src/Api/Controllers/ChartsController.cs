
namespace Api.Controllers
{

    using Api.Models;
    using Api.ViewModel;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class ChartsController : ControllerBase
    {

        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Initialize the Database Context 
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        private readonly ESBookshopContext _context;


        public ChartsController(ESBookshopContext context)
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
        [Route("Appreciations")]
        public async Task<ActionResult<IEnumerable<ChartViewModel>>> GetAppreciations()
        {

            var result = _context.Appreciations.GroupBy(x => new { x.EvaluationDate.Date.Year }).Select(e => new
                  ChartViewModel()
            {
                Evaluation = e.Sum(item => Convert.ToInt32(item.Evaluation)),
                EvaluationDate = e.Key.Year,
                CountCustomers = (from c in _context.Customers select c).Count()

            }).ToListAsync();

            return await result;

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
        public async Task<ActionResult<IEnumerable<ChartViewModel>>> GetBestCities()
        {
            var result = (from client in _context.Customers
                          group client by client.City into clientGroup
                          select new ChartViewModel
                          {
                              City = clientGroup.Key,
                              Clients = clientGroup.Count()
                          }).OrderByDescending(e => e.Clients).Take(10).ToListAsync();

            return await result;
        }


        [HttpGet]
        [Route("TotalCustomers")]
        public async Task<ActionResult<int>> GetTotalCustomers()
        {
            // SELECT COUNT(*) FROM Customers;
            var nbClients = (from c in _context.Customers select c).Count();
            return nbClients;

        }

        /*

        ---------------------------------------------------
        -- Top 10 Best Customers 
        ---------------------------------------------------
        // TODO TODO 

        */

        [HttpGet]
        [Route("BestCustomers")]
        public async Task<ActionResult<IEnumerable<ChartViewModel>>> BestCustomers()
        {
            return NotFound();
        }



    }// END CLASS 
}