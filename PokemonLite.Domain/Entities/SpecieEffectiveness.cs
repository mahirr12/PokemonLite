using PokemonLite.Domain.Enums;

namespace PokemonLite.Domain.Entities;

public class SpecieEffectiveness
{
    public Guid AttackingSpecieId { get; set; }
    public Specie AttackingSpecie { get; set; } = null!;

    public Guid DefendingSpecieId { get; set; }
    public Specie DefendingSpecie { get; set; } = null!;

    public EffectType Type { get; set; } = EffectType.Normal;
}