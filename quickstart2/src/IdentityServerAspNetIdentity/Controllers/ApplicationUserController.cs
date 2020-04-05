using IdentityServerAspNetIdentity.Data;
using IdentityServerAspNetIdentity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace IdentityServerAspNetIdentity.Controllers
{
    public class ApplicationUserController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private string resView;
        
        public ApplicationUserController(UserManager<ApplicationUser> userManager) {
            _userManager = userManager;
            resView = "CreateDone";
        }

        public IActionResult Create()
        {
            return View();
        }


        public IActionResult CreateDone(ApplicationUser user)
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
                    
                    if (user.UserName == null)
                    {
                        resView = "ErrorUserName";
                    }
                    else
                    {
                        var checkUser = userMgr.FindByNameAsync(user.UserName).Result;
                        if (checkUser == null)
                        {
                            checkUser = user;
                            var result = userMgr.CreateAsync(checkUser, user.PasswordHash).Result;
                            if (!result.Succeeded)
                            {
                                resView = "ErrorPassword";
                            }
                            Log.Debug($"{checkUser.UserName} created");
                        }
                        else
                        {
                            Log.Debug($"{checkUser.UserName} already exists");
                        }
                    }                    
                }
            }
            return View(resView);
        }
    }
}