using InanceBL.Services.Interfaces;
using InanceModels.Models;
using Microsoft.AspNetCore.Mvc;

namespace Inance.PL.Controllers
{
	public class HomeController : Controller
	{
		private readonly IService<ntiretest> _test;

		public HomeController(IService<ntiretest> test)
		{
			_test = test;
		}

		public async Task<IActionResult> Index()
		{
			var data = await _test.GetAllAsync();
			return View(data);
		}
	}
}
