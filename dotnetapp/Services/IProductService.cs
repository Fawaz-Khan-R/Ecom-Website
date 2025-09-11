using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using dotnetapp.DTOs;
using dotnetapp.Models;

namespace dotnetapp.Services
{

public interface IProductService
{
    Task<IEnumerable<ProductDto>> GetAllProductsAsync();
    Task<IEnumerable<ProductDto>> GetApprovedProductsAsync();
    Task<IEnumerable<ProductDto>> GetProductsBySellerAsync(int sellerId);
    Task<ProductDto> GetProductByIdAsync(int id);
    Task<ProductDto> CreateProductAsync(CreateProductDto dto, int sellerId);
    Task<ProductDto> UpdateProductAsync(int id, UpdateProductDto dto, int sellerId);
    Task<IEnumerable<ProductDto>> SearchProductsAsync(string searchTerm, string category);
        IEnumerable<Product> GetAllProducts();
        Product GetProductById(int id);
        void CreateProduct(Product product);
        void UpdateProduct(int id, Product product);
        void DeleteProduct(int id);
}


}