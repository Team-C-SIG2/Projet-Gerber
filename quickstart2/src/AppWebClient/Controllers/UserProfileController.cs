using AppWebClient.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AppWebClient.Controllers
{
    [Authorize]
    public class UserProfileController : Controller
    {
        private readonly IConfiguration _configuration;
        private ESBookshopContext dbContext = new ESBookshopContext();

        public UserProfileController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // Retourne les infos du user reprises depuis l'API
        public async Task<IActionResult> Index()
        {
            string accessToken = await HttpContext.GetTokenAsync("access_token");
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            string content = await client.GetStringAsync(_configuration["URLApi"] + "api/Customers/");

            Customer customer = JsonConvert.DeserializeObject<Customer>(content);

            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: Movies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            string accessToken = await HttpContext.GetTokenAsync("access_token");

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            string content = await client.GetStringAsync(_configuration["URLApi"] + "api/Customers/");

            Customer user = JsonConvert.DeserializeObject<Customer>(content);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }
        

        public async Task<IActionResult> EmailConfirm()
        {
            string accessToken = await HttpContext.GetTokenAsync("access_token");

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            string idUser = await client.GetStringAsync(_configuration["URLApi"] + "api/AspNetUsers/UserId/");

            if (idUser == null)
            {
                return NotFound();
            }

            return Redirect(_configuration["URLIdentity"]+"ApplicationUser/ConfirmEmailSend/"+idUser);
        }

        public async Task<IActionResult> PhoneConfirm()
        {
            string accessToken = await HttpContext.GetTokenAsync("access_token");

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            string idUser = await client.GetStringAsync(_configuration["URLApi"] + "api/AspNetUsers/UserId/");

            if (idUser == null)
            {
                return NotFound();
            }

            return Redirect(_configuration["URLIdentity"] + "ApplicationUser/VerifyPhone/");
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("Id,Acronyme,Firstname,Lastname,Address,Zip,City,Phone,Email,BillingAddress")] Customer customer)
        {
            string accessToken = await HttpContext.GetTokenAsync("access_token");

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            string content = await client.GetStringAsync(_configuration["URLApi"] + "api/Customers/");

            Customer user = JsonConvert.DeserializeObject<Customer>(content);

            if (user == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                string jsonString = System.Text.Json.JsonSerializer.Serialize<Customer>(customer);

                StringContent httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PutAsync(_configuration["URLApi"] + "api/Customers/" + user.Id, httpContent);
                if (response.StatusCode != HttpStatusCode.NoContent)
                {
                    return BadRequest();
                }
                return RedirectToAction(nameof(Index));
            }

            return View(user);
        }
    }
}