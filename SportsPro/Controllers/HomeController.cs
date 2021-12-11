using Microsoft.AspNetCore.Mvc;

namespace SportsPro.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        // Attribute Routing
        [Route("About")]
        public IActionResult About()
        {
            return View();
        }
    }
}