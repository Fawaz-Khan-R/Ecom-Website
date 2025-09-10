using System.Collections.Generic;
using System.Threading.Tasks;
using dotnetapp.Models;

namespace dotnetapp.Repositories
{
    public interface IProductRepository
    {
        Task<Product> GetProductByIdAsync(int id);
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task AddProductAsync(Product product);
        Task UpdateProductAsync(Product product);
        Task DeleteProductAsync(int id);

        Task<IEnumerable<Product>> GetBySellerIdAsync(int sellerId);
        Task<IEnumerable<Product>> GetApprovedProductsAsync();
        Task<IEnumerable<Product>> GetProductsByStatusAsync(ProductStatus status);
        Task<IEnumerable<Product>> SearchProductsAsync(string searchTerm, string category);
    }
}
