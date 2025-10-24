using AutoMapper;
using CoreLayer.DTO_s.CarDtos;
using CoreLayer.Exception;
using CoreLayer.Interfaces.Repositories;
using CoreLayer.Interfaces.ServiceInterfaces;
using CoreLayer.Models;

namespace ApplicationLayer.Services;

public class CarService : ICarService
{
    private readonly ICarRepository _carRepository;
    private readonly IEngineRepository _engineRepository;
    private IMapper _mapper;

    public CarService(ICarRepository carRepository, IEngineRepository engineRepository, IMapper mapper)
    {
        _carRepository = carRepository;
        _engineRepository = engineRepository;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<CarDto>> GetAllAsync()
    {
        var cars = await _carRepository.GetAlLAsync();
        return _mapper.Map<IEnumerable<CarDto>>(cars);
    }

    public async Task<CarDto?> GetByIdAsync(int id)
    {
        if (id < 0)
            throw new BusinessRuleViolationException($"{id} is less than 0");

        var car = await _carRepository.GetByIdAsync(id);
        
        if (car == null) 
            throw new EntityNotFoundException($"Car with Id {id} was not found");

        return _mapper.Map<CarDto>(car);
    }

    public async Task<IEnumerable<CarDto>> GetByBrandAsync(string brandname)
    {
        if (brandname == null)
            throw new BusinessRuleViolationException($"Dont take a brand name");

        var cars = await _carRepository.GetAlLAsyncByBrand(brandname);
        
        if (cars == null)
            throw new EntityNotFoundException($"Cars with this {brandname} Brand name not found");

        return _mapper.Map<IEnumerable<CarDto>>(cars);
    }

    public async Task<IEnumerable<CarDto>> GetByBrandAsync(string brandname, string modelname)
    {
        if (brandname == null)
            throw new BusinessRuleViolationException($"Dont take a brand name");
        
        if (modelname == null)
            throw new BusinessRuleViolationException($"Dont take a model name");

        var cars = await _carRepository.GetAlLAsyncByBrand(brandname, modelname);
        
        if (cars == null) throw new EntityNotFoundException($"Cars with this {brandname} Brand name and {modelname} Model name not found");
        return _mapper.Map<IEnumerable<CarDto>>(cars);
    }

    public async Task<IEnumerable<CarDto>> GetByYearRangeAsync(int fromyear, int toyear)
    {
        var cars = await _carRepository.GetByYearRangeAsync(fromyear, toyear);
        if (cars == null) throw new EntityNotFoundException($"Cars with this {fromyear} Year to {toyear} Year not found");
        return _mapper.Map<IEnumerable<CarDto>>(cars);    
    }

    public async Task<IEnumerable<CarDto>> GetCarsWithEnginesAsync()
    {
        var cars = await _carRepository.GetCarsWithEnginesAsync();
        return _mapper.Map<IEnumerable<CarDto>>(cars);    
    }

    
    
    public async Task<CarDto?> CreateAsync(CreateCarDto dto)
    {
        if (dto.Year != default)
            dto.Year = DateTime.SpecifyKind(dto.Year, DateTimeKind.Utc);
        
        var entity = _mapper.Map<CarModel>(dto);

        if (dto.Engines is not null && dto.Engines.Any())
        {
            entity.Engines = await _engineRepository.GetByIdsAsync(dto.Engines);
        }
        else
        {
            throw new BusinessRuleViolationException("You dont put engines");
        }
        
        await _carRepository.AddAsync(entity);
        return _mapper.Map<CarDto?>(entity);
    }

    public async Task UpdateCarAsync(int id, UpdateCarDto updated)
    {
        var car = await _carRepository.GetByIdAsync(id);
        
        if (car == null || id < 0) throw new BusinessRuleViolationException($"For Updating {id} is invalid");
        
        _mapper.Map(updated, car); 

        if (updated.EngineIds is not null)
        {
            car.Engines = await _engineRepository.GetByIdsAsync(updated.EngineIds);
        }

        _carRepository.Update(car);    
    }

    public async Task DeleteAsync(int id)
    {
        var car = await _carRepository.GetByIdAsync(id);
        if (car == null || id < 0) throw new BusinessRuleViolationException($"For Deleting {id} is invalid");

        _carRepository.Remove(car);
        
    }
}