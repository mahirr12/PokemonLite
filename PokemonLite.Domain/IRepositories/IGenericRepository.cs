using PokemonLite.Domain.Entities;

namespace PokemonLite.Domain.IRepositories;

public interface IGenericRepository<T> where T : BaseEntity, new()
{
    // generic repository methods
    Task<T?> GetByIdAsync(Guid id);
    IQueryable<T> GetAll();
    Task<T> AddAsync(T entity);
    T Update(T entity);
    Task<bool> DeleteAsync(Guid id);
}