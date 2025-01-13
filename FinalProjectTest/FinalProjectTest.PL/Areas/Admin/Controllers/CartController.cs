using FinalProjectTest.BL.Implementation.Interfaces;
using FinalProjectTest.Model.Dtos.CartDtos;
using FinalProjectTest.Model.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectTest.PL.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CartController : Controller
    {

        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        public async Task<IActionResult> Index()
        {

            var a = await _cartService.GetAllAsync();
            return View(a);
        }


        public IActionResult Create() 
        {

            return View();
        
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCartDto cart) 
        {
            if (!ModelState.IsValid) 
            {
                return View(cart);
            }
            await _cartService.InsertAsync(cart);
            return RedirectToAction("Index");   
        
        }

        public async Task<IActionResult> Delete(int Id)
        {
            await _cartService.DeleteAsync(Id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int Id)
        {

            var a = await _cartService.GetByIdAsync(Id);
            UpdateCartDto  cart = new UpdateCartDto()
            {
                Id = a.Id,
                Tittle = a.Tittle,
                Description = a.Description,
                Icon = a.Icon,
                ImageUrl = a.Image,
            };  

            return View(cart);
        }


        [HttpPost]
        public async Task<IActionResult> Update(UpdateCartDto cart)
        {
            if (!ModelState.IsValid)
            { 
                return View(cart);
            
            }

            await _cartService.UpdateAsync(cart);
            return RedirectToAction("Index");
        }
    }
}
