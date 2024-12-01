using Microsoft.AspNetCore.Mvc;

namespace UniqloBL.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
