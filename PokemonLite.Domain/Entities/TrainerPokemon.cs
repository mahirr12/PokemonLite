namespace PokemonLite.Domain.Entities;

public class TrainerPokemon : BaseEntity
{
    public Guid TrainerId { get; set; }
    public Trainer Trainer { get; set; } = null!;

    public Guid PokemonId { get; set; }
    public Pokemon Pokemon { get; set; } = null!;

    public int Level { get; set; }
    public double CurrentHp { get; set; }
    public string NickName { get; set; } = string.Empty;
    public bool IsShiny { get; set; } = false;
    public int Order { get; set; }

    public ICollection<BaseAbility> AbilityInventory { get; set; } = [];

    public ICollection<BaseAbility> SelectedAbilities { get; set; } = [];
}