using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Contexts;
using WebAPI.Data;

namespace WebAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly ProductContext _context;

        public ProductService(ProductContext context)
        {
            _context = context;
        }

        public async Task<Product> AddAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<List<Product>> CategoryIdWithProduct(int categoryId)
        {
            var products = _context.Products.Where(x => x.CategoryId == categoryId).ToListAsync();
            return await products;
        }

        public async Task<Product> DeleteAsync(Product product)
        {
            var checkEntity = await _context.Products.FindAsync(product.Id);
            if (checkEntity != null)
            {
                _context.Products.Remove(checkEntity);
                _context.SaveChanges();
                return product;
            }
            return null;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _context.Products.AsNoTracking().ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            var checkEntity = await _context.Products.AsNoTracking().FirstOrDefaultAsync(x=> x.Id==id);
            if (checkEntity != null)
            {
                return checkEntity;
            }
            return null;
        }

        public async Task<Product> UpdateAsync(Product product)
        {
            var checkEntity = await _context.Products.FindAsync(product.Id);
            if (checkEntity != null)
            {
                _context.Entry(checkEntity).CurrentValues.SetValues(product);
                await _context.SaveChangesAsync();
                return product;
            }
            return null;
        }
    }
}
