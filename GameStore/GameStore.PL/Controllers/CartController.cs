using GameStore.BL.Services.Interfaces;
using GameStore.Model.DTOs;
using GameStore.Model.DTOs.Cart;
using GameStore.Model.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text.Json;

namespace GameStore.PL.Controllers
{
    public class CartController : Controller
    {
        private readonly IService<Game> _gameContext;

        public CartController(IService<Game> gameContext)
        {
            _gameContext = gameContext;
        }

        public async Task<IActionResult> Index()
        {
            var a = GetCartItems();

           ICollection<Cart> carts = new List<Cart>();
            foreach (var item in a)
            {
                var game = await _gameContext.GetByIdAsync(item.ProductId);
                if (game != null) 
                {
                    Cart cart = new Cart()
                    {
                        Id = game.Id,
                        Name = game.Title,
                        Price = game.Price,
                        Image = game.Image,
                        Guantity = item.Quantity,
                    };
                    carts.Add(cart);
                }
                
            }
            ViewBag.CartItems = carts;
            return View();
        }

        [HttpPost]
       
        public IActionResult DeleteCartItem(int id)
        {
            try
            {
                RemoveFromCart(id);
                return Ok(new { success = true });
            }
            catch
            {
                return BadRequest(new { success = false, message = "Məhsulu silmək alınmadı." });
            }
        }



        public IActionResult AddCart(int id)
        {
            AddToCart(id, 1);

            var a = GetCartCookie();

            return RedirectToAction(nameof(Index));
        }

        public void AddToCart(int productId, int quantity)
        {
            
            var cartItems = GetCartCookie();

           
            var existingItem = cartItems.FirstOrDefault(x => x.ProductId == productId);
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                
                cartItems.Add(new CartItem
                {
                    ProductId = productId,
                    Quantity = quantity
                });
            }

          
            SetCartCookie(cartItems);
        }



        public void SetCartCookie(List<CartItem> cartItems)
        {
            string jsonCart = JsonSerializer.Serialize(cartItems); 
            CookieOptions option = new CookieOptions
            {
                Expires = DateTime.Now.AddMinutes(60),
                HttpOnly = true,
                Secure = true
            };

            HttpContext.Response.Cookies.Append("Cart", jsonCart, option); 
        }


        public List<CartItem> GetCartItems()
        {
            return GetCartCookie();
        }

        public List<CartItem> GetCartCookie()
        {
            string jsonCart = HttpContext.Request.Cookies["Cart"];

            if (string.IsNullOrEmpty(jsonCart)) return new List<CartItem>();

            return JsonSerializer.Deserialize<List<CartItem>>(jsonCart); 
        }


       


        public void RemoveFromCart(int productId)
        {
           
            var cartItems = GetCartCookie();

           
            var itemToRemove = cartItems.FirstOrDefault(x => x.ProductId == productId);
            if (itemToRemove != null)
            {
                cartItems.Remove(itemToRemove);
            }

           
            SetCartCookie(cartItems);
        }







    }
}
