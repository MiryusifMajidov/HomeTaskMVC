using Microsoft.AspNetCore.Mvc;

namespace UniqloBL.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
