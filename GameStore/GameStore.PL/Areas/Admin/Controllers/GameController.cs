using GameStore.BL.CustomExtension;
using GameStore.BL.Services.Implementations;
using GameStore.BL.Services.Interfaces;
using GameStore.Model.DTOs.Product;
using GameStore.Model.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.PL.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class GameController : Controller
    {
        

        private readonly IService<Game> _gameContext;

        public GameController(IService<Game> gameContext)
        {
            _gameContext = gameContext;
        }

        public async Task<IActionResult> Index()
        {
            var games = await _gameContext.GetAllAsync();
            
            return View(games);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateDto productCreateDto, IFormFile Image) 
        { 
            if (!ModelState.IsValid)
            {
                return View(productCreateDto);
            }

            var ImagePathName = await Image.FileUpload("wwwroot/Images/Game",5);

            Game game = new Game() 
            { 
                Title = productCreateDto.Title,
                Description = productCreateDto.Description,
                Price = productCreateDto.Price,
                Guantity = productCreateDto.Guantity,
                GameId = productCreateDto.GameId,
                Image = ImagePathName,
                CreateAt = DateTime.Now,

            };

            await _gameContext.AddAsync(game);

            return RedirectToAction("Index");
        }
    }
}
