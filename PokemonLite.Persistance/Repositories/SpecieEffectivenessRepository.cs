using Microsoft.EntityFrameworkCore;
using PokemonLite.Domain.Entities;
using PokemonLite.Domain.IRepositories;
using PokemonLite.Persistance.DataBase;

namespace PokemonLite.Persistance.Repositories;

public class SpecieEffectivenessRepository(PokemonDBContext context)
    : ISpecieEffectivenessRepository
{
    private readonly DbSet<SpecieEffectiveness> _dbSet = context.Set<SpecieEffectiveness>();

    public async Task<SpecieEffectiveness?> GetByIdAsync(Guid aId, Guid dId)
    {
        return await _dbSet.FindAsync(aId, dId);
    }

    public IQueryable<SpecieEffectiveness> GetAll()
    {
        return _dbSet;
    }

    public IQueryable<SpecieEffectiveness> GetAllBySpecie(Guid specieId)
    {
        return _dbSet.Where(se =>
            se.AttackingSpecieId == specieId || se.DefendingSpecieId == specieId);
    }

    public async Task<SpecieEffectiveness> AddAsync(SpecieEffectiveness entity)
    {
        return (await _dbSet.AddAsync(entity)).Entity;
    }

    public SpecieEffectiveness Update(SpecieEffectiveness entity)
    {
        return _dbSet.Update(entity).Entity;
    }

    public async Task<bool> DeleteAsync(Guid aId, Guid dId)
    {
        var entity = await _dbSet.FindAsync(aId, dId);
        if (entity == null) return false;

        _dbSet.Remove(entity);
        return true;
    }
}