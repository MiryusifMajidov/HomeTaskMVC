using Microsoft.AspNetCore.Mvc;

namespace KlinicProject.App.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
