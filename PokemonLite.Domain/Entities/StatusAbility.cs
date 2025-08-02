using PokemonLite.Domain.Enums;

namespace PokemonLite.Domain.Entities;

// Effectiveness of the status of Pokémon itself
public class StatusAbility
    : BaseAbility
{
    public int[] StatusEffectiveness { get; set; } =new int[3]; // effectiveness on (0: hp, 1: attack, 2: defense)
        


    public StatusAbilityType StatusAbilityType { get; set; } 
}