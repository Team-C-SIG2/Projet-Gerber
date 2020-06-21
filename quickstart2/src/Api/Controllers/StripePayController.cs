namespace Api.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using System.Collections.Generic;
    using NLog;
    using System;
    using Microsoft.AspNetCore.Http;

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StripePayController : ControllerBase
    {

        // NLog 
        private static Logger _logger = LogManager.GetCurrentClassLogger();


        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Prepare de Configuration of Stripe
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////

        private readonly IConfiguration _configuration;


        public StripePayController(IConfiguration configuration)
        {
            _configuration = configuration;

        }

        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // retourne la clé publique du compte du vendeur (Stripe) 
        // GET: api/StripePay/PKey
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////

        [HttpGet]
        [Route("PKey")]
        public IEnumerable<string> GetPublicKey()
        {
            // NLog 
            string message = $"(API Server) -Try to GET PublicKey for payment - Controller name: StripePayController; " +
                "Actionname: GetPublicKey(...); HTTP method : HttpGet; Time: " + DateTime.Now + "\n\n";
            _logger.Info(message);

            string publickey = null;
            try
            {
                publickey = _configuration.GetValue<string>("Stripe:PublishableKey");
                return new string[] { publickey };
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

                return (IEnumerable<string>)StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Return the ApiKey for Stripe configuration
        // GET: api/StripePay/KeyApi
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////

        [HttpGet]
        [Route("ApiKey")]
        public IEnumerable<string> GetApiKey()
        {
            // NLog 
            string message = $"(API Server) -Try to GET ApiKey for payment - Controller name: StripePayController; " +
                "Actionname: GetApiKey(...); HTTP method : HttpGet; Time: " + DateTime.Now + "\n\n";
            _logger.Info(message);

            string apiKey = null;
            try
            {
                apiKey = _configuration.GetValue<string>("Stripe:ApiKey");
                return new string[] { apiKey };
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

                return (IEnumerable<string>)StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

            }

        }

    }// End Class
}
