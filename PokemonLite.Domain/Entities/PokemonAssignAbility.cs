namespace PokemonLite.Domain.Entities;

public class PokemonAssignAbility
{
    public Guid TrainerPokemonId { get; set; }
    public TrainerPokemon TrainerPokemon { get; set; } = null!;
    
    public Guid AbilityId { get; set; }
    public BaseAbility Ability { get; set; } = null!;
}