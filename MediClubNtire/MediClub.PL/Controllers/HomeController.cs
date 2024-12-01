using Microsoft.AspNetCore.Mvc;

namespace MediClub.PL.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
