using CoreLayer.Models;

namespace CoreLayer.Interfaces.Repositories;

public interface IOrderRepository : IRepository<OrderModel>
{
    // Task<IEnumerable<OrderModel>> GetOrdersByCustomerIdAsync(int userId);
    Task<IEnumerable<OrderModel>> GetOrdersByDateRange(DateTime fromdate, DateTime todate);
    Task<IEnumerable<OrderModel>> GetOrdersByOrderIdAsync(int orderId);
}