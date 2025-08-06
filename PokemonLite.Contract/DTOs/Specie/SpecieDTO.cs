namespace PokemonLite.Contract.DTOs.Specie;

public class SpecieDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public IDictionary<Guid, string> Pokemons { get; set; } = new Dictionary<Guid, string>();
}