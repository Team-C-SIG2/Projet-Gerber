using AppWebClient.Models;
using AppWebClient.ViewModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<IActionResult> Edit()
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
            UserProfilViewModel userProfil = new UserProfilViewModel
            {
                Id = user.Id,
                Firstname = user.Firstname,
                Lastname = user.Lastname,
                Address = user.Address,
                Zip = user.Zip,
                City = user.City,
                BillingAddress = user.BillingAddress,
                Email = user.AspNetUsers.FirstOrDefault().Email,
                PhoneNumber = user.AspNetUsers.FirstOrDefault().PhoneNumber
            };
            return View(userProfil);
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
        public async Task<IActionResult> Edit(UserProfilViewModel userProfilViewModel)
        {
            Customer customer = new Customer
            {
                Id = userProfilViewModel.Id,
                Firstname = userProfilViewModel.Firstname,
                Lastname = userProfilViewModel.Lastname,
                Address = userProfilViewModel.Address,
                Zip = userProfilViewModel.Zip,
                City = userProfilViewModel.City,
                BillingAddress = userProfilViewModel.BillingAddress
            };

            string accessToken = await HttpContext.GetTokenAsync("access_token");
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            string userId = await client.GetStringAsync(_configuration["URLApi"] + "api/AspNetUsers/UserId/");

            string users = await client.GetStringAsync(_configuration["URLApi"] + "api/AspNetUsers/" + userId);
            AspNetUser currentUser = JsonConvert.DeserializeObject<AspNetUser>(users);

            currentUser.Email = userProfilViewModel.Email;
            currentUser.NormalizedEmail = (userProfilViewModel.Email).ToUpper();
            currentUser.PhoneNumber = userProfilViewModel.PhoneNumber;

            string content = await client.GetStringAsync(_configuration["URLApi"] + "api/Customers/");
            Customer user = JsonConvert.DeserializeObject<Customer>(content);

            if (user == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                // Modification de la table Customers
                string jsonStringCustomer = System.Text.Json.JsonSerializer.Serialize<Customer>(customer);
                StringContent httpContentCustomer = new StringContent(jsonStringCustomer, Encoding.UTF8, "application/json");
                HttpResponseMessage responseCustomer = await client.PutAsync(_configuration["URLApi"] + "api/Customers/" + user.Id, httpContentCustomer);
                if (responseCustomer.StatusCode != HttpStatusCode.NoContent)
                {
                    return BadRequest();
                }

                // Modification de la table AspNetUsers (email et téléphone)
                string jsonStringUser = System.Text.Json.JsonSerializer.Serialize<AspNetUser>(currentUser);
                StringContent httpContentUser = new StringContent(jsonStringUser, Encoding.UTF8, "application/json");
                HttpResponseMessage responseUser = await client.PutAsync(_configuration["URLApi"] + "api/AspNetUsers/" + userId, httpContentUser);
                if (responseUser.StatusCode != HttpStatusCode.NoContent)
                {
                    return BadRequest();
                }

                return RedirectToAction(nameof(Index));
            }

            return View(user);
        }
    }
}