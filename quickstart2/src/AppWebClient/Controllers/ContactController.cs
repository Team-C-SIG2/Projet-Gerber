using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AppWebClient.Services;
using AppWebClient.ViewModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace AppWebClient.Controllers
{
    public class ContactController : Controller
    {

        private readonly IConfiguration _configuration;

        public ContactController(IConfiguration configuration) {
            _configuration = configuration;
        }

        public async Task<IActionResult> IndexAsync()
        {
            string accessToken = await HttpContext.GetTokenAsync("access_token");

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            string idUser = await client.GetStringAsync(_configuration["URLApi"] + "api/AspNetUsers/UserId/");

            ViewBag.IdUser = idUser;
            return View();
        }

        public async Task<IActionResult> SendContact(ContactForm cf)
        {
            string subject = cf.IdUser+" - "+cf.Object;
            string body = cf.Body+" <br> <a href='mailto:"+cf.Email+"'>Répondre</a>";
            EmailSender es = new EmailSender(_configuration["sendgridApi"], _configuration["email"]);
            es.SendEmail(_configuration["email"], subject, body);
            return View();
        }
    }
}