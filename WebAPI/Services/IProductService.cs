using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Data;

namespace WebAPI.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(int id);
        Task<Product> AddAsync(Product product);
        Task<Product> UpdateAsync(Product product);
        Task<Product> DeleteAsync(Product product);
        Task<List<Product>> CategoryIdWithProduct(int categoryId);

    }
}
