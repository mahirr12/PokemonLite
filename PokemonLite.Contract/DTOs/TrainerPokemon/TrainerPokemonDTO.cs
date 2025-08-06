using PokemonLite.Domain.Enums;

namespace PokemonLite.Contract.DTOs.TrainerPokemon;

public class TrainerPokemonDTO
{
    public Guid Id { get; set; }
    public string NickName { get; set; } = null!;
    public PokemonType PokemonType { get; set; }
    public Guid? TrainerId { get; set; }
    public Guid PokemonId { get; set; }
    public int Level { get; set; }
    public int Exp { get; set; }
    public bool IsShiny { get; set; }
    public int CurrentHp { get; set; }
    public int CurrentAttack { get; set; }
    public int CurrentDefense { get; set; }

    // Navigation properties
    public IDictionary<Guid,string> Abilities { get; set; } = new Dictionary<Guid,string>();
    public IDictionary<Guid,string> PokemonAssignAbilities { get; set; } = new Dictionary<Guid,string>();
    
    public ICollection<Guid> BattleIds { get; set; } = [];
}