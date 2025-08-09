using AutoMapper;
using PokemonLite.Contract.DTOs.Pokemon;
using PokemonLite.Contract.IServices;
using PokemonLite.Domain.Entities;
using PokemonLite.Domain.IRepositories;

namespace PokemonLite.Application.Services;

public class PokemonService(
    IMapper mapper,
    IGenericRepository<Pokemon> pokemonRepository,
    IUnitOfWork unitOfWork,
    IGenericRepository<Specie> specieRepository)
    : GenericService<Pokemon, CreatePokemonDTO, PokemonDTO>(mapper, pokemonRepository, unitOfWork),
        IPokemonService
{
    public async Task<PokemonDTO> CreateWithSpecieAsync(CreatePokemonDTO createPokemonDto)
    {
        var entity = mapper.Map<Pokemon>(createPokemonDto);
        var mainSpecie = await specieRepository.GetByIdAsync(createPokemonDto.MainSpecieId);
        if (mainSpecie == null) throw new ArgumentException("Main Specie not found");
        entity.Species.Add(mainSpecie);
        if (createPokemonDto.SecondarySpecieId != null && createPokemonDto.SecondarySpecieId != Guid.Empty)
        {
            var secondarySpecie = await specieRepository.GetByIdAsync(createPokemonDto.SecondarySpecieId.Value);
            if (secondarySpecie == null) throw new ArgumentException("Secondary Specie not found");
            entity.Species.Add(secondarySpecie);
        }

        var createdEntity = await pokemonRepository.AddAsync(entity);
        await unitOfWork.SaveChangesAsync();
        return mapper.Map<PokemonDTO>(createdEntity);
    }

    public async Task<PokemonDTO> UpdateWithSpecieAsync(CreatePokemonDTO updatePokemonDto)
    {
        if (updatePokemonDto.Id == null) throw new ArgumentException("Pokemon ID cannot be empty");
        var existingPokemon = await pokemonRepository.GetByIdAsync((Guid)updatePokemonDto.Id);
        if (existingPokemon == null) throw new ArgumentException("Pokemon not found");

        var entity = mapper.Map<Pokemon>(updatePokemonDto);
        var mainSpecie = await specieRepository.GetByIdAsync(updatePokemonDto.MainSpecieId);
        if (mainSpecie == null) throw new ArgumentException("Main Specie not found");
        entity.Species.Add(mainSpecie);
        if (updatePokemonDto.SecondarySpecieId != null && updatePokemonDto.SecondarySpecieId != Guid.Empty)
        {
            var secondarySpecie = await specieRepository.GetByIdAsync(updatePokemonDto.SecondarySpecieId.Value);
            if (secondarySpecie == null) throw new ArgumentException("Secondary Specie not found");
            entity.Species.Add(secondarySpecie);
        }

        entity.Id = existingPokemon.Id; // Ensure the ID is set to the existing Pokemon's ID
        var updatedEntity = pokemonRepository.Update(entity);
        await unitOfWork.SaveChangesAsync();
        return mapper.Map<PokemonDTO>(updatedEntity);
    }
}