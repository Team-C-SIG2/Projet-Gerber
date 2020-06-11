using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using AppWebClient.Tools;
using AppWebClient.ViewModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace AppWebClient.Controllers
{
    public class ImgUploadController : Controller
    {
        // Var USERID 
        private readonly string UserID = "002078C2AB";

        // HTTPCLIENT 
        private HttpClient _client = new HttpClient();

        // URL 
        private string _url = "api/image/";

        private readonly IConfiguration _configuration;

        public ImgUploadController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UploadAsync(ICollection<IFormFile> files)
        {
            string accessToken = await HttpContext.GetTokenAsync("access_token");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            foreach (var file in files)
            {
                if (file.Length <= 0)
                    continue;

                var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');

                using (var content = new MultipartFormDataContent())
                {
                    content.Add(new StreamContent(file.OpenReadStream())
                    {
                        Headers =
                    {
                        ContentLength = file.Length,
                        ContentType = new MediaTypeHeaderValue(file.ContentType)
                    }
                    }, "File", fileName);

                    var response = await _client.PostAsync(_configuration["URLApi"] + "api/image/", content);
                }
            }
            return View();
        }
    }
}