using FinalApi.BL.Implementations.Interfaces;
using FinalApi.Model.DTOs.Category;
using FinalApi.Model.DTOs.Size;
using FinalApi.Model.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SizeController : ControllerBase
    {
        private readonly ISizeService _sizeService;

        public SizeController(ISizeService sizeService)
        {
            _sizeService = sizeService;
        }


        [HttpGet("getalldata")]
        //[Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> GetAll()
        {
            var sizes = await _sizeService.GetAllAsync();
            return Ok(sizes);
        }

        [HttpGet("{id}")]
        //[Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> GetById(int id)
        {
            var size = await _sizeService.GetByIdAsync(id);
            return Ok(size);
        }


        [HttpPost("addednewdata")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Add(SizeDto sizeDto)
        {
            await _sizeService.AddAsync(sizeDto);
            return Ok("Category added successfully!");
        }

        [HttpPut("edit/{id}")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(SizeDto size, int id)
        {
            Size sizeUpdate = new Size()
            {
                Id = id ,
                Name = size.Name
            };
            await _sizeService.UpdateAsync(sizeUpdate);
            return Ok("Category updated successfully!");
        }

        [HttpDelete("{id}/hard")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> HardDelete(int id)
        {
            await _sizeService.HardDeleteAsync(id);
            return Ok("Category hard-deleted successfully!");
        }

        [HttpDelete("{id}/soft")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> SoftDelete(int id)
        {
            await _sizeService.SoftDeleteAsync(id);
            return Ok("Category soft-deleted successfully!");
        }




    }
}
