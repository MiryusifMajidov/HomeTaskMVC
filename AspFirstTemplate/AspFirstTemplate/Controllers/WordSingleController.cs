using Microsoft.AspNetCore.Mvc;

namespace AspFirstTemplate.Controllers
{
    public class WordSingleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
