using AutoMapper;
using PokemonLite.Contract.DTOs.TrainerPokemon;
using PokemonLite.Contract.IServices;
using PokemonLite.Domain.Entities;
using PokemonLite.Domain.IRepositories;

namespace PokemonLite.Application.Services;

public class TrainerPokemonService(
    IMapper mapper,
    IGenericRepository<TrainerPokemon> repository,
    IGenericRepository<Pokemon> pokemonRepository,
    IGenericRepository<BaseAbility> abilityRepository,
    IUnitOfWork unitOfWork)
    : GenericService<TrainerPokemon, CreateTrainerPokemonDTO, TrainerPokemonDTO>(mapper, repository, unitOfWork),
        ITrainerPokemonService
{
    public async Task<TrainerPokemonDTO> CreateWithRandomStatsAsync(CreateTrainerPokemonDTO dto)
    {
        var pokemon = mapper.Map<TrainerPokemon>(dto);
        var basePokemon = await pokemonRepository.GetByIdAsync(dto.PokemonId, p => p.AbilityLevels)
                          ?? throw new ArgumentException("Pokemon not found");
        pokemon.Exp = Random.Shared.Next(101, 5005); // Random exp between 101 and 500
        pokemon.Level = CalculateLevel(pokemon.Exp);
        // 1/800 chance to be shiny
        pokemon.IsShiny = Random.Shared.Next(1, 801) == 1;
        pokemon.CurrentHp = CalculateHealth(pokemon.Level, basePokemon.BaseHp);
        pokemon.CurrentAttack = CalculateStat(pokemon.Level, basePokemon.BaseAttack);
        pokemon.CurrentDefense = CalculateStat(pokemon.Level, basePokemon.BaseDefense);
        //select random ability from base pokemon abilitieslevel
        var abilities = basePokemon.AbilityLevels.Where(al => al.Level <= pokemon.Level)
            .Select(al => al.BaseAbilityId).ToList();
        // add pokemon abilities random ability from abilities list
        if (abilities.Count <= 0) return mapper.Map<TrainerPokemonDTO>(pokemon);
        var randomAbilityId = abilities[Random.Shared.Next(abilities.Count)];
        var ability = await abilityRepository.GetByIdAsync(randomAbilityId);
        if (ability == null) throw new ArgumentException("Ability not found");
        pokemon.Abilities.Add(ability);
        var result = await repository.AddAsync(pokemon);
        await unitOfWork.SaveChangesAsync();
        return mapper.Map<TrainerPokemonDTO>(result);
    }

    private static int CalculateLevel(int exp)
    {
        var y = Math.Pow((double)exp / 100, 1.0 / 2.0);
        var level = (int)Math.Floor((-1 + Math.Sqrt(1 + 8 * y)) / 2);
        return level;
    }

    private static int CalculateHealth(int level, int baseHp)
    {
        var hp = (int)Math.Floor(baseHp * Math.Pow(level, 1.2));
        return hp;
    }

    private static int CalculateStat(int level, int baseStat)
    {
        var stat = baseStat * Math.Pow(level, 1.2);
        //random stat 90% to 110% of the calculated stat
        var randomFactor = Random.Shared.Next(90, 111) / 100.0;
        return (int)(stat * randomFactor);
    }
}