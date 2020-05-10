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
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;

namespace AppWebClient.Controllers
{
    public class AspNetUsersController : Controller
    {
        private readonly IConfiguration _configuration;
        private ESBookshopContext dbContext = new ESBookshopContext();
        //private readonly ESBookshopContext _context;

        public AspNetUsersController(IConfiguration configuration)
        {
            //_context = context;
            _configuration = configuration;
        }

        //// GET: AspNetUsers
        //public async Task<IActionResult> Index()
        //{
        //    var eSBookshopContext = _context.AspNetUsers.Include(a => a.IdCustomerNavigation);
        //    return View(await eSBookshopContext.ToListAsync());
        //}

        // GET: AspNetUsers
        public async Task<IActionResult> Index()
        {
            string accessToken = await HttpContext.GetTokenAsync("access_token");
            ViewBag.json = accessToken;

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            string content = await client.GetStringAsync(_configuration["URLApi"] + "api/AspNetUsers");

            List<UserRoles> users = JsonConvert.DeserializeObject<List<UserRoles>>(content);


            if (users == null)
            {
                return NotFound();
            }

            return View(users);
        }

        // GET: AspNetUsers/Details/5
        public async Task<IActionResult> Details(string id)
        {
            string accessToken = await HttpContext.GetTokenAsync("access_token");
            ViewBag.json = accessToken;

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            string content = await client.GetStringAsync(_configuration["URLApi"] + "api/AspNetUsers/" + id);

            AspNetUser users = JsonConvert.DeserializeObject<AspNetUser>(content);


            if (users == null)
            {
                return NotFound();
            }

            return View(users);
        }

        //// GET: AspNetUsers/Details/5
        //public async Task<IActionResult> Details(string id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var aspNetUser = await _context.AspNetUsers
        //        .Include(a => a.IdCustomerNavigation)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (aspNetUser == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(aspNetUser);
        //}

        //// GET: AspNetUsers/Create
        //public IActionResult Create()
        //{
        //    ViewData["IdCustomer"] = new SelectList(_context.Customers, "Id", "Id");
        //    return View();
        //}

        //// POST: AspNetUsers/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,IdCustomer,Username,NormalizedUsername,Email,NormalizedEmail,EmailConfirmed,PasswordHash,SecurityStamp,ConcurrencyStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnd,LockoutEnabled,AccessFailedCount")] AspNetUser aspNetUser)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(aspNetUser);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["IdCustomer"] = new SelectList(_context.Customers, "Id", "Id", aspNetUser.IdCustomer);
        //    return View(aspNetUser);
        //}

        //// GET: AspNetUsers/Edit/5
        //public async Task<IActionResult> Edit(string id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var aspNetUser = await _context.AspNetUsers.FindAsync(id);
        //    if (aspNetUser == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["IdCustomer"] = new SelectList(_context.Customers, "Id", "Id", aspNetUser.IdCustomer);
        //    return View(aspNetUser);
        //}

        //// POST: AspNetUsers/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(string id, [Bind("Id,IdCustomer,Username,NormalizedUsername,Email,NormalizedEmail,EmailConfirmed,PasswordHash,SecurityStamp,ConcurrencyStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnd,LockoutEnabled,AccessFailedCount")] AspNetUser aspNetUser)
        //{
        //    if (id != aspNetUser.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(aspNetUser);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!AspNetUserExists(aspNetUser.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["IdCustomer"] = new SelectList(_context.Customers, "Id", "Id", aspNetUser.IdCustomer);
        //    return View(aspNetUser);
        //}

        //// GET: AspNetUsers/Delete/5
        //public async Task<IActionResult> Delete(string id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var aspNetUser = await _context.AspNetUsers
        //        .Include(a => a.IdCustomerNavigation)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (aspNetUser == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(aspNetUser);
        //}

        //// POST: AspNetUsers/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(string id)
        //{
        //    var aspNetUser = await _context.AspNetUsers.FindAsync(id);
        //    _context.AspNetUsers.Remove(aspNetUser);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool AspNetUserExists(string id)
        //{
        //    return _context.AspNetUsers.Any(e => e.Id == id);
        //}
    }
}
