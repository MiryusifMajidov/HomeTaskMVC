using FinalApi.BL.Implementations.Interfaces;
using FinalApi.Model.DTOs.Product;
using FinalApi.Model.DTOs.Size;
using FinalApi.Model.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

       
        [HttpGet("getalldata")]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAllAsync();
            return Ok(products);
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var product = await _productService.GetByIdAsync(id);
                return Ok(product);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

       
        [HttpPost("addnewdata")]
        public async Task<IActionResult> Create([FromForm] CreateProductDto productDto)
        {
            try
            {
                 await _productService.AddAsync(productDto);
                return Ok(productDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

       
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromForm] Product product)
        {
            if (id != product.Id)
                return BadRequest("ID mismatch.");

            try
            {
                await _productService.UpdateAsync(product);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
        [HttpDelete("soft/{id}")]
        public async Task<IActionResult> SoftDelete(int id)
        {
            try
            {
                await _productService.SoftDeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        
        [HttpDelete("hard/{id}")]
        public async Task<IActionResult> HardDelete(int id)
        {
            try
            {
                await _productService.HardDeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }


    }
}
