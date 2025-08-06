namespace PokemonLite.Contract.DTOs.Pokemon;

public class PokemonDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = string.Empty;
    public int BaseHp { get; set; }
    public int BaseAttack { get; set; }
    public int BaseDefense { get; set; }

    public IDictionary<Guid, string> Species { get; set; } = new Dictionary<Guid, string>();
}