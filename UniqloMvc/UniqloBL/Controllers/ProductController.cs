using Microsoft.AspNetCore.Mvc;

namespace UniqloBL.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
