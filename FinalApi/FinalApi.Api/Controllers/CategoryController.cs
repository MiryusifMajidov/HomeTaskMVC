using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Authorization;

using FinalApi.BL.Implementations.Interfaces;
using FinalApi.Model.DTOs.Category;
using FinalApi.Model.Models;

namespace FinalApi.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    
    [HttpGet("getalldata")]
    //[Authorize]
    public async Task<IActionResult> GetAll()
    {
        var categories = await _categoryService.GetAllAsync();
        return Ok(categories);
    }

    [HttpGet("{id}")]
    //[Authorize(Roles = "Admin,User")]
    public async Task<IActionResult> GetById(int id)
    {
        var category = await _categoryService.GetByIdAsync(id);
        return Ok(category);
    }

    
    [HttpPost("addednewdata")]
    //[Authorize(Roles = "Admin")]
    public async Task<IActionResult> Add(CategoryDto categoryDto)
    {
        await _categoryService.AddAsync(categoryDto);
        return Ok("Category added successfully!");
    }

    [HttpPut("update/{id}")]
    //[Authorize(Roles = "Admin")]
    public async Task<IActionResult> Update(CategoryDto category, int id)
    {
        Category updateCategory = new Category()
        {
            Id = id,
            Name = category.Name,
        };
        await _categoryService.UpdateAsync(updateCategory);
        return Ok("Category updated successfully!");
    }

    [HttpDelete("{id}/hard")]
    //[Authorize(Roles = "Admin")]
    public async Task<IActionResult> HardDelete(int id)
    {
        await _categoryService.HardDeleteAsync(id);
        return Ok("Category hard-deleted successfully!");
    }

    [HttpDelete("{id}/soft")]
    //[Authorize(Roles = "Admin")]
    public async Task<IActionResult> SoftDelete(int id)
    {
        await _categoryService.SoftDeleteAsync(id);
        return Ok("Category soft-deleted successfully!");
    }
}
