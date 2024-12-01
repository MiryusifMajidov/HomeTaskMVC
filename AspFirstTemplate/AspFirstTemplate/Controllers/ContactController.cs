using Microsoft.AspNetCore.Mvc;

namespace AspFirstTemplate.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
