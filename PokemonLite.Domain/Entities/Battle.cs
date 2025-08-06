namespace PokemonLite.Domain.Entities;

public class Battle : BaseEntity
{
    public Guid CreatorId { get; set; }
    public Trainer Creator { get; set; }= null!;

    public Guid? JoinerId { get; set; }
    public Trainer? Joiner { get; set; }

    public ICollection<BattleTrainerPokemon> Pokemons { get; set; } = [];
}