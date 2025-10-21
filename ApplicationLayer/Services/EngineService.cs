using AutoMapper;
using CoreLayer.DTO_s.EngineDtos;
using CoreLayer.Exception;
using CoreLayer.Interfaces.Repositories;
using CoreLayer.Interfaces.ServiceInterfaces;
using CoreLayer.Models;

namespace ApplicationLayer.Services;

public class EngineService : IEngineService
{
    private readonly IEngineRepository _engineRepository;
    private readonly IMapper _mapper;

    public EngineService(IEngineRepository engineRepository, IMapper mapper)
    {
        _engineRepository = engineRepository;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<EngineDto>> GetAllAsync()
        => _mapper.Map<IEnumerable<EngineDto>>(await _engineRepository.GetAlLAsync());

    public async Task<EngineDto> GetByIdAsync(int id)
    {
        if (id < 0) throw new BusinessRuleViolationException("Id is less than 0");
        var engine = await _engineRepository.GetByIdAsync(id);
        if (engine == null) throw new EntityNotFoundException($"Engine with this {id} Id not found");
        return _mapper.Map<EngineDto>(engine);
    }

    public async Task<IEnumerable<EngineDto>> GetWithPowerRange(int start, int end)
    {
        if (start > end) throw new BusinessRuleViolationException("The powers don't match.");
        var engines = await _engineRepository.GetByPowerAsync(start, end);

        return _mapper.Map<IEnumerable<EngineDto>>(engines);
    }



    public async Task<EngineDto> CreateEngineAsync(CreateEngineDto dto)
    {
        var engine = _mapper.Map<EngineModel>(dto);
        await _engineRepository.AddAsync(engine);
        return _mapper.Map<EngineDto>(engine);
    }

    public async Task UpdateEngineAsync(int id, UpdateEngineDto dto)
    {
        if (id < 0) throw new BusinessRuleViolationException("Id is less than 0");
        var engine = await _engineRepository.GetByIdAsync(id);
        if (engine == null) throw new EntityNotFoundException($"Engine with this {id} Id not found");
        _mapper.Map(dto, engine);
        _engineRepository.Update(engine);
    }

    public async Task DeleteEngineAsync(int id)
    {
        if (id < 0) throw new BusinessRuleViolationException("Id is less than 0");

        var engine = await _engineRepository.GetByIdAsync(id);
        if (engine == null) throw new EntityNotFoundException($"Engine with this {id} Id not found");

        _engineRepository.Remove(engine);
    }

    public async Task<IEnumerable<EngineDto>> GetByFuelTypeAsync(string fuelType)
    {
        var result = await _engineRepository.GetByFuelTypeAsync(fuelType);
        
        return _mapper.Map<IEnumerable<EngineDto>>(result);
    }
    
    
}