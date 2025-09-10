using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using dotnetapp.Data;
using dotnetapp.Models;

namespace dotnetapp.Repositories
{


public interface IProductRepository 
{
    Product GetProductById(int id);
    IEnumerable<Product> GetAllProducts();
    void AddProduct(Product product);
    void UpdateProduct(Product product);
    void DeleteProduct(int id);

    // Your async methods
    Task<IEnumerable<Product>> GetBySellerIdAsync(int sellerId);
    Task<IEnumerable<Product>> GetApprovedProductsAsync();
    Task<IEnumerable<Product>> GetProductsByStatusAsync(ProductStatus status);
    Task<IEnumerable<Product>> SearchProductsAsync(string searchTerm, string category);
}
}