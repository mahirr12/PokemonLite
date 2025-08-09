using PokemonLite.Domain.Entities;

namespace PokemonLite.Domain.IRepositories;

public interface ISpecieEffectivenessRepository
{
    Task<SpecieEffectiveness?> GetByIdAsync(Guid aId, Guid dId);
    IQueryable<SpecieEffectiveness> GetAll();
    IQueryable<SpecieEffectiveness> GetAllBySpecie(Guid specieId);
    Task<SpecieEffectiveness> AddAsync(SpecieEffectiveness entity);
    SpecieEffectiveness Update(SpecieEffectiveness entity);
    Task<bool> DeleteAsync(Guid aId, Guid dId);
}