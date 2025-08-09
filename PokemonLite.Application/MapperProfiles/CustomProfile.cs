using AutoMapper;
using PokemonLite.Contract.DTOs.Ability;
using PokemonLite.Contract.DTOs.Battle;
using PokemonLite.Contract.DTOs.Pokemon;
using PokemonLite.Contract.DTOs.Specie;
using PokemonLite.Contract.DTOs.SpecieEffectiveness;
using PokemonLite.Contract.DTOs.Trainer;
using PokemonLite.Contract.DTOs.TrainerPokemon;
using PokemonLite.Domain.Entities;

namespace PokemonLite.Application.MapperProfiles;

public class CustomProfile : Profile
{
    public CustomProfile()
    {
        //Ability
        CreateMap<CreateAbilityDTO, BaseAbility>()
            .ForMember(dest => dest.AbilityLevels,
                opt => opt.MapFrom(src => src.PokemonLevels.Select(al => new AbilityLevel
                {
                    PokemonId = al.Key,
                    Level = al.Value
                })));

        // same mapping for all ability types
        CreateMap<CreateAbilityDTO, ActiveAbility>()
            .IncludeBase<CreateAbilityDTO, BaseAbility>();
        CreateMap<CreateAbilityDTO, PassiveAbility>()
            .IncludeBase<CreateAbilityDTO, BaseAbility>();
        CreateMap<CreateAbilityDTO, StatusAbility>()
            .IncludeBase<CreateAbilityDTO, BaseAbility>();

        CreateMap<BaseAbility, AbilityDTO>()
            .ForMember(dest => dest.Specie, opt => opt.MapFrom(src => src.Specie.Name))
            .ForMember(dest => dest.PokemonLevels,
                opt => opt.MapFrom(src => src.AbilityLevels.ToDictionary(al => al.PokemonId, al => al.Level)));

        // same mapping for all ability types
        CreateMap<ActiveAbility, AbilityDTO>()
            .IncludeBase<BaseAbility, AbilityDTO>();
        CreateMap<PassiveAbility, AbilityDTO>()
            .IncludeBase<BaseAbility, AbilityDTO>();
        CreateMap<StatusAbility, AbilityDTO>()
            .IncludeBase<BaseAbility, AbilityDTO>();


        //Specie
        CreateMap<CreateSpecieDTO, Specie>();
        CreateMap<Specie, SpecieDTO>()
            .ForMember(dest => dest.Pokemons,
                opt => opt.MapFrom(src => src.Pokemons.ToDictionary(p => p.Id, p => p.Name)));

        //SpecieEffectiveness
        CreateMap<CreateSpecieEffectivenessDTO, SpecieEffectiveness>();
        CreateMap<SpecieEffectiveness, SpecieEffectivenessDTO>()
            .ForMember(dest => dest.AttackingSpecie, opt => opt.MapFrom(src => src.AttackingSpecie.Name))
            .ForMember(dest => dest.DefendingSpecie, opt => opt.MapFrom(src => src.DefendingSpecie.Name));

        //Pokemon
        CreateMap<CreatePokemonDTO, Pokemon>()
            .ForMember(dest => dest.Species,
                opt => opt.Ignore());

        CreateMap<Pokemon, PokemonDTO>()
            .ForMember(dest => dest.Species,
                opt => opt.MapFrom(src => src.Species.ToDictionary(s => s.Id, s => s.Name)));

        //Trainer
        CreateMap<CreateTrainerDTO, Trainer>();

        CreateMap<Trainer, TrainerDTO>()
            .ForMember(dest => dest.BattleIds,
                opt => opt.MapFrom(src => src.CreatedBattles.Select(b => b.Id)
                    .Concat(src.JoinedBattles.Select(b => b.Id))
                    .Distinct().ToList()))
            .ForMember(dest => dest.TrainerPokemons,
                opt => opt.MapFrom(src => src.TrainerPokemons.ToDictionary(tp => tp.PokemonId, tp => tp.NickName)));

        // TrainerPokemon
        CreateMap<CreateTrainerPokemonDTO, TrainerPokemon>();

        CreateMap<TrainerPokemon, TrainerPokemonDTO>()
            .ForMember(dest => dest.Abilities,
                opt => opt.MapFrom(src => src.Abilities.ToDictionary(a => a.Id, a => a.Name)))
            .ForMember(dest => dest.PokemonAssignAbilities,
                opt => opt.MapFrom(src =>
                    src.PokemonAssignAbilities.ToDictionary(pa => pa.AbilityId, pa => pa.Ability.Name)))
            .ForMember(dest => dest.BattleIds,
                opt => opt.MapFrom(src => src.Battles.Select(btp => btp.BattleId).Distinct().ToList()));
        
        // Battle
        CreateMap<CreateBattleDTO, Battle>()
            .ForMember(dest => dest.Pokemons, opt => opt.Ignore());

        CreateMap<Battle, BattleDTO>()
            .ForMember(dest => dest.CreatorName,
                opt => opt.MapFrom(src => src.Creator.Nickname))
            .ForMember(dest => dest.JoinerName,
                opt => opt.MapFrom(src => src.Joiner != null ? src.Joiner.Nickname : ""))
            .ForMember(dest => dest.CreatorPokemons,
                opt => opt.MapFrom(src => src.Pokemons
                    .Where(p => p.IsCreatorPokemon).Select(p => p.TrainerPokemon).ToList()))
            .ForMember(dest => dest.JoinerPokemons,
                opt => opt.MapFrom(src => src.Pokemons
                    .Where(p => !p.IsCreatorPokemon).Select(p => p.TrainerPokemon).ToList()));
    }
}