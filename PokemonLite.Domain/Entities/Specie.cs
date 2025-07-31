namespace PokemonLite.Domain.Entities;

public class Specie : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }

    //public ICollection<Ability> Abilities { get; set; } = [];
    public ICollection<Pokemon> Pokemons { get; set; } = [];
}