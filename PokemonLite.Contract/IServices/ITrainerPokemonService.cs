using PokemonLite.Contract.DTOs.TrainerPokemon;
using PokemonLite.Domain.Entities;

namespace PokemonLite.Contract.IServices;

public interface ITrainerPokemonService
    :IGenericService<TrainerPokemon,CreateTrainerPokemonDTO, TrainerPokemonDTO>
{
    Task<TrainerPokemonDTO> CreateWithRandomStatsAsync(CreateTrainerPokemonDTO dto);
}