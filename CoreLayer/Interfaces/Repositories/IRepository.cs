namespace CoreLayer.Interfaces.Repositories;


public interface IRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAlLAsync();
    Task<T?> GetByIdAsync(int id);
    void Remove(T entity);
    void Update(T entity);
    Task AddAsync(T entity);
}
