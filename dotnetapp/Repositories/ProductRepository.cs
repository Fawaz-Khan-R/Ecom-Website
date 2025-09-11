using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using dotnetapp.DbContext;
using dotnetapp.Models;

namespace dotnetapp.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public new readonly ApplicationDbContext _context;
        public new readonly DbSet<Product> _dbSet;

        public ProductRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
            _dbSet = _context.Set<Product>();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task AddProductAsync(Product product)
        {
            await _dbSet.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProductAsync(Product product)
        {
            _dbSet.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(int id)
        {
            var product = await _dbSet.FindAsync(id);
            if (product != null)
            {
                _dbSet.Remove(product);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Product>> GetBySellerIdAsync(int sellerId)
        {
            return await _dbSet
                .Where(p => p.SellerId == sellerId)
                .Include(p => p.Seller)
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetApprovedProductsAsync()
        {
            return await _dbSet
                .Where(p => p.Status.Equals(dotnetapp.Models.ProductStatus.Approved) && p.Quantity > 0)
                .Include(p => p.Seller)
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> SearchAsync(string searchTerm, string category)
        {
            var query = _dbSet.Where(p => p.Status.Equals(dotnetapp.Models.ProductStatus.Approved));

            if (!string.IsNullOrEmpty(searchTerm))
            {
                query = query.Where(p => p.Name.Contains(searchTerm) || p.Description.Contains(searchTerm));
            }

            if (!string.IsNullOrEmpty(category))
            {
                query = query.Where(p => p.Category == category);
            }

            return await query.Include(p => p.Seller).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByStatusAsync(ProductStatus status)
        {
            return await _dbSet
                .Where(p => p.Status.Equals(status))
                .Include(p => p.Seller)
                .ToListAsync();
        }
    }
}
