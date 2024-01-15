using Microsoft.AspNetCore.Mvc;

namespace MultiplyWebAPI.Controllers
{
    public class HomeadvanceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
