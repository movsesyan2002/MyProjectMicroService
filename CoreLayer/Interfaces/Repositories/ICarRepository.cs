using CoreLayer.Models;

namespace CoreLayer.Interfaces.Repositories;

public interface ICarRepository : IRepository<CarModel>
{
    Task<IEnumerable<CarModel>> GetAlLAsyncByBrand(string brandname);
    Task<IEnumerable<CarModel>> GetAlLAsyncByBrand(string brandname, string modelname);
    Task<IEnumerable<CarModel>> GetByYearRangeAsync(int fromyear, int toyear);
    Task<IEnumerable<CarModel>> GetCarsWithEnginesAsync();
}