using CoreLayer.Models;

namespace CoreLayer.Interfaces.Repositories;

public interface IEngineRepository : IRepository<EngineModel>
{
    Task<IEnumerable<EngineModel>> GetByFuelTypeAsync(string fuelType);
    Task<IEnumerable<EngineModel>> GetByPowerAsync(int frompower, int topower);
    Task<ICollection<EngineModel>> GetByIdsAsync(IEnumerable<int> ids);

}