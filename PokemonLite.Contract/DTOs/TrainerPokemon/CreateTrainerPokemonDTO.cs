using System.ComponentModel.DataAnnotations;

namespace PokemonLite.Contract.DTOs.TrainerPokemon;

public class CreateTrainerPokemonDTO
{
    public Guid? Id { get; set; }

    [Required(ErrorMessage = "Nickname is required")]
    [MaxLength(50, ErrorMessage = "Nickname cannot exceed 50 characters")]
    public string NickName { get; set; } = null!;

    public Guid? TrainerId { get; set; }
    public Guid PokemonId { get; set; }
    public int Level { get; set; }
    public int Exp { get; set; }
    public bool IsShiny { get; set; }
    public ICollection<Guid> AbilityIds { get; set; } = [];
    public ICollection<Guid> PokemonAssignAbilityIds { get; set; } = [];
}