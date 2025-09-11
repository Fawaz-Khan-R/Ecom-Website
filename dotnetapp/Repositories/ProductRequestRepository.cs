using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using dotnetapp.DbContext;
using dotnetapp.Models;

namespace dotnetapp.Repositories
{
    public class ProductRequestRepository : IProductRequestRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<ProductRequest> _dbSet;

        public ProductRequestRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<ProductRequest>();
        }

        public async Task AddAsync(ProductRequest request)
        {
            await _dbSet.AddAsync(request);
            await _context.SaveChangesAsync();
        }

        // Add other method implementations as needed
    }
}
