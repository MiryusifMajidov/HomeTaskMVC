using Microsoft.AspNetCore.Mvc;

namespace MastersMVC.Controllers
{
    public class ServiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
