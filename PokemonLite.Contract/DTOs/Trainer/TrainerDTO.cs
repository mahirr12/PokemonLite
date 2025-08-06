using PokemonLite.Domain.Enums;

namespace PokemonLite.Contract.DTOs.Trainer;

public class TrainerDTO
{
    public Guid Id { get; set; }
    public string Nickname { get; set; }= null!;
    public int Level { get; set; }
    public TrainerType Type { get; set; }
    public string? UserId { get; set; }
    public ICollection<Guid> BattleIds { get; set; }=[];
    public IDictionary<Guid,string> TrainerPokemons { get; set; } = new Dictionary<Guid,string>();
}