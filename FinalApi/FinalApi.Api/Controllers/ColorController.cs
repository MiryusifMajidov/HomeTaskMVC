using FinalApi.BL.Implementations.Interfaces;
using FinalApi.Model.DTOs.Category;
using FinalApi.Model.DTOs.Color;
using FinalApi.Model.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;

namespace FinalApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorController : ControllerBase
    {

        private readonly IColorService _colorService;

        public ColorController(IColorService colorService)
        {
            _colorService = colorService;
        }


        [HttpGet("getalldata")]
        //[Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> GetAll()
        {
            var colors = await _colorService.GetAllAsync();
            return Ok(colors);
        }

        [HttpGet("{id}")]
        //[Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> GetById(int id)
        {
            var color = await _colorService.GetByIdAsync(id);
            return Ok(color);
        }


        [HttpPost("addednewdata")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Add(ColorDto colorDto)
        {
            await _colorService.AddAsync(colorDto);
            return Ok("Category added successfully!");
        }

        [HttpPut("edit/{id}")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(ColorDto color, int id)
        {
            Model.Models.Color colorUpdate = new Model.Models.Color()
            {
                Id = id,
                Name = color.Name,
            };
            await _colorService.UpdateAsync(colorUpdate);
            return Ok("Category updated successfully!");
        }

        [HttpDelete("{id}/hard")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> HardDelete(int id)
        {
            await _colorService.HardDeleteAsync(id);
            return Ok("Category hard-deleted successfully!");
        }

        [HttpDelete("{id}/soft")]
       // [Authorize(Roles = "Admin")]
        public async Task<IActionResult> SoftDelete(int id)
        {
            await _colorService.SoftDeleteAsync(id);
            return Ok("Category soft-deleted successfully!");
        }
    }
}
