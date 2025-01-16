using Microsoft.AspNetCore.Mvc;

namespace FinalApojectTest4.App.Areas.Admin.Controllers
{
    public class DoctorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
