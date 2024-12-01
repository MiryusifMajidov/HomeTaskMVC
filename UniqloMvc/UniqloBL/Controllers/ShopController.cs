using Microsoft.AspNetCore.Mvc;

namespace UniqloBL.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
