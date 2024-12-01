using Microsoft.AspNetCore.Mvc;

namespace MastersMVC.Areas.Admin.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
