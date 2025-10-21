using System.Data;
using CoreLayer.Interfaces.Repositories;
using CoreLayer.Models;
using InfrasructureLayer.DbConnection;
using Microsoft.EntityFrameworkCore;

namespace InfrasructureLayer.Repositories;

public class EngineRepositoy : Repository<EngineModel>, IEngineRepository
{
    public EngineRepositoy(AppDbContext context) : base(context) { }

    public async Task<IEnumerable<EngineModel>> GetByFuelTypeAsync(string fuelType)
    {
        var context = Context.Engines;

        if (context == null) throw new DataException("In Engines Db context is nullable");
        
        return await context.
            Where(e => e.FuelType == fuelType).ToListAsync();
    }

    public async Task<IEnumerable<EngineModel>> GetByPowerAsync(int frompower, int topower)
    {
        var context = Context.Engines;

        if (context == null) throw new DataException("In Engines Db context is nullable");
        return await context.
            Where(e => e.PowerHp >= frompower && e.PowerHp <= topower)
            .ToListAsync();
    }

    public async Task<ICollection<EngineModel>> GetByIdsAsync(IEnumerable<int> ids)
    {
        var context = Context.Engines;

        if (context == null) throw new DataException("In Engines Db context is nullable");
        
        return await context.Where(e => ids.Contains(e.EngineId)).ToListAsync();
    }
}