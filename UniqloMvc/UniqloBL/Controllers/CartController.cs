using Microsoft.AspNetCore.Mvc;

namespace UniqloBL.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
