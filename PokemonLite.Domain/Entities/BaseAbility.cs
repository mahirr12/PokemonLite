namespace PokemonLite.Domain.Entities;

public abstract class BaseAbility : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }

    public Specie Specie { get; set; } = null!;
    public int Difficulty { get; set; } = 1;
    
    //public IDictionary<Guid, int> PokemonLevels { get; set; } 
    public ICollection<AbilityLevels> AbilityLevels { get; set; } = [];
    
}