using Microsoft.AspNetCore.Mvc;

namespace FinalApojectTest4.App.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }
    }
}
