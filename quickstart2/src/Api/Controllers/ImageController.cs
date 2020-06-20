namespace Api.Controllers
{
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System.IO;
    using System.Threading.Tasks;
    using NLog;
    using System;

    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        // NLog 
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        // //////////////////////////////////////////////////////////////////////////////////////////////////////// 
        // Initialize the IWebHostEnvironment Environment 
        // //////////////////////////////////////////////////////////////////////////////////////////////////////// 

        private readonly IWebHostEnvironment _hostingEnvironment;
        public ImageController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        // //////////////////////////////////////////////////////////////////////////////////////////////////////// 
        // POST : Image/S1/S2 
        // //////////////////////////////////////////////////////////////////////////////////////////////////////// 
        [HttpPost("{id}")]
        public async Task<IActionResult> Post(string id, IFormFile file)
        {
            // NLog 
            string message = $"(API Server) -Try to POST Image - Controller name: ImageController; " +
                "Actionname: Post(...); HTTP method : HttpPost; Time: " + DateTime.Now + "\n";
            _logger.Info(message);

            try
            {
                string root = Path.Combine(_hostingEnvironment.WebRootPath, "Images");
                string extension = ".jpg";
                string filePath = Path.Combine(root, id + extension);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                    fileStream.Flush();
                }
            }
            catch (Exception ex)
            {
                // NLog Framework Call 

                // LOG INFO 
                _logger.Info("INFORMATION DETAILS, Exception occured during operation : " + message);
                _logger.Info("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG WARN
                _logger.Warn("WARNING DETAILS, Exception occured during operation : " + message);
                _logger.Warn("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG ERROR
                _logger.Error("ERROR DETAILS, Exception occured during operation : " + message);
                _logger.Error("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG TRACE 
                _logger.Trace("WARNING DETAILS, Exception occured during operation : " + message);
                _logger.Trace("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG FATAL
                _logger.Fatal("FATAL DETAILS, Exception occured during operation : " + message);
                _logger.Fatal("EXCEPTION DETAILS: " + ex.Message + "\n");

                // LOG DEGUG 
                _logger.Debug("DEGUG DETAILS, Exception occured during operation : " + message);
                _logger.Debug("EXCEPTION DETAILS: " + ex.Message + "\n");

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

            return Ok();
        }

    } // END CLASS
}