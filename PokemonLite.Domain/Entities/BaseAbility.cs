namespace PokemonLite.Domain.Entities;

public class BaseAbility : BaseEntity
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; }

    public Guid SpecieId { get; set; }
    public Specie Specie { get; set; } = null!;

    public int Difficulty { get; set; } = 1;

    //public IDictionary<Guid, int> PokemonLevels { get; set; } 
    public ICollection<AbilityLevel> AbilityLevels { get; set; } = [];

    public ICollection<TrainerPokemon> Pokemons { get; set; } = [];
}