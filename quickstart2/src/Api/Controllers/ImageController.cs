using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        [HttpPost("upload")]
        public async Task<IActionResult> Post(IFormFile formFile)
        {
            long size = formFile.Sum(f => f.Length);

            var uploads = Path.Combine("/", "Images");

            if (formFile.Length > 0)
            {
                var filePath = Path.Combine(uploads, formFile.FileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await formFile.CopyToAsync(fileStream);
                    fileStream.Flush();
                }
            }

            return Ok();
        }
    }
}