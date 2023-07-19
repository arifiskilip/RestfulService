using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Contexts;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ProductContext _context;

        public CategoriesController(ProductContext context)
        {
            _context = context;
        }
        [HttpGet("{id}/products")]
        public async Task<IActionResult> CategoryWithProducts(int id)
        {
            var result = await _context.Categories.Include(x => x.Products).ToListAsync();
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var data = await _context.Categories.ToListAsync();
            return Ok(data);
        }
    }
}
