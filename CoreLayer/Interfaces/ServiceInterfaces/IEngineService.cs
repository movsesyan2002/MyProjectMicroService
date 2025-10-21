using CoreLayer.DTO_s.EngineDtos;

namespace CoreLayer.Interfaces.ServiceInterfaces;

public interface IEngineService
{
    Task<IEnumerable<EngineDto>> GetAllAsync();
    Task<EngineDto> GetByIdAsync(int id);
    Task<IEnumerable<EngineDto>> GetWithPowerRange(int start, int end);
    Task<EngineDto> CreateEngineAsync(CreateEngineDto engineDto);
    Task UpdateEngineAsync(int id, UpdateEngineDto engineDto);
    Task DeleteEngineAsync(int id);

    Task<IEnumerable<EngineDto>> GetByFuelTypeAsync(string fueltype);
}