using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PokemonLite.Domain.Entities;
using PokemonLite.Domain.IRepositories;
using PokemonLite.Persistance.DataBase;

namespace PokemonLite.Persistance.Repositories;

public class GenericRepository<T>(PokemonDBContext context)
    : IGenericRepository<T> where T : BaseEntity, new()
{
    private readonly PokemonDBContext _context = context;
    private readonly DbSet<T> _dbSet = context.Set<T>();

    public async Task<T?> GetByIdAsync(Guid id, params Expression<Func<T, object>>[] includeProperties)
    {
        var query = _dbSet.AsQueryable();
        foreach (var includeProperty in includeProperties)
            query = query.Include(includeProperty);
        return await query.FirstOrDefaultAsync(t => t.Id == id && !t.IsDeleted);
    }


    public IQueryable<T> GetAll(params Expression<Func<T, object>>[] includeProperties)
    {
        var query = _dbSet.Where(t => !t.IsDeleted);
        foreach (var includeProperty in includeProperties)
            query = query.Include(includeProperty);
        return query;
    }


    public async Task<T> AddAsync(T entity)
    {
        return (await _dbSet.AddAsync(entity)).Entity;
    }


    public T Update(T entity)
    {
        return _dbSet.Update(entity).Entity;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var entity = await GetByIdAsync(id);
        if (entity == null || entity.IsDeleted) return false;

        entity.IsDeleted = true;
        _dbSet.Update(entity);
        return true;
    }
}