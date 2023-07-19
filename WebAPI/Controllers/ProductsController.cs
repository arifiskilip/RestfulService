using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;
using WebAPI.Data;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            return Ok(await _productService.GetAllAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var result = await _productService.GetByIdAsync(id);
            if (result == null)
            {
                return BadRequest($"{id} is not found!");
            }
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product)
        {
            var result = await _productService.AddAsync(product);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProduct(Product product)
        {
            var result = await _productService.UpdateAsync(product);
            if (result == null)
            {
                return BadRequest($"{product.Id} is not found!");
            }
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var chehckProduct = await _productService.GetByIdAsync(id);
            if (chehckProduct != null)
            {
                var result = await _productService.DeleteAsync(chehckProduct);
                return Ok(result);
            }     
         
            return BadRequest($"{id} not found!");
        }
        [HttpPost("file")]
        public async Task<IActionResult> UploadForm(IFormFile file)
        {
            var newName = Guid.NewGuid() + "." + Path.GetExtension(file.FileName);
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/files", newName);
            var stream = new FileStream(path, FileMode.Create);
            await file.CopyToAsync(stream);
            return Ok(file);
        }

    }
}
