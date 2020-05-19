
namespace Api.Controllers
{

    using Api.Models;
    using Api.ViewModel;

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

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
            - Meilleurs acheteurs (utilisateurs) 
            - Livres les plus vendus 
            - Categories les plus apréciées 

        */


        [HttpGet]
        [Route("Appreciations")]
        public async Task<ActionResult<IEnumerable<ChartViewModel>>> GetAppreciations()
        {

            var result = _context.Appreciations.GroupBy(x => new { x.EvaluationDate.Date.Year }).Select(c => new
                  ChartViewModel()
            {
                Evaluation = c.Sum(item => Convert.ToInt32(item.Evaluation)),
                EvaluationDate = c.Key.Year
            }).ToListAsync();

            return await result;

        }


    }// END CLASS 
}