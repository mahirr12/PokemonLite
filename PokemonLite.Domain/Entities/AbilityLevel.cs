namespace PokemonLite.Domain.Entities;

public class AbilityLevel
{
    public Guid PokemonId { get; set; }
    public Pokemon Pokemon { get; set; } = null!;
    public Guid BaseAbilityId { get; set; }
    public BaseAbility BaseAbility { get; set; } = null!;

    //Level required to use the ability
    public int Level { get; set; } = 1;
}