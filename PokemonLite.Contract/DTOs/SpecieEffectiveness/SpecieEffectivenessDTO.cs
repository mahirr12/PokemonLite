using PokemonLite.Domain.Enums;

namespace PokemonLite.Contract.DTOs.SpecieEffectiveness;

public class SpecieEffectivenessDTO
{
    public Guid AttackingSpecieId { get; set; }
    public string AttackingSpecie { get; set; } = string.Empty;

    public Guid DefendingSpecieId { get; set; }
    public string DefendingSpecie { get; set; } = string.Empty;

    public EffectType Type { get; set; }
}