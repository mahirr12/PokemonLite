using PokemonLite.Contract.DTOs.TrainerPokemon;

namespace PokemonLite.Contract.DTOs.Battle;

public class BattleDTO
{
    public Guid Id { get; set; }
    public Guid CreatorId { get; set; }
    public string CreatorName { get; set; } = null!;
    public Guid? JoinerId { get; set; }
    public string? JoinerName { get; set; }
    public ICollection<TrainerPokemonDTO> CreatorPokemons { get; set; } = [];
    public ICollection<TrainerPokemonDTO> JoinerPokemons { get; set; } = [];

    public string Status { get; set; }= "Waiting";
}