using Microsoft.AspNetCore.Mvc;

namespace MastersMVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
