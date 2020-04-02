using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityModel;
using IdentityServerAspNetIdentity.Data;
using IdentityServerAspNetIdentity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;

namespace IdentityServerAspNetIdentity.Controllers
{
    public class ApplicationUserController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        
        public ApplicationUserController(UserManager<ApplicationUser> userManager) {
            _userManager = userManager;
        }

        public IActionResult Create()
        {
            return View();
        }


        public async Task<IActionResult> CreateDone(ApplicationUser user)
        {
            var services = new ServiceCollection();
            services.AddLogging();
            services.AddDbContext<ApplicationDbContext>(options =>
               options.UseSqlServer(Startup.ConnectionString));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            using (var serviceProvider = services.BuildServiceProvider())
            {
                using (var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
                {
                    var context = scope.ServiceProvider.GetService<ApplicationDbContext>();

                    var userMgr = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

                    var checkUser = userMgr.FindByNameAsync(user.UserName).Result;
                    if (checkUser == null)
                    {
                        
                        checkUser = user;
                        var result = userMgr.CreateAsync(checkUser, user.PasswordHash).Result; 
                        if (!result.Succeeded)
                        {
                            return View("Error");
                            //throw new Exception(result.Errors.First().Description);
                        }
                        else
                        {
                            //_logger.LogInformation("User created a new account with password.");

                           // var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                           // code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                            //var callbackUrl = Url.Action("Account", "ConfirmEmail", new { userId = user.Id, code = code }, Request.Scheme);

                            //string message = "Salut mon pote comment ca va ? si tu veux confirmer ton inscription c'est par <a href='" + callbackUrl + "'>ici</a>";
                            //await _emailSender.SendEmailAsync(user.Email, "Confirmer votre Email", message);

                        }
                        Log.Debug($"{checkUser.UserName} created");
                    }
                    else
                    {
                        Log.Debug($"{checkUser.UserName} already exists");
                    }
                }
            }
            return View();
            //return RedirectToAction("Index");
        }
    }
}