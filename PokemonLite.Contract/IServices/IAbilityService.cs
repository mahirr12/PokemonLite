using PokemonLite.Contract.DTOs.Ability;
using PokemonLite.Domain.Entities;

namespace PokemonLite.Contract.IServices;

public interface IAbilityService: IGenericService<BaseAbility, CreateAbilityDTO, AbilityDTO>
{
    public new Task<AbilityDTO> CreateAsync(CreateAbilityDTO createAbilityDto);
}