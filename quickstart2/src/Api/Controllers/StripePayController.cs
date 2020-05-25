
namespace Api.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using System.Collections.Generic;

    [Route("api/[controller]")]
    [ApiController]

    [Authorize]
    public class StripePayController : ControllerBase
    {



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
            string publickey = _configuration.GetValue<string>("Stripe:PublishableKey");
            return new string[] { publickey };
        }



        // ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Return the ApiKey for Stripe configuration
        // GET: api/StripePay/KeyApi
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////

        [HttpGet]
        [Route("ApiKey")]
        public IEnumerable<string> GetApiKey()
        {
            string apiKey = _configuration.GetValue<string>("Stripe:ApiKey");
            return new string[] { apiKey };
        }




    }// End Class
}
