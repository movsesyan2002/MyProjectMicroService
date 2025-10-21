using System.Data;
using CoreLayer.Interfaces.Repositories;
using CoreLayer.Models;
using InfrasructureLayer.DbConnection;
using Microsoft.EntityFrameworkCore;

namespace InfrasructureLayer.Repositories;

public class CarRepository : Repository<CarModel>, ICarRepository
{
    public CarRepository(AppDbContext context) : base(context){}

    public async Task<IEnumerable<CarModel>> GetAlLAsyncByBrand(string brandname)
    {
        var context = Context.Cars;

        if (context == null) throw new DataException("In Cars Db context is nullable");
        return await context.Where(c => c.Name == brandname).ToListAsync() ;
    }
    
    public async Task<IEnumerable<CarModel>> GetAlLAsyncByBrand(string brandname, string modelname)
    {
        var context = Context.Cars;

        if (context == null) throw new DataException("In Cars Db context is nullable");
        return await context.Where(c => c.Name == brandname || c.ModelName == modelname).ToListAsync();
    }

    public async Task<IEnumerable<CarModel>> GetByYearRangeAsync(int fromyear, int toyear)
    {
        var context = Context.Cars;

        if (context == null) throw new DataException("In Cars Db context is nullable");
        return await context.
            Where(c => c.Year != null && c.Year.Value.Year >= fromyear && c.Year.Value.Year <= toyear)
            .ToListAsync();
    }

    public async Task<IEnumerable<CarModel>> GetCarsWithEnginesAsync()
    {
        var context = Context.Cars;

        if (context == null) throw new DataException("In Cars Db context is nullable");
        return await context.Include(e => e.Engines)
            .ToListAsync();
    }
}