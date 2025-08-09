using System.Linq.Expressions;
using PokemonLite.Domain.Entities;

namespace PokemonLite.Domain.IRepositories;

public interface IGenericRepository<T> where T : BaseEntity, new()
{
    // generic repository methods
    Task<T?> GetByIdAsync(Guid id,params Expression<Func<T, object>>[] includeProperties);
    IQueryable<T> GetAll(params Expression<Func<T, object>>[] includeProperties);
    Task<T> AddAsync(T entity);
    T Update(T entity);
    Task<bool> DeleteAsync(Guid id);
}