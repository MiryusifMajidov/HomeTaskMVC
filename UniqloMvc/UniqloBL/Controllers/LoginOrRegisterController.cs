using Microsoft.AspNetCore.Mvc;

namespace UniqloBL.Controllers
{
    public class LoginOrRegisterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
