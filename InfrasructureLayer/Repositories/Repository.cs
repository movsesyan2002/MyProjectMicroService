using CoreLayer.Interfaces.Repositories;
using InfrasructureLayer.DbConnection;
using Microsoft.EntityFrameworkCore;

namespace InfrasructureLayer.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    protected readonly AppDbContext Context;
    protected readonly DbSet<T> DbSet;

    public Repository(AppDbContext context)
    {
        Context = context;
        DbSet = context.Set<T>();
    }


    public async Task<IEnumerable<T>> GetAlLAsync()
    {
        return await DbSet.ToListAsync();
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        return await DbSet.FindAsync(id);
    }

    public async Task AddAsync(T entity)
    {
        await DbSet.AddAsync(entity);
        await Context.SaveChangesAsync();
    }

    public void Update(T entity)
    {
        DbSet.Update(entity);
        Context.SaveChangesAsync();
    }

    public void Remove(T entity)
    {
        DbSet.Remove(entity);
        Context.SaveChangesAsync();
    }
}