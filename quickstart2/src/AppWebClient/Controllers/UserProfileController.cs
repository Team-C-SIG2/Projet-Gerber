using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AppWebClient.Models;
using Microsoft.AspNetCore.Authentication;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System.Net.Mime;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;

namespace AppWebClient.Controllers
{
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
            string content = await client.GetStringAsync(_configuration["URLApi"] + "api/Customers/" + 2);

            Customer user = JsonConvert.DeserializeObject<Customer>(content);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
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
            string content = await client.GetStringAsync(_configuration["URLApi"] + "api/Customers/" + 2);

            Customer user = JsonConvert.DeserializeObject<Customer>(content);

            if (user == null)
            {
                return NotFound();
            }

            Customer customer = dbContext.Customers.Find(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind("Id,Acronyme,Firstname,Lastname,Address,Zip,City,Phone,Email,BillingAddress")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                dbContext.Entry(customer).State = EntityState.Modified;
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }
    }
}