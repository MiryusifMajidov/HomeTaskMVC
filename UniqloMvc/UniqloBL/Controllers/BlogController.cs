using Microsoft.AspNetCore.Mvc;

namespace UniqloBL.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
