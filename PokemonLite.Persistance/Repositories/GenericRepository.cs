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

    public async Task<T?> GetByIdAsync(Guid id)
        => await _dbSet.FirstOrDefaultAsync(t => t.Id == id && !t.IsDeleted);


    public IQueryable<T> GetAll()
        => _dbSet.Where(t => !t.IsDeleted);


    public async Task<T> AddAsync(T entity)
        => (await _dbSet.AddAsync(entity)).Entity;


    public T Update(T entity)
        => _dbSet.Update(entity).Entity;

    public async Task<bool> DeleteAsync(Guid id)
    {
        var entity = await GetByIdAsync(id);
        if (entity == null || entity.IsDeleted) return false;

        entity.IsDeleted = true;
        _dbSet.Update(entity);
        return true;
    }
}