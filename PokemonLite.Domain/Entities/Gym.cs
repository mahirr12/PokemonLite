namespace PokemonLite.Domain.Entities;

public class Gym : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string Location { get; set; } = string.Empty;

    public Trainer LeaderTrainer { get; set; } = null!;
    public ICollection<TrainerPokemon> Guards { get; set; } = [];
    public Area Area { get; set; } = null!;
}