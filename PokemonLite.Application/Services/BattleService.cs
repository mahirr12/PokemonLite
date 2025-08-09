using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PokemonLite.Contract.DTOs.Battle;
using PokemonLite.Contract.IServices;
using PokemonLite.Domain.Entities;
using PokemonLite.Domain.IRepositories;

namespace PokemonLite.Application.Services;

public class BattleService(
    IMapper mapper,
    IGenericRepository<Battle> repository,
    IGenericRepository<TrainerPokemon> trainerPokemonRepository,
    IUnitOfWork unitOfWork) : GenericService<Battle, CreateBattleDTO, BattleDTO>(mapper, repository, unitOfWork),
    IBattleService
{
    public async Task<BattleDTO> CreateBattleAsync(CreateBattleDTO dto)
    {
        var battle = mapper.Map<Battle>(dto);
        // get creator's pokemons by creatorpokemon ids
        var creatorPokemons = await
            trainerPokemonRepository.GetAll(tp => tp.PokemonAssignAbilities)
                .Where(tp => tp.TrainerId == dto.CreatorId && dto.CreatorPokemons.Contains(tp.Id)).ToListAsync();
        foreach (var creatorPokemon in creatorPokemons)
            battle.Pokemons.Add(new BattleTrainerPokemon
            {
                TrainerPokemon = creatorPokemon,
                Battle = battle,
                IsCreatorPokemon = true
            });

        var result = await repository.AddAsync(battle);
        await unitOfWork.SaveChangesAsync();
        return mapper.Map<BattleDTO>(result);
    }

    public async Task<BattleDTO> JoinBattleAsync(JoinBattleDTO dto)
    {
        var battle = await repository.GetByIdAsync(dto.BattleId, b => b.Pokemons);
        if (battle == null)
            throw new ArgumentException("Battle not found");

        battle.JoinerId = dto.JoinerId;
        // get joiner's pokemons by joinerpokemon ids
        var joinerPokemons = await trainerPokemonRepository.GetAll(tp => tp.PokemonAssignAbilities)
            .Where(tp => tp.TrainerId == dto.JoinerId && dto.JoinerPokemons.Contains(tp.Id)).ToListAsync();

        foreach (var joinerPokemon in joinerPokemons)
            battle.Pokemons.Add(new BattleTrainerPokemon
            {
                TrainerPokemon = joinerPokemon,
                Battle = battle,
                IsCreatorPokemon = false
            });

        var result = repository.Update(battle);
        await unitOfWork.SaveChangesAsync();
        return mapper.Map<BattleDTO>(result);
    }

    public async Task<BattleDTO> SelectMoveAsync()
    {
        throw new NotImplementedException();
    }
}