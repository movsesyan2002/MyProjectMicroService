using CoreLayer.DTO_s.OrderDtos;

namespace CoreLayer.Interfaces.ServiceInterfaces;

public interface IOrderService
{
    Task<IEnumerable<OrderDto>> GetByWithCarsAsync(int orderId);
    Task<IEnumerable<OrderDto>> GetByUserIdAsync(int userId);
    Task<IEnumerable<OrderDto>> GetAllOrdersAsync();
    Task<OrderDto> GetByIdAsync(int id);
    Task<OrderDto> CreateAsync(CreateOrderDto createdDto);
    Task UpdateAsync(int id, UpdateOrderDto updatedDto);
    Task DeleteAsync(int id);
}