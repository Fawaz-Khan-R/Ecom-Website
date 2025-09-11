using System.Collections.Generic;
using System.Threading.Tasks;
using dotnetapp.Models;

namespace dotnetapp.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(int id);
        Task<Product> AddAsync(Product product);
        Task UpdateAsync(Product product);
        Task<IEnumerable<Product>> SearchAsync(string searchTerm, string category);
        Task<IEnumerable<Product>> GetBySellerIdAsync(int sellerId);
        Task<IEnumerable<Product>> GetApprovedProductsAsync();
        Task<IEnumerable<Product>> GetProductsByStatusAsync(ProductStatus status);
    }
}
