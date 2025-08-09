using PokemonLite.Contract.DTOs.SpecieEffectiveness;

namespace PokemonLite.Contract.IServices;

public interface ISpecieEffectivenessService
{
    Task<SpecieEffectivenessDTO?> GetByIdAsync(Guid aId, Guid dId);
    Task<IEnumerable<SpecieEffectivenessDTO>> GetAllAsync();
    Task<IEnumerable<SpecieEffectivenessDTO>> GetAllBySpecieAsync(Guid specieId);
    Task<SpecieEffectivenessDTO> CreateAsync(CreateSpecieEffectivenessDTO dto);
    Task<SpecieEffectivenessDTO> UpdateAsync(CreateSpecieEffectivenessDTO dto);
    Task<bool> DeleteAsync(Guid aId, Guid dId);
}