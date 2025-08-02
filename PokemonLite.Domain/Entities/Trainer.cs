using PokemonLite.Domain.Enums;

namespace PokemonLite.Domain.Entities;

public class Trainer : BaseEntity
{
    public string Nickname { get; set; } = null!;
    public int Level { get; set; }

    public TrainerType Type { get; set; }

    public ICollection<TrainerPokemon> TrainerPokemons { get; set; } = [];

    public string? UserId { get; set; }
    public User? User { get; set; }

    // public Guid AreaId { get; set; }
    //public Area Area { get; set; }
}