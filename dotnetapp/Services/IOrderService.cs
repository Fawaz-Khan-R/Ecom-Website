using System.Threading.Tasks;
using System.Collections.Generic;
using dotnetapp.Models;

namespace dotnetapp.Services
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetAllOrdersAsync();
        Task<Order> GetOrderByIdAsync(int id);
        // Other service methods
    }
}
