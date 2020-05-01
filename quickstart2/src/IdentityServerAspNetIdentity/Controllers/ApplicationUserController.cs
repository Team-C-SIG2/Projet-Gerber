using IdentityServerAspNetIdentity.Data;


// HB 
using IdentityServerAspNetIdentity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System.Linq;

namespace IdentityServerAspNetIdentity.Controllers
{
    public class ApplicationUserController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ESBookshopContext _context;
        private string resView;

        public ApplicationUserController(UserManager<ApplicationUser> userManager, ESBookshopContext context) {
            _userManager = userManager;
            _context = context;
            resView = "CreateDone";
        }
        public IActionResult Create()
        {
            return View();
        }
        public async System.Threading.Tasks.Task<IActionResult> CreateDoneAsync(ApplicationUser user)
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
                        Customer newCust = new Customer();
                        newCust.Lastname = null;
                        newCust.Firstname = null;
                        newCust.Acronyme = null;
                        newCust.Address = null;
                        newCust.BillingAddress = null;
                        newCust.City = null;
                        newCust.Phone = null;
                        newCust.Zip = null;
                        _context.Customers.Add(newCust);
                        await _context.SaveChangesAsync();
                        user.IdCustomer = _context.Customers.Max(u => u.Id);

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


    }// End Class 
}