

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
        private string _url = $"api/Dashboard/";

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

        [Route("ChartAppreciations")]
        public async Task<IActionResult> ChartAppreciations()
        {
            // ADD SECURITY 
            string accessToken = await HttpContext.GetTokenAsync("access_token");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            // GET LIST OF APPRECIATIONS
            List<DashboardViewModel> items = new List<DashboardViewModel>();
            string uri = _configuration["URLApi"] + _url + "ChartAppreciations";
            HttpResponseMessage response = await _client.GetAsync(uri);// HTTP GET
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result; // HTTP GET
                items = JsonConvert.DeserializeObject<List<DashboardViewModel>>(result);

            }
            else
            {
                return NotFound();
            }

            // GET TOTAL NUMBER OF APPRECIATIONS
            int nbAppreciations;
            string uriTotalAppreciations = _configuration["URLApi"] + _url + "TotalAppreciations";
            HttpResponseMessage responseTotalAppreciations = await _client.GetAsync(uriTotalAppreciations);// HTTP GET
            if (responseTotalAppreciations.IsSuccessStatusCode)
            {
                var resultTotalAppreciations = responseTotalAppreciations.Content.ReadAsStringAsync().Result; // HTTP GET
                nbAppreciations = JsonConvert.DeserializeObject<int>(resultTotalAppreciations);
            }
            else
            {
                return NotFound();
            }

            ViewBag.NBAPPRECIATIONS = nbAppreciations;
            return View(items);

        }

        // ---------------------------------------------------
        // -- Top 10 Best cities(whith most clients)
        // ---------------------------------------------------

        [Route("BestCities")]
        public async Task<IActionResult> BestCities()
        {
            // ADD SECURITY 
            string accessToken = await HttpContext.GetTokenAsync("access_token");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);


            // GET TOP 10 CITIES WITH MOST CUSTOMERS 
            List<DashboardViewModel> items = new List<DashboardViewModel>();
            string uri = _configuration["URLApi"] + _url + "BestCities";
            HttpResponseMessage response = await _client.GetAsync(uri);// HTTP GET
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result; // HTTP GET
                items = JsonConvert.DeserializeObject<List<DashboardViewModel>>(result);

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
            // ADD SECURITY 
            string accessToken = await HttpContext.GetTokenAsync("access_token");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);


            // GET TOP 10 CUSTOMERS 
            List<DashboardViewModel> itemsCustomers = new List<DashboardViewModel>();
            string uriCustomers = _configuration["URLApi"] + _url + "BestCustomers";
            HttpResponseMessage responseCustomers = await _client.GetAsync(uriCustomers);// HTTP GET
            if (responseCustomers.IsSuccessStatusCode)
            {
                var result = responseCustomers.Content.ReadAsStringAsync().Result; // HTTP GET
                itemsCustomers = JsonConvert.DeserializeObject<List<DashboardViewModel>>(result);

            }
            else
            {
                return NotFound();
            }


            // GET TOTAL NUMBER OF ORDERS IN THE DB
            int nbOrders;
            string uriTotalOrders = _configuration["URLApi"] + _url + "TotalOrders";
            HttpResponseMessage responseTotalOrders = await _client.GetAsync(uriTotalOrders);// HTTP GET
            if (responseTotalOrders.IsSuccessStatusCode)
            {
                var resultTotalCustomers = responseTotalOrders.Content.ReadAsStringAsync().Result; // HTTP GET
                nbOrders = JsonConvert.DeserializeObject<int>(resultTotalCustomers);
            }
            else
            {
                return NotFound();
            }

            ViewBag.NBORDERS = nbOrders;
            return View(itemsCustomers);
        }




        // ---------------------------------------------------
        // -- Top 10 Best Customers / Buyer 
        // ---------------------------------------------------

        [Route("ChartOrders")]
        public async Task<IActionResult> ChartOrders()
        {
            // ADD SECURITY 
            string accessToken = await HttpContext.GetTokenAsync("access_token");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);


            // GET ORDERS BY YEARS 
            List<DashboardViewModel> itemsOrders = new List<DashboardViewModel>();
            string uriOrders = _configuration["URLApi"] + _url + "ChartOrders";
            HttpResponseMessage responseOrders = await _client.GetAsync(uriOrders);// HTTP GET
            if (responseOrders.IsSuccessStatusCode)
            {
                var resultOrders = responseOrders.Content.ReadAsStringAsync().Result; // HTTP GET
                itemsOrders = JsonConvert.DeserializeObject<List<DashboardViewModel>>(resultOrders);

            }
            else
            {
                return NotFound();
            }

            ViewData["CHARTORDERS"] = itemsOrders; // Send this list to the view
            return View(itemsOrders);
        }


        // ---------------------------------------------------
        // -- Top 10 Books Categories
        // ---------------------------------------------------

        [Route("RankCategories")]
        public async Task<IActionResult> RankCategories()
        {
            // ADD SECURITY 
            string accessToken = await HttpContext.GetTokenAsync("access_token");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);


            // GET TOP 10 CUSTOMERS 
            List<DashboardViewModel> itemRankCategories = new List<DashboardViewModel>();
            string uriRankCategories = _configuration["URLApi"] + _url + "RankCategories";
            HttpResponseMessage responseRankCategories = await _client.GetAsync(uriRankCategories);// HTTP GET
            if (responseRankCategories.IsSuccessStatusCode)
            {
                var result = responseRankCategories.Content.ReadAsStringAsync().Result; // HTTP GET
                itemRankCategories = JsonConvert.DeserializeObject<List<DashboardViewModel>>(result);

            }
            else
            {
                return NotFound();
            }

            // GET TOTAL NUMBER OF BOOKS IN THE DB
            int nbStocks;
            string uriTotalStocks = _configuration["URLApi"] + _url + "TotalStocks";
            HttpResponseMessage responseTotalStocks = await _client.GetAsync(uriTotalStocks);// HTTP GET
            if (responseTotalStocks.IsSuccessStatusCode)
            {
                var resultTotalStocks = responseTotalStocks.Content.ReadAsStringAsync().Result; // HTTP GET
                nbStocks = JsonConvert.DeserializeObject<int>(resultTotalStocks);
            }
            else
            {
                return NotFound();
            }


            ViewBag.dataSource = itemRankCategories; 
            ViewBag.NBSTOCKS = nbStocks;
            return View(itemRankCategories);
        }

        // ---------------------------------------------------
        // -- Format States
        // ---------------------------------------------------

        [Route("RankFormats")]
        public async Task<IActionResult> RankFormats()
        {
            // ADD SECURITY 
            string accessToken = await HttpContext.GetTokenAsync("access_token");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);


            // GET TOP 10 CUSTOMERS 
            List<DashboardViewModel> itemRankFormats = new List<DashboardViewModel>();
            string uriRankFormats = _configuration["URLApi"] + _url + "RankFormats";
            HttpResponseMessage responseRankFormats = await _client.GetAsync(uriRankFormats);// HTTP GET

            if (responseRankFormats.IsSuccessStatusCode)
            {
                var result = responseRankFormats.Content.ReadAsStringAsync().Result; // HTTP GET
                itemRankFormats = JsonConvert.DeserializeObject<List<DashboardViewModel>>(result);

            }
            else
            {
                return NotFound();
            }

            // GET TOTAL NUMBER OF BOOKS IN THE DB
            int nbStocks;
            string uriTotalStocks = _configuration["URLApi"] + _url + "TotalStocks";
            HttpResponseMessage responseTotalStocks = await _client.GetAsync(uriTotalStocks);// HTTP GET
            if (responseTotalStocks.IsSuccessStatusCode)
            {
                var resultTotalStocks = responseTotalStocks.Content.ReadAsStringAsync().Result; // HTTP GET
                nbStocks = JsonConvert.DeserializeObject<int>(resultTotalStocks);
            }
            else
            {
                return NotFound();
            }

            ViewBag.NBSTOCKS = nbStocks;
            return View(itemRankFormats);
        }


        // ---------------------------------------------------
        // -- Format States
        // ---------------------------------------------------

        [Route("RankGenres")]
        public async Task<IActionResult> RankGenres()
        {
            // ADD SECURITY 
            string accessToken = await HttpContext.GetTokenAsync("access_token");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);


            // GET TOP 10 CUSTOMERS 
            List<DashboardViewModel> itemRankGenres = new List<DashboardViewModel>();
            string uriRankGenres = _configuration["URLApi"] + _url + "RankGenres";
            HttpResponseMessage responseRankGenres = await _client.GetAsync(uriRankGenres);// HTTP GET

            if (responseRankGenres.IsSuccessStatusCode)
            {
                var result = responseRankGenres.Content.ReadAsStringAsync().Result; // HTTP GET
                itemRankGenres = JsonConvert.DeserializeObject<List<DashboardViewModel>>(result);
            }
            else
            {
                return NotFound();
            }

            // GET TOTAL NUMBER OF BOOKS IN THE DB
            int nbStocks;
            string uriTotalStocks = _configuration["URLApi"] + _url + "TotalStocks";
            HttpResponseMessage responseTotalStocks = await _client.GetAsync(uriTotalStocks);// HTTP GET
            if (responseTotalStocks.IsSuccessStatusCode)
            {
                var resultTotalStocks = responseTotalStocks.Content.ReadAsStringAsync().Result; // HTTP GET
                nbStocks = JsonConvert.DeserializeObject<int>(resultTotalStocks);
            }
            else
            {
                return NotFound();
            }

            ViewBag.NBSTOCKS = nbStocks;
            return View(itemRankGenres);
        }




        // ---------------------------------------------------
        // -- Stock States
        // ---------------------------------------------------

        [Route("StockAvailability")]
        public async Task<IActionResult> StockAvailability()
        {
            // ADD SECURITY 
            string accessToken = await HttpContext.GetTokenAsync("access_token");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);


            // GET TOP 10 CUSTOMERS 
            List<DashboardViewModel> itemStockAvailability = new List<DashboardViewModel>();
            string uriStockAvailability = _configuration["URLApi"] + _url + "StockAvailability";
            HttpResponseMessage responseStockAvailability = await _client.GetAsync(uriStockAvailability);// HTTP GET

            if (responseStockAvailability.IsSuccessStatusCode)
            {
                var result = responseStockAvailability.Content.ReadAsStringAsync().Result; // HTTP GET
                itemStockAvailability = JsonConvert.DeserializeObject<List<DashboardViewModel>>(result);
            }
            else
            {
                return NotFound();
            }

            // GET TOTAL NUMBER OF BOOKS IN THE DB
            int nbStocks;
            string uriTotalStocks = _configuration["URLApi"] + _url + "TotalStocks";
            HttpResponseMessage responseTotalStocks = await _client.GetAsync(uriTotalStocks);// HTTP GET
            if (responseTotalStocks.IsSuccessStatusCode)
            {
                var resultTotalStocks = responseTotalStocks.Content.ReadAsStringAsync().Result; // HTTP GET
                nbStocks = JsonConvert.DeserializeObject<int>(resultTotalStocks);
            }
            else
            {
                return NotFound();
            }

            ViewBag.NBSTOCKS = nbStocks;
            return View(itemStockAvailability);
        }


    }// End Class
}