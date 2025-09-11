using System.Collections.Generic;
using dotnetapp.Models;

namespace dotnetapp.Services
{
    public interface IOrderService
    {
        IEnumerable<Order> GetAllOrders();
        Order GetOrderById(int id);
        void CreateOrder(Order order);
        void UpdateOrder(int id, Order order);
        void DeleteOrder(int id);
    }
}
