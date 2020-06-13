using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IWebHostEnvironment _hostingEnvironment;

        public ImageController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> Post(string id, IFormFile file)
        {
            string root = Path.Combine(_hostingEnvironment.WebRootPath, "Images");
            string extension = ".jpg";
            string filePath = Path.Combine(root, id + extension);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
                fileStream.Flush();
            }

            return Ok();
        }
    }
}