using Microsoft.AspNetCore.Mvc;

namespace GameStore.PL.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        
    }
}
