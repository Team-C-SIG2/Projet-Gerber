namespace AppWebClient.Controllers
{
    using AppWebClient.ViewModel;
    using AppWebClient.Models;

    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;

    public class ChartsController : Controller
    {
        // Client HTTP
        private HttpClient _client = new HttpClient();

        // URL         
        private string _url = $"api/Charts/";

        // APPSETTING.JSON 
        private readonly IConfiguration _configuration;


        public ChartsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public IActionResult Index()
        {
            return View();
        }




        [Route("Appreciations")]
        // GET: Charts
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


    }// End Class 
}

