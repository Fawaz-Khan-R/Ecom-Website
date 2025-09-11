using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using dotnetapp.DbContext;
using dotnetapp.Models;

namespace dotnetapp.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Order> _dbSet;

        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<Order>();
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<Order> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task AddAsync(Order order)
        {
            await _dbSet.AddAsync(order);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Order order)
        {
            _dbSet.Update(order);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var order = await _dbSet.FindAsync(id);
            if (order != null)
            {
                _dbSet.Remove(order);
                await _context.SaveChangesAsync();
            }
        }
    }
}
