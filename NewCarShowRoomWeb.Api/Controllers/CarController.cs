using ApplicationLayer.Services;
using CoreLayer.DTO_s.CarDtos;
using CoreLayer.Interfaces.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace NewCarShowRoomWeb.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CarController : ControllerBase
{
    private readonly ICarService _carService;

    public CarController(ICarService service) => _carService = service;

    [HttpGet("GetAllCars")]
    public async Task<ActionResult<CarDto>> GetAll()
    {
        return Ok(await _carService.GetAllAsync());
    }

    [HttpGet("GetCarById/{id}")]
    public async Task<ActionResult<CarDto>> GetByIdAsync(int id)
    {
        return Ok(await _carService.GetByIdAsync(id));
    }

    [HttpGet("byyear/{start:int}/{end:int}")]
    public async Task<ActionResult<CarDto>> GetByYearAsync(int start, int end)
    {
        if (start > end)
        {
            return BadRequest("started cannot big from ended");
        }

        return Ok(await _carService.GetByYearRangeAsync(start, end));

    }

    [HttpGet("GetWithEngines")]
    public async Task<ActionResult<CarDto>> GetWithEngines()
    {
        var cars = await _carService.GetCarsWithEnginesAsync();
        if (!ModelState.IsValid) return BadRequest();

        return Ok(cars);
    }

    [HttpPost("CreateCar")]
    public async Task<IActionResult> Create([FromBody] CreateCarDto dto)
    {
        var result = await _carService.CreateAsync(dto);
        if (!ModelState.IsValid) return BadRequest();
        return Accepted(result);
    }

    [HttpPut("UpdateCar/{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateCarDto dto)
    {
        await _carService.UpdateCarAsync(id, dto);
        return NoContent();
    }

    [HttpDelete("DeleteCar/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _carService.DeleteAsync(id);
        return NoContent();
    }
}