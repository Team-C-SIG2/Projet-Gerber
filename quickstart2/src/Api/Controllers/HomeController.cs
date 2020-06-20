namespace Api.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Security.Claims;
    using NLog;
    using System;

    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        // NLog 
        private static Logger _logger = LogManager.GetCurrentClassLogger();


        // ____________________________________________________________________
        // Home/Index 
        // ____________________________________________________________________
        [AllowAnonymous]
        public string Index()
        {
            return "Welcome ! For our RESTFull API Server Documentation, just visite our web page 'www.esbookshop.ch'";
        }


        // ____________________________________________________________________
        // GET CONNECTED USER ID (Control -> EsbookshopDB.AspNetUsers.Id)
        // ____________________________________________________________________

        [Route("UserId")]
        public string GetUserId()
        {
            // NLog 
            string message = $"(API Server) - Try to GET Connected User Id - Controller name: HomeController; " +
                $"Actionname: GetUserId(); HTTP method : HttpGet; Time: " + DateTime.Now + "\n";
            _logger.Info(message);

            string userId = null;
            try
            {
                userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
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

                return null;
            }

            return userId;
        }



    }// END CLASS
}