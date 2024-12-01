using Microsoft.AspNetCore.Mvc;

namespace MediClub.PL.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
	{
		
		public IActionResult Index()
		{
			return View();
		}
	}
}
