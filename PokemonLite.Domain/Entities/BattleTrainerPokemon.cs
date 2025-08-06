namespace PokemonLite.Domain.Entities;

public class BattleTrainerPokemon
{
    public Guid BattleId { get; set; }
    public Battle Battle { get; set; } = null!;

    public Guid TrainerPokemonId { get; set; }
    public TrainerPokemon TrainerPokemon { get; set; } = null!;

    public bool IsCreatorPokemon { get; set; }
}