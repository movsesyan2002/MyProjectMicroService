using CoreLayer.DTO_s.OrderDtos;
using CoreLayer.Interfaces.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NewCarShowRoomWeb.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet("GetAllCars")]
    public async Task<ActionResult<IEnumerable<OrderDto>>> GetAllAsync()
    {
        var orders = await _orderService.GetAllOrdersAsync();
        if (!ModelState.IsValid) return NotFound("Orders is Empty");

        return Ok(orders);
    }

    [HttpGet("GetCarById/{id:int}")]
    public async Task<ActionResult<OrderDto>> GetByIdAsync(int id)
    {
        var order = await _orderService.GetByIdAsync(id);
        if (!ModelState.IsValid) NotFound();

        return Ok(order);
    }

    [HttpGet("GetOrderByUserId")]
    public async Task<ActionResult<OrderDto>> GetByUserIdAsync(int userId)
    {
        var orders = await _orderService.GetByUserIdAsync(userId);

        return Ok(orders);
    }
    
    [HttpGet("GetWithCars/{id}")]
    public async Task<ActionResult<IEnumerable<OrderDto>>> GetWithCarsAsync(int id)
    {
        var orders = await _orderService.GetByWithCarsAsync(id);
        if (!ModelState.IsValid) return NotFound("Orders is Empty");

        return Ok(orders);
    }

    [HttpPost("CreateOrder")]
    public async Task<ActionResult<OrderDto>> CreateAsync([FromBody]CreateOrderDto dto)
    {
        var order = await _orderService.CreateAsync(dto);
        if (!ModelState.IsValid) return BadRequest();

        return Ok(order);
    }

    [HttpPut("UpdateOrder")]
    public async Task<ActionResult> UpdateAsync(int id,[FromForm] UpdateOrderDto dto)
    {
        await _orderService.UpdateAsync(id, dto);
        return Accepted();
    }

    [HttpDelete("DeleteOrder/{id:int}")]
    public async Task<ActionResult> DeleteAsync(int id)
    {
        await _orderService.DeleteAsync(id);
        return Accepted();
    }
}