using Microsoft.AspNetCore.Mvc;

namespace AspFirstTemplate.Controllers
{
    public class WorkController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
