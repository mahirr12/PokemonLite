using PokemonLite.Contract.DTOs.Pokemon;
using PokemonLite.Domain.Entities;

namespace PokemonLite.Contract.IServices;

public interface IPokemonService : IGenericService<Pokemon, CreatePokemonDTO, PokemonDTO>
{
    Task<PokemonDTO> CreateWithSpecieAsync(CreatePokemonDTO createPokemonDto);
    Task<PokemonDTO> UpdateWithSpecieAsync(CreatePokemonDTO updatePokemonDto);
}