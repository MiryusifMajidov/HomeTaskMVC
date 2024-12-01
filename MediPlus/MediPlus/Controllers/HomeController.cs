using Microsoft.AspNetCore.Mvc;

namespace MediPlus.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
