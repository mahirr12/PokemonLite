using PokemonLite.Domain.Enums;

namespace PokemonLite.Contract.DTOs.SpecieEffectiveness;

public class CreateSpecieEffectivenessDTO
{
    public Guid AttackingSpecieId { get; set; }
    public Guid DefendingSpecieId { get; set; }
    public EffectType Type { get; set; }
}