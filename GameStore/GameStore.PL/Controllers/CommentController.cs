using GameStore.BL.Services.Interfaces;
using GameStore.Model.DTOs.Comment;
using GameStore.Model.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using System.Security.Claims;
using System.Security.Claims;

namespace GameStore.PL.Controllers
{
    public class CommentController : Controller
    {
        private readonly IService<Comment> _commentService;

        public CommentController(IService<Comment> commentService)
        {
            _commentService = commentService;
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(CommentDto commentDto, int Id)
        {


            Comment comment = new Comment()
            {
                CommentMessage = commentDto.CommentMessage,
                UserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value,
                ProductId = Id
            };


            await _commentService.AddAsync(comment);

         return View(comment);
        }

       
    }
}
