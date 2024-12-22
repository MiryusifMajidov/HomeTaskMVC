using GameStore.BL.Services.Interfaces;
using GameStore.Model.DTOs.Comment;
using GameStore.Model.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GameStore.PL.Controllers
{
    public class ProductController : Controller
    {

        private readonly IService<Game> _gameContext;
        private readonly IService<Comment> _commentContext;

        public ProductController(IService<Game> gameContext, IService<Comment> commentContext)
        {
            _gameContext = gameContext;
            _commentContext = commentContext;
        }

        public async Task<IActionResult> Index()
        {
            var games =await _gameContext.GetAllAsync();
            return View(games);
        }
        public async Task<IActionResult> Detail(int id)
        {
            var product = await _gameContext.GetByIdAsync(id);
            if (product == null)
            {
               
                return NotFound("Product not found");
            }

            ViewBag.Comment =  await _commentContext.GetByCommentAsync(id);
            ViewBag.Product = product;
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> AddComment(CommentDto commentDto, int id)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userId == null)
            {
                return Unauthorized("You need to log in to add comments.");
            }

            var comment = new Comment
            {
                CommentMessage = commentDto.CommentMessage,
                UserId = userId,
                ProductId = id,
                CreateAt = DateTime.UtcNow,
            };

            await _commentContext.AddAsync(comment);
            return RedirectToAction(nameof(Detail), new { id = id });
        }
    }
}
