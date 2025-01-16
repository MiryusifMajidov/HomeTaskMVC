using Microsoft.AspNetCore.Mvc;

namespace FinalApojectTest4.App.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
