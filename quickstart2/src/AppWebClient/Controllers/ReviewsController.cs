using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppWebClient.Models;
using Microsoft.AspNetCore.Authentication;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Text;
using System.Net;
using AppWebClient.ViewModel;

namespace AppWebClient.Controllers
{
    public class ReviewsController : Controller
    {
        private readonly IConfiguration _configuration;

        public ReviewsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IActionResult> AdminIndex()
        {

            string accessToken = await HttpContext.GetTokenAsync("access_token");
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            string content = await client.GetStringAsync(_configuration["URLApi"] + "api/reviews/signaledreviews");

            List<BookReviews> signaledreviews = JsonConvert.DeserializeObject<List<BookReviews>>(content);

            if (signaledreviews == null)
            {
                return NotFound();
            }

            return View(signaledreviews);
        }


        public async Task<IActionResult> AcceptReview(int? id)
        {
            string accessToken = await HttpContext.GetTokenAsync("access_token");
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            string content = await client.GetStringAsync(_configuration["URLApi"] + "api/Reviews/" + id);

            Review review = JsonConvert.DeserializeObject<Review>(content);

            if (review == null)
            {
                return NotFound();
            }
            review.Signale = false;

            if (ModelState.IsValid)
            {
                string jsonString = System.Text.Json.JsonSerializer.Serialize<Review>(review);

                StringContent httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PutAsync(_configuration["URLApi"] + "api/Reviews/" + id, httpContent);
                if (response.StatusCode != HttpStatusCode.NoContent)
                {
                    return BadRequest();
                }
                return RedirectToAction("AdminIndex");
            }

            return RedirectToAction("AdminIndex");
        }

        public async Task<IActionResult> DeleteReview(int? id)
        {
            string accessToken = await HttpContext.GetTokenAsync("access_token");
            HttpClient client = new HttpClient();
            Review signaledreview = new Review();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            // HTTP DELETE
            HttpResponseMessage response = await client.DeleteAsync(_configuration["URLApi"] + "api/reviews/" + id);

            response.EnsureSuccessStatusCode();

            return RedirectToAction("AdminIndex");

        }
    }
}
