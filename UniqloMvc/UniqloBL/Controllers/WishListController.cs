using Microsoft.AspNetCore.Mvc;

namespace UniqloBL.Controllers
{
    public class WishListController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
