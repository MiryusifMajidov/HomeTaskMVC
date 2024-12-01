using Microsoft.AspNetCore.Mvc;

namespace MVCTask1._1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
             
            return View();
        }
    }
}
