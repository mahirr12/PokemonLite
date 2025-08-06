using System.ComponentModel.DataAnnotations;

namespace PokemonLite.Contract.DTOs.Ability;

public class CreateAbilityDTO
{
    private int? _cooldown;
    private int? _duration;
    private int[]? _effectiveness;
    private int[]? _opponentEffectiveness;
    private int[]? _ownEffectiveness;
    private int? _statusAbilityType;
    private int[]? _statusEffectiveness;
    public AbilityType AbilityType { get; set; }
    public Guid? Id { get; set; }

    [Required(ErrorMessage = "Name is required.")]
    [StringLength(100, ErrorMessage = "Name cannot be longer than 100 characters.")]
    public string Name { get; set; } = null!;

    [Required(ErrorMessage = "Difficulty is required.")]
    [StringLength(500, ErrorMessage = "Description cannot be longer than 500 characters.")]
    public string Description { get; set; } = null!;

    [Required(ErrorMessage = "Specie is required.")]
    public Guid SpecieId { get; set; }

    [Required(ErrorMessage = "Difficulty is required.")]
    [Range(1, 5, ErrorMessage = "Difficulty must be between 1 and 5.")]
    public int Difficulty { get; set; }

    public IDictionary<Guid, int> PokemonLevels { get; set; } = new Dictionary<Guid, int>();

    //Active Ability
    public int? Cooldown
    {
        get => _cooldown;
        set
        {
            if (AbilityType == AbilityType.Active) _cooldown = value;
        }
    }

    //int array size must be 3, representing effectiveness on (0: hp, 1: attack, 2: defense)
    public int[]? Effectiveness
    {
        get => _effectiveness;
        set
        {
            if (AbilityType == AbilityType.Active) _effectiveness = value;
        }
    }

    //Passive Ability
    public int? Duration
    {
        get => _duration;
        set
        {
            if (AbilityType == AbilityType.Passive) _duration = value;
        }
    }

    //int array size must be 3, representing own effectiveness on (0: hp, 1: attack, 2: defense)
    public int[]? OwnEffectiveness
    {
        get => _ownEffectiveness;
        set
        {
            if (AbilityType == AbilityType.Passive) _ownEffectiveness = value;
        }
    }

    //int array size must be 3, representing opponent effectiveness on (0: hp, 1: attack, 2: defense)
    public int[]? OpponentEffectiveness
    {
        get => _opponentEffectiveness;
        set
        {
            if (AbilityType == AbilityType.Passive) _opponentEffectiveness = value;
        }
    }

    //Status Ability
    //int array size must be 3, representing effectiveness on (0: hp, 1: attack, 2: defense)
    public int[]? StatusEffectiveness
    {
        get => _statusEffectiveness;
        set
        {
            if (AbilityType == AbilityType.Status) _statusEffectiveness = value;
        }
    }

    public int? StatusAbilityType
    {
        get => _statusAbilityType;
        set
        {
            if (AbilityType == AbilityType.Status) _statusAbilityType = value;
        }
    } // Enum value for StatusAbilityType
}