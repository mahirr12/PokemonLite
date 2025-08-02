namespace PokemonLite.Domain.Entities;

public class AbilityLevels
{
    public Guid PokemonId { get; set; }
    public Pokemon Pokemon { get; set; }
    public Guid BaseAbilityId { get; set; }
    public BaseAbility BaseAbility { get; set; }
    
    //Level required to use the ability
    public int Level { get; set; } = 1;
}