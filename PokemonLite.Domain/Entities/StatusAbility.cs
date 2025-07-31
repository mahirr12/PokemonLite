using PokemonLite.Domain.Enums;

namespace PokemonLite.Domain.Entities;

// Effectiveness of the status of Pokémon itself
public class StatusAbility(
    StatusAbilityType statusAbilityType,
    int healthEffectiveness=1,
    int attackEffectiveness=1,
    int defenseEffectiveness=1)
    : BaseAbility
{
    public int[] StatusEffectiveness { get; } =
        [healthEffectiveness, attackEffectiveness, defenseEffectiveness];


    public StatusAbilityType StatusAbilityType { get; } =
        statusAbilityType;
}