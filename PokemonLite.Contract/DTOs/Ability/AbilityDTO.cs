namespace PokemonLite.Contract.DTOs.Ability;

public class AbilityDTO
{
    public AbilityType AbilityType { get; set; }
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = string.Empty;
    public Guid SpecieId { get; set; }
    public string Specie { get; set; } = string.Empty;
    public int Difficulty { get; set; }
    public IDictionary<Guid, string> PokemonLevels { get; set; } = new Dictionary<Guid, string>();

    //Active Ability
    public int? Cooldown { get; set; }
    public int[]? Effectiveness { get; set; }

    //Passive Ability
    public int? Duration { get; set; }
    public int[]? OwnEffectiveness { get; set; }
    public int[]? OpponentEffectiveness { get; set; }

    //Status Ability
    public int[]? StatusEffectiveness { get; set; }
    public int? StatusAbilityType { get; set; }
}

public enum AbilityType
{
    Active = 0,
    Passive = 1,
    Status = 2
}