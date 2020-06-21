namespace Api.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;
    using NLog;
    using System;
    using Microsoft.AspNetCore.Http;

    [Route("identity")]
    [Authorize]
    public class IdentityController : ControllerBase
    {
        // NLog 
        private static Logger _logger = LogManager.GetCurrentClassLogger();


        // //////////////////////////////////////////////////////////////////////////////////////////////////////// 
        // Get User Identity  
        // //////////////////////////////////////////////////////////////////////////////////////////////////////// 
        [HttpGet]
        public IActionResult Get()
        {
            // NLog 
            string message = $"(API Server) - Try to GET User Identity - Controller name: IdentityController; " +
                $"Actionname: Get(); HTTP method : HttpGet; Time: " + DateTime.Now + "\n";
            _logger.Info(message);

            try
            {
                return new JsonResult(from c in User.Claims select new { c.Type, c.Value });
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

    }// END CLASS 
}