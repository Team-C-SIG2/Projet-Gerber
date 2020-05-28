using IdentityServerAspNetIdentity.Data;
// HB 
using IdentityServerAspNetIdentity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System.Linq;
using System;
using IdentityServerAspNetIdentity.ViewModels;
using System.Threading.Tasks;
using Twilio.Rest.Verify.V2.Service;
using IdentityServerAspNetIdentity.Services;
using Microsoft.Extensions.Options;

namespace IdentityServerAspNetIdentity.Controllers
{
    public class ApplicationUserController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ESBookshopContext _context;
        private readonly IConfiguration _configuration;
        private readonly TwilioVerifySettings _settings;
        private string resView;

        public ApplicationUserController(IOptions<TwilioVerifySettings> settings, IConfiguration configuration, UserManager<ApplicationUser> userManager, ESBookshopContext context, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
            _configuration = configuration;
            _settings = settings.Value;
            resView = "Error";
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
                        var checkUser = userMgr.FindByEmailAsync(user.Email).Result;
                        if (checkUser == null)
                        {
                            Customer newCust = new Customer();

                            /* Prod only
                            newCust.Id = _context.Customers.Max(u => u.Id)+1;
                            */
                            _context.Customers.Add(newCust);
                            await _context.SaveChangesAsync();
                            user.IdCustomer = _context.Customers.Max(u => u.Id);

                            checkUser = user;
                            var result = userMgr.CreateAsync(checkUser, user.PasswordHash).Result;
                            if (checkUser.UserName.Contains("alice"))
                            {
                                if (await _roleManager.RoleExistsAsync("Admin"))
                                {
                                    await _roleManager.CreateAsync(new IdentityRole("Admin"));
                                }
                                await userMgr.AddToRoleAsync(checkUser, "Admin");
                            }
                            else
                            {
                                if (await _roleManager.RoleExistsAsync("User"))
                                {
                                    await _roleManager.CreateAsync(new IdentityRole("User"));
                                }
                                await userMgr.AddToRoleAsync(checkUser, "User");
                            }

                            if (!result.Succeeded)
                            {
                                resView = "ErrorPassword";
                            }
                            else {
                                Log.Debug($"{checkUser.UserName} created");

                                ShoppingCart sp = new ShoppingCart
                                {
                                    UserId = checkUser.Id,
                                    CreatedDate = DateTime.Now
                                };
                                _context.ShoppingCarts.Add(sp);
                                await _context.SaveChangesAsync();

                                Wishlist wl = new Wishlist
                                {
                                    UserId = checkUser.Id,
                                    CreatedDate = DateTime.Now
                                };
                                _context.Wishlists.Add(wl);
                                await _context.SaveChangesAsync();

                                
                                var code = await userMgr.GenerateEmailConfirmationTokenAsync(checkUser);
                                var callbackUrl = Url.Action("ConfirmEmailAsync", "ApplicationUser", new EmailConfirmViewModel { UserId = checkUser.Id, code = code}, "http");
                                string subject = "Confirmez votre email";
                                string body = "Cliquez sur ce lien pour confirmmer votre email: <a href='" + callbackUrl + "'>Reinit</a>";
                                EmailSender es = new EmailSender(_configuration["sendgridApi"], _configuration["email"]);
                                es.SendEmail(checkUser.Email, subject, body);

                                resView = "CreateDone";
                            }
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

        public async Task<IActionResult> ConfirmEmailSendAsync(string id)
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
                    var userMgr = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                    var user = await userMgr.FindByIdAsync(id);
                    if (!user.EmailConfirmed) {
                        var code = await userMgr.GenerateEmailConfirmationTokenAsync(user);
                        var callbackUrl = Url.Action("ConfirmEmail", "ApplicationUser", new EmailConfirmViewModel { UserId = user.Id, code = code }, "http");
                        string subject = "Confirmez votre email";
                        string body = "Cliquez sur ce lien pour confirmmer votre email: <a href='" + callbackUrl + "'>Reinit</a>";
                        EmailSender es = new EmailSender(_configuration["sendgridApi"], _configuration["email"]);
                        es.SendEmail(user.Email, subject, body);
                    }
                    else
                    {
                        return View("ConfirmEmailDone");
                    }
                }
            }
            return View("ConfirmEmailSend");
        }


        public async Task<IActionResult> ConfirmEmailAsync(EmailConfirmViewModel ec)
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
                    var userMgr = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                    var user = await userMgr.FindByIdAsync(ec.UserId);
                    await userMgr.ConfirmEmailAsync(user, ec.code);
                }
            }
            return View();
        }

        public IActionResult ResetPwdForm(ResetPwdViewModel pwdModel)
        {
            ViewBag.id = pwdModel.UserId;
            ViewBag.code = pwdModel.code;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ResetPwdMailAsync(string mail)
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
                    var checkUser = userMgr.FindByEmailAsync(mail).Result;
                    if (checkUser != null)
                    {
                        var code = await userMgr.GeneratePasswordResetTokenAsync(checkUser);
                        var callbackUrl = Url.Action("ResetPwdForm", "ApplicationUser", new ResetPwdViewModel { UserId = checkUser.Id, code = code }, "http");
                        string subject = "Réinitialisation du mot de passe";
                        string body = "Cliquez sur ce lien pour réinitialiser votre MDP: <a href='" + callbackUrl + "'>Reinit</a>";
                        EmailSender es = new EmailSender(_configuration["sendgridApi"], _configuration["email"]);
                        es.SendEmail(mail, subject, body);

                    }
                }
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ResetPwdConfirmAsync(ResetPwdViewModel pwdModel)
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
                    var checkUser = userMgr.FindByIdAsync(pwdModel.UserId).Result;
                    var result = await userMgr.ResetPasswordAsync(checkUser, pwdModel.code, pwdModel.newPwd);
                    var rst = result;
                }
                return View();
            }



        }// End Class 

        public async Task<IActionResult> VerifyPhoneAsync()
        {
            await LoadPhoneNumber();
            SMSVerification model = new SMSVerification();
            model.PhoneNumber = PhoneNumber;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> PostVerifyPhoneModelAsync()
        {
            await LoadPhoneNumber();
            SMSVerification model = new SMSVerification();
            try
            {
                VerificationResource verification = await VerificationResource.CreateAsync(
                    to: PhoneNumber,
                    channel: "sms",
                    pathServiceSid: _settings.VerificationServiceSID
                );

                if (verification.Status == "pending")
                {
                    model.PhoneNumber = PhoneNumber;
                    return View("ConfirmPhone", model);
                }

                ModelState.AddModelError("", $"Your verification is not pending, please constact admin");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "There was an error sending the verification code, please contact admin");
            }
            return View("VerifyPhone", model);
        }

        [HttpPost]
        public async Task<IActionResult> PostVerifyPhoneCodeAsync(SMSVerification input)
        {
            await LoadPhoneNumber();
            if (!ModelState.IsValid)
            {
                return View("ConfirmPhone", input);
            }

            try
            {
                VerificationCheckResource verification = await VerificationCheckResource.CreateAsync(
                    to: PhoneNumber,
                    code: input.VerificationCode,
                    pathServiceSid: _settings.VerificationServiceSID
                );
                if (verification.Status == "approved")
                {
                    var identityUser = await _userManager.GetUserAsync(User);
                    identityUser.PhoneNumberConfirmed = true;
                    var updateResult = await _userManager.UpdateAsync(identityUser);

                    if (updateResult.Succeeded)
                    {
                        ViewBag.urlAppWeb = _configuration["URLAppWeb"];
                        return View("ConfirmPhoneSuccess");
                    }
                    else
                    {
                        ModelState.AddModelError("", "There was an error confirming the verification code, please try again");
                    }
                }
                else
                {
                    ModelState.AddModelError("", $"There was an error confirming the verification code: {verification.Status}");
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("",
                    "There was an error confirming the code, please check the verification code is correct and try again");
            }

            return View("ConfirmPhone", input);
        }

        public string PhoneNumber { get; set; }
        private async Task LoadPhoneNumber()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new Exception($"Unable to load user with ID");
            }
            PhoneNumber = user.PhoneNumber;
        }
    }
}
