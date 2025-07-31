namespace PokemonLite.Domain.Entities;

public abstract class BaseAbility : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }

    public Specie Specie { get; set; } = null!;
    public int Difficulty { get; set; } = 1;
    
    public Dictionary<Guid, int> PokemonLevels { get; set; } = new();
    
}