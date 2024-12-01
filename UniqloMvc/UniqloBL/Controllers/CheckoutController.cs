using Microsoft.AspNetCore.Mvc;

namespace UniqloBL.Controllers
{
    public class CheckoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
