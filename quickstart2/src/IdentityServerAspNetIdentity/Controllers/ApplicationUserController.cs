using IdentityServerAspNetIdentity.Data;


// HB 
using IdentityServerAspNetIdentity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System.Linq;
using IdentityServerAspNetIdentity.Services;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Services;
using SendGrid.Helpers.Mail;
using SendGrid;
using System.Net.Mail;
using System.Net;
using System;
using Microsoft.AspNetCore.Authentication;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;
using Microsoft.Extensions.Configuration;

namespace IdentityServerAspNetIdentity.Controllers
{
    public class ApplicationUserController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ESBookshopContext _context;
        private readonly IEmailSender _emailSender;
        private readonly IConfiguration _configuration;
        private string resView;

        public ApplicationUserController(IConfiguration configuration, UserManager<ApplicationUser> userManager, ESBookshopContext context, IEmailSender emailSender, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
            _emailSender = emailSender;
            _configuration = configuration;
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
                            if (await _roleManager.RoleExistsAsync("Admin"))
                            {
                                await _roleManager.CreateAsync(new IdentityRole("Admin"));

                            }
                            await userMgr.AddToRoleAsync(checkUser, "Admin");
                            if (!result.Succeeded)
                            {
                                resView = "ErrorPassword";
                            }
                            else {
                                //var lastId = _context.AspNetUsers.Max(u => u.Id);
                                Log.Debug($"{checkUser.UserName} created");

                                /*ShoppingCart sp = new ShoppingCart {
                                    UserId = lastId,
                                    CreatedDate = DateTime.Now
                                };*/


                                /*_context.ShoppingCarts.Add(sp);
                                await _context.SaveChangesAsync();*/

                                resView = "CreateDone";
                                /*var token = await userMgr.GenerateEmailConfirmationTokenAsync(checkUser);
                                await userMgr.ConfirmEmailAsync(checkUser, token);*/
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
                        var basicCredential = new NetworkCredential("apikey", _configuration["sendgridApi"]);
                        string to = mail;
                        string from = "info.esbookshop@gmail.com";
                        MailMessage message = new MailMessage(from, to);
                        message.Subject = "Réinitialisation du mot de passe";
                        message.Body = "Cliquez sur ce lien pour réinitialiser votre MDP: <a href='" + callbackUrl + "'>Reinit</a>";
                        message.IsBodyHtml = true;
                        SmtpClient smtpClient = new SmtpClient("smtp.sendgrid.net", 25);
                        // Credentials are necessary if the server requires the client 
                        // to authenticate before it will send email on the client's behalf.
                        smtpClient.UseDefaultCredentials = false;
                        smtpClient.Credentials = basicCredential;
                        smtpClient.Send(message);

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
    }
}
