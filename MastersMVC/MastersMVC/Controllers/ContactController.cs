using Microsoft.AspNetCore.Mvc;

namespace MastersMVC.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
