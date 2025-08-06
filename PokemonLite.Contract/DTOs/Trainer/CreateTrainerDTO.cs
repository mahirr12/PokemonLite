using System.ComponentModel.DataAnnotations;
using PokemonLite.Domain.Enums;

namespace PokemonLite.Contract.DTOs.Trainer;

public class CreateTrainerDTO
{
    public Guid? Id { get; set; }
    [Required(ErrorMessage = "Nickname is required")]
    [MaxLength(50, ErrorMessage = "Nickname cannot exceed 50 characters")]
    public string Nickname { get; set; } = null!;

    [Required(ErrorMessage = "Type is required")]
    [Range(0, 1, ErrorMessage = "Type must be between 0 and 1")]
    public TrainerType TrainerType { get; set; }
}