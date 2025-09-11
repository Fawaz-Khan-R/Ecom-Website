using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using dotnetapp.Repositories;
using dotnetapp.Models;
using dotnetapp.DTOs;

namespace dotnetapp.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly IProductRequestRepository _productRequestRepository;

        public ProductService(IProductRepository productRepository, IMapper mapper, IProductRequestRepository productRequestRepository)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _productRequestRepository = productRequestRepository;
        }

        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
        {
            var products = await _productRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }

        public async Task<IEnumerable<ProductDto>> GetApprovedProductsAsync()
        {
            var products = await _productRepository.GetApprovedProductsAsync();
            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }

        public async Task<IEnumerable<ProductDto>> GetProductsBySellerAsync(int sellerId)
        {
            var products = await _productRepository.GetBySellerIdAsync(sellerId);
            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }

        public async Task<ProductDto> UpdateProductAsync(int id, UpdateProductDto dto, int sellerId)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null || product.SellerId != sellerId)
                throw new UnauthorizedAccessException("Product not found or access denied.");

            _mapper.Map(dto, product);
            await _productRepository.UpdateAsync(product);

            return _mapper.Map<ProductDto>(product);
        }

        public async Task<IEnumerable<ProductDto>> SearchProductsAsync(string searchTerm, string category)
        {
            var products = await _productRepository.SearchAsync(searchTerm, category);
            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }

        public async Task<ProductDto> GetProductByIdAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            return _mapper.Map<ProductDto>(product);
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _productRepository.GetAllAsync().Result;
        }

        public Product GetProductById(int id)
        {
            return _productRepository.GetByIdAsync(id).Result;
        }

        public void CreateProduct(Product product)
        {
            _productRepository.AddAsync(product).Wait();
        }

        public void UpdateProduct(int id, Product product)
        {
            var existing = _productRepository.GetByIdAsync(id).Result;
            if (existing != null)
            {
                existing.Name = product.Name;
                existing.Price = product.Price;
                existing.Quantity = product.Quantity;
                existing.Status = product.Status;
                _productRepository.UpdateAsync(existing).Wait();
            }
        }

        public void DeleteProduct(int id)
        {
            _productRepository.DeleteProductAsync(id).Wait();
        }

        public async Task<ProductDto> CreateProductAsync(CreateProductDto dto, int sellerId)
        {
            var product = _mapper.Map<Product>(dto);
            product.SellerId = sellerId;
            await _productRepository.AddAsync(product);
            return _mapper.Map<ProductDto>(product);
        }
    }
}