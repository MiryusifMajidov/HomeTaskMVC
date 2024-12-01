using Microsoft.AspNetCore.Mvc;

namespace UniqloBL.Controllers
{
    public class TeamController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
