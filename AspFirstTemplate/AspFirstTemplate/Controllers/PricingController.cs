using Microsoft.AspNetCore.Mvc;

namespace AspFirstTemplate.Controllers
{
    public class PricingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
