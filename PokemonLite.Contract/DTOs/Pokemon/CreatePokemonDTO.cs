using System.ComponentModel.DataAnnotations;

namespace PokemonLite.Contract.DTOs.Pokemon;

public class CreatePokemonDTO
{
    public Guid? Id { get; set; }
    [Required(ErrorMessage = "Name is required.")]
    [StringLength(50, ErrorMessage = "Name cannot be longer than 100 characters.")]
    public string Name { get; set; } = null!;

    [Required(ErrorMessage = "Description is required.")]
    [StringLength(500, ErrorMessage = "Description cannot be longer than 500 characters.")]
    public string Description { get; set; } = string.Empty;

    [Required(ErrorMessage = "Base HP is required.")]
    [Range(1, 999, ErrorMessage = "Base HP must be between 1 and 999.")]
    public int BaseHp { get; set; }

    [Required(ErrorMessage = "Base Attack is required.")]
    [Range(1, 999, ErrorMessage = "Base Attack must be between 1 and 999.")]
    public int BaseAttack { get; set; }

    [Required(ErrorMessage = "Base Defense is required.")]
    [Range(1, 999, ErrorMessage = "Base Defense must be between 1 and 999.")]
    public int BaseDefense { get; set; }

    [Required(ErrorMessage = "Specie1Id is required.")]
    public Guid MainSpecieId { get; set; }


    public Guid? SecondarySpecieId { get; set; } 
}