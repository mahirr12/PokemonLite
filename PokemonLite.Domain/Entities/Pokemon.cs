namespace PokemonLite.Domain.Entities;

public class Pokemon : BaseEntity
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = string.Empty;
    public ICollection<Specie> Species { get; set; } = [];
    public double BaseHp { get; set; }
    public int BaseAttack { get; set; }
    public int BaseDefense { get; set; }
    public int BaseAttackSpeed { get; set; }
    public int BaseDefenseSpeed { get; set; }
    
    public ICollection<TrainerPokemon> TrainerPokemons { get; set; } = [];
}