namespace PokemonLite.Domain.Entities;

public class PokemonAssignAbility
{
    public Guid TrainerPokemonId { get; set; }
    public TrainerPokemon TrainerPokemon { get; set; } = null!;
    
    public Guid BaseAbilityId { get; set; }
    public BaseAbility BaseAbility { get; set; } = null!;
}