using Microsoft.AspNetCore.Mvc;

namespace MastersMVC.Areas.Admin.Controllers
{
    public class MasterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
