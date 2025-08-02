using PokemonLite.Domain.Enums;

namespace PokemonLite.Domain.Entities;

public class TrainerPokemon : BaseEntity
{
    public PokemonType PokemonType { get; set; }

    public Guid? TrainerId { get; set; }
    public Trainer? Trainer { get; set; }

    public Guid PokemonId { get; set; }
    public Pokemon Pokemon { get; set; } = null!;

    public int Level { get; set; }
    public double CurrentHp { get; set; }
    public string NickName { get; set; } = string.Empty;
    public bool IsShiny { get; set; } = false;
    public int Order { get; set; }

    public ICollection<BaseAbility> Abilities { get; set; } = [];

    public ICollection<PokemonAssignAbility> PokemonAssignAbilities { get; set; } = [];
    //public ICollection<BaseAbility> SelectedAbilities { get; set; } = [];
}