using Microsoft.AspNetCore.Mvc;

namespace MastersMVC.Areas.Admin.Controllers
{
    public class ServiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
