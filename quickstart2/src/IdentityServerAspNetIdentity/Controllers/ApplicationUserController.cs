using IdentityServerAspNetIdentity.Data;


// HB 
using IdentityServerAspNetIdentity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using AppDbContext.Models;
using System.Linq;
using IdentityServerAspNetIdentity.Services;
using System.Threading.Tasks;

namespace IdentityServerAspNetIdentity.Controllers
{
    public class ApplicationUserController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly CoreDbContext _context;
        private string resView;

        public ApplicationUserController(UserManager<ApplicationUser> userManager, CoreDbContext context) {
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

        public IActionResult ResetPwd()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> MailSendAsync(string mail)
        {
            AuthMessageSenderOptions msgOpt = new AuthMessageSenderOptions();
            msgOpt.SendGridKey = "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";
            msgOpt.SendGridUser = "ESBookshop";

            EmailSender snd = new EmailSender(msgOpt);
            var subject = "Sending with SendGrid is Fun";
            var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
            await snd.SendEmailAsync(mail, subject, htmlContent);
            return View();
        }

    }// End Class 
}