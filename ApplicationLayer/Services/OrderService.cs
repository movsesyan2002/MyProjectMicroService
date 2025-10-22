using AutoMapper;
using CoreLayer.DTO_s.OrderDtos;
using CoreLayer.Exception;
using CoreLayer.Interfaces.Repositories;
using CoreLayer.Interfaces.ServiceInterfaces;
using CoreLayer.Models;

namespace ApplicationLayer.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;

    public OrderService(IOrderRepository orderRepository, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<OrderDto>> GetAllOrdersAsync()
        => _mapper.Map<IEnumerable<OrderDto>>(await _orderRepository.GetAlLAsync());

    public async Task<OrderDto> GetByIdAsync(int id)
    {
        if (id < 0) throw new BusinessRuleViolationException("Id is less than 0");
        var order = await _orderRepository.GetByIdAsync(id);
        if (order == null) throw new EntityNotFoundException($"Order with this {id} Id not found");
        return _mapper.Map<OrderDto>(order);
    }

    public async Task<OrderDto> CreateAsync(CreateOrderDto dto)
    {
        var entity = _mapper.Map<OrderModel>(dto);
        entity.OrderDate = DateTime.UtcNow;
        await _orderRepository.AddAsync(entity);
        return _mapper.Map<OrderDto>(entity);
    }

    public async Task UpdateAsync(int id, UpdateOrderDto dto)
    {
        if (id < 0) throw new BusinessRuleViolationException("Id is less than 0");

        var entity = await _orderRepository.GetByIdAsync(id);
        if (entity == null) throw new EntityNotFoundException($"Order with this {id} Id not found");

        _mapper.Map(dto, entity);
        _orderRepository.Update(entity);
    }

    public async Task DeleteAsync(int id)
    {
        if (id < 0) throw new BusinessRuleViolationException("Id is less than 0");

        var entity = await _orderRepository.GetByIdAsync(id);
        if (entity == null) throw new EntityNotFoundException($"Order with this {id} Id not found");

        _orderRepository.Remove(entity);
    }

    public async Task<IEnumerable<OrderDto>> GetByUserIdAsync(int userId)
    {
        if (userId < 0) throw new BusinessRuleViolationException("Id is less than 0");
    
        var result = await _orderRepository.GetOrdersByUserIdAsync(userId);
        if (result == null) throw new EntityNotFoundException($"User not fount with this {userId} Id");
        return _mapper.Map<IEnumerable<OrderDto>>(result);
    }

    public async Task<IEnumerable<OrderDto>> GetByWithCarsAsync(int orderId)
    {
        if (orderId < 0) throw new BusinessRuleViolationException("Id is less than 0");

        var result = await _orderRepository.GetOrdersByOrderIdAsync(orderId);
        if (result == null) throw new EntityNotFoundException($"Order with this {orderId} Id not found");
        
        return _mapper.Map<IEnumerable<OrderDto>>(result);
    }
}