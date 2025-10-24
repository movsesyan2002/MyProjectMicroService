using CoreLayer.DTO_s.EngineDtos;
using CoreLayer.Interfaces.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NewCarShowRoomWeb.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EngineController : ControllerBase
{
    private readonly IEngineService _engineService;

    public EngineController(IEngineService engineService)
    {
        _engineService = engineService;
    }

    [HttpGet("GetAllEngines")]
    public async Task<ActionResult<IEnumerable<EngineDto>>> GetAllAsync()
    {
        var engines = await _engineService.GetAllAsync();
        if (!ModelState.IsValid) return NotFound();

        return Ok(engines);
    }

    [HttpGet("GetEngineById/{id}")]
    public async Task<ActionResult<EngineDto>> GetEngineByIdAsync(int id)
    {
        var engine = await _engineService.GetByIdAsync(id);
        if (!ModelState.IsValid) return NotFound();

        return Ok(engine);
    }

    [HttpGet("GetWithFuelType/{fueltype}")]
    public async Task<ActionResult<IEnumerable<EngineDto>>> GetEnginesWithFuelType(string fueltype)
    {
        var engines = await _engineService.GetByFuelTypeAsync(fueltype);
        if (!ModelState.IsValid) return NotFound("Fuel type existed");

        return Ok(engines);
    }
    
    [HttpGet("GetWithPower/{start:int}/{end:int}")]
    public async Task<ActionResult<IEnumerable<EngineDto>>> GetEnginesWithPowerRange(int start, int end)
    {
        var engines = await _engineService.GetWithPowerRange(start,end);
        if (!ModelState.IsValid) return NotFound("No Cars with this Power Range");

        return Ok(engines);
    }

    [HttpPost("CreateEngine")]
    public async Task<ActionResult<EngineDto>> CreateEngine([FromBody] CreateEngineDto dto)
    {
        var engine = await _engineService.CreateEngineAsync(dto);
        if (!ModelState.IsValid) return BadRequest();

        return Ok(engine);
    }
    
    [HttpPut("UpdateEngine")]
    public async Task<ActionResult<EngineDto>> UpdateEngine([FromBody] int id,[FromForm] UpdateEngineDto dto)
    {
        await _engineService.UpdateEngineAsync(id, dto);
        return Ok();
    }
    
    [HttpDelete("DeleteEngine/{id:int}")]
    public async Task<ActionResult<EngineDto>> DeleteEngine(int id)
    {
        await _engineService.DeleteEngineAsync(id);

        return Ok();
    }
}