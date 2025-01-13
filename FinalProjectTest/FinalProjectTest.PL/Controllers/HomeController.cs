using FinalProjectTest.BL.Implementation.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectTest.PL.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICartService _cartService;

        public HomeController(ICartService cartService)
        {
            _cartService = cartService;
        }

        public async Task<IActionResult> Index()
        {
            
            ViewBag.Carts = await _cartService.GetAllAsync();
            return View();
        }
    }
}
