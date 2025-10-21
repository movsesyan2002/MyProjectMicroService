using CoreLayer.DTO_s.CarDtos;

namespace CoreLayer.Interfaces.ServiceInterfaces;

public interface ICarService
{
    Task<IEnumerable<CarDto>> GetAllAsync();
    Task<CarDto?> GetByIdAsync(int id);
    Task<IEnumerable<CarDto>> GetByBrandAsync(string brandname);
    Task<IEnumerable<CarDto>> GetByBrandAsync(string brandname, string modelname);
    Task<IEnumerable<CarDto>> GetByYearRangeAsync(int fromyear, int toyear);
    Task<IEnumerable<CarDto>> GetCarsWithEnginesAsync();
    // Task<CarDto> CreateAsync(CreateCarDto dto);
    Task CreateAsync(CreateCarDto dto);
    Task UpdateCarAsync(int id, UpdateCarDto uptadet);
    Task DeleteAsync(int id);
}