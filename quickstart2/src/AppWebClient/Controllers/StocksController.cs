using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using AppWebClient.Models;
using AppWebClient.ViewModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace AppWebClient.Controllers
{
    public class StocksController : Controller
    {
        private readonly IConfiguration _configuration;

        public StocksController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IActionResult> IndexAsync()
        {
            string accessToken = await HttpContext.GetTokenAsync("access_token");
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            string content = await client.GetStringAsync(_configuration["URLApi"] + "api/Stocks/BookStocks");

            List<BookStock> bookStocks = JsonConvert.DeserializeObject<List<BookStock>>(content);

            if (bookStocks == null)
            {
                return NotFound();
            }

            return View(bookStocks);
        }

        [HttpPost]
        public async Task<IActionResult> EditAsync(BookStock bookStock)
        {
            /*Stock stock = new Stock
            {
                Id = bookStock.IdStock,
                CurrentStock = bookStock.currentStock

            };*/

            string accessToken = await HttpContext.GetTokenAsync("access_token");
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            string content = await client.GetStringAsync(_configuration["URLApi"] + "api/Stocks/" + bookStock.IdStock);

            Stock stock = JsonConvert.DeserializeObject<Stock>(content);

            if (stock == null)
            {
                return NotFound();
            }
            else
            {
                stock.CurrentStock = bookStock.currentStock;
                string jsonString = System.Text.Json.JsonSerializer.Serialize<Models.Stock>(stock);

                StringContent httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PutAsync(_configuration["URLApi"] + "api/Stocks/" + stock.Id, httpContent);

                if (!response.IsSuccessStatusCode)
                {
                    return View("Error");
                }
            }

            return RedirectToAction("index");
        }
    }
}