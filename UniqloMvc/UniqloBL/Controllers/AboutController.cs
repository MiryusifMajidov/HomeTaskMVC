using Microsoft.AspNetCore.Mvc;

namespace UniqloBL.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
