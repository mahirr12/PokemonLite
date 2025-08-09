using System.ComponentModel.DataAnnotations;

namespace PokemonLite.Contract.DTOs.Battle;

public class CreateBattleDTO
{
    [Required(ErrorMessage = "CreatorId is required")]
    public Guid CreatorId { get; set; }

    [Required(ErrorMessage = "CreatorPokemons is required")]
    [MinLength(1, ErrorMessage = "At least one Pokemon is required")]
    [MaxLength(6, ErrorMessage = "A maximum of 6 Pokemons is allowed")]
    public ICollection<Guid> CreatorPokemons { get; set; } = [];
}