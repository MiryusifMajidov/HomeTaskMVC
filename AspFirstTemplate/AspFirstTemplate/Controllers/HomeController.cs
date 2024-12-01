using Microsoft.AspNetCore.Mvc;

namespace AspFirstTemplate.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
