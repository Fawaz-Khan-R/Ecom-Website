using System.Collections.Generic;
using System.Linq;
using dotnetapp.Models;

namespace dotnetapp.Services
{
    public class OrderService : IOrderService
    {
        private readonly List<Order> _orders = new();
        public IEnumerable<Order> GetAllOrders() => _orders;
        public Order GetOrderById(int id) => _orders.FirstOrDefault(o => o.Id == id);
        public void CreateOrder(Order order)
        {
            order.Id = _orders.Count + 1;
            _orders.Add(order);
        }
        public void UpdateOrder(int id, Order order)
        {
            var existing = GetOrderById(id);
            if (existing != null)
            {
                existing.ProductId = order.ProductId;
                existing.Quantity = order.Quantity;
                existing.Status = order.Status;
            }
        }
        public void DeleteOrder(int id)
        {
            var order = GetOrderById(id);
            if (order != null)
                _orders.Remove(order);
        }
    }
}
