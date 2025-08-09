using System.ComponentModel.DataAnnotations;

namespace PokemonLite.Contract.DTOs.Battle;

public class JoinBattleDTO
{
    [Required(ErrorMessage = "JoinerId is required")]
    public Guid JoinerId { get; set; }
    
    [Required(ErrorMessage = "BattleId is required")]
    public Guid BattleId { get; set; }
    
    [Required(ErrorMessage = "JoinerPokemons is required")]
    [MinLength(1, ErrorMessage = "At least one Pokemon is required")]
    [MaxLength(6, ErrorMessage = "A maximum of 6 Pokemons is allowed")]
    public ICollection<Guid> JoinerPokemons { get; set; } = [];
}