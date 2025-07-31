namespace PokemonLite.Domain.Entities;

public class Area : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }


    // Navigation properties
    public ICollection<Pokemon> Pokemons { get; set; } = [];
    public ICollection<Trainer> Trainers { get; set; } = [];
    public ICollection<Gym> Gyms { get; set; } = [];
    public ICollection<Trainer> Elite4 { get; set; } = [];
    public Trainer? Champions { get; set; }
}