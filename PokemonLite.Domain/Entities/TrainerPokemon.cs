using PokemonLite.Domain.Enums;

namespace PokemonLite.Domain.Entities;

public class TrainerPokemon : BaseEntity
{
    public string NickName { get; set; } = null!;
    public PokemonType PokemonType { get; set; }

    public Guid? TrainerId { get; set; }
    public Trainer? Trainer { get; set; }

    public Guid PokemonId { get; set; }
    public Pokemon Pokemon { get; set; } = null!;

    public int Level { get; set; }

    public int Exp { get; set; }
    public bool IsShiny { get; set; }
    public int CurrentHp { get; set; }
    public int CurrentAttack { get; set; }
    public int CurrentDefense { get; set; }

    public ICollection<BaseAbility> Abilities { get; set; } = [];

    public ICollection<PokemonAssignAbility> PokemonAssignAbilities { get; set; } = [];

    public ICollection<BattleTrainerPokemon> Battles { get; set; } = [];
    
}