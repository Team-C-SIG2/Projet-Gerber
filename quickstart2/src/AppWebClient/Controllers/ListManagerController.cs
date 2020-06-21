using Microsoft.AspNetCore.Mvc;

namespace AppWebClient.Controllers
{
    public class ListManagerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
