

namespace AppWebClient.Controllers
{


    using AppWebClient.ViewModel;

    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;


    public class DashboardController : Controller
    {
        // Client HTTP
        private HttpClient _client = new HttpClient();

        // URL         
        private string _url = $"api/Charts/";

        // APPSETTING.JSON 
        private readonly IConfiguration _configuration;

        // CONSTRUCTOR 
        public DashboardController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        // ---------------------------------------------------
        // -- Point d'entré du tableau de bord 
        // ---------------------------------------------------
        public IActionResult Index()
        {

            // Contenu de Charts/Appreciations 
            // Redirection 
            return View();
        }


        // ---------------------------------------------------
        // -- Evolutions des appréciations en années 
        // ---------------------------------------------------

        [Route("Appreciations")]
        public async Task<IActionResult> Appreciations()
        {
            List<ChartViewModel> items = new List<ChartViewModel>();

            string accessToken = await HttpContext.GetTokenAsync("access_token");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            string uri = _configuration["URLApi"] + _url + "Appreciations";
            HttpResponseMessage response = await _client.GetAsync(uri);// HTTP GET


            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result; // HTTP GET
                items = JsonConvert.DeserializeObject<List<ChartViewModel>>(result);

            }
            else
            {
                return NotFound();
            }

            return View(items);
        }



        // ---------------------------------------------------
        // -- Top 10 Best cities(whith most clients)
        // ---------------------------------------------------

        [Route("BestCities")]
        public async Task<IActionResult> BestCities()
        {
            string accessToken = await HttpContext.GetTokenAsync("access_token");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);


            // GET TOP 10 CITIES WITH MOST CUSTOMERS 
            List<ChartViewModel> items = new List<ChartViewModel>();
            string uri = _configuration["URLApi"] + _url + "BestCities";
            HttpResponseMessage response = await _client.GetAsync(uri);// HTTP GET
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result; // HTTP GET
                items = JsonConvert.DeserializeObject<List<ChartViewModel>>(result);

            }
            else
            {
                return NotFound();
            }

            // GET TOTAL NUMBER OF CUSTOMERS IN THE DB
            int nbClients;
            string uriTotalCustomers = _configuration["URLApi"] + _url + "TotalCustomers";
            HttpResponseMessage responseTotalCustomers = await _client.GetAsync(uriTotalCustomers);// HTTP GET
            if (responseTotalCustomers.IsSuccessStatusCode)
            {
                var resultTotalCustomers = responseTotalCustomers.Content.ReadAsStringAsync().Result; // HTTP GET
                nbClients = JsonConvert.DeserializeObject<int>(resultTotalCustomers);
            }
            else
            {
                return NotFound();
            }

            // SELECT COUNT(*) FROM Customers;
            ViewBag.NBCLIENTS = nbClients;

            return View(items);
        }



        // ---------------------------------------------------
        // -- Top 10 Best Customers / Buyer 
        // ---------------------------------------------------

        [Route("BestCustomers")]
        public async Task<IActionResult> BestCustomers()
        {

            return View();
        }

    }// End Class
}