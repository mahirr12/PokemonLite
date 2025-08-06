using AutoMapper;
using PokemonLite.Contract.DTOs.Ability;
using PokemonLite.Contract.IServices;
using PokemonLite.Domain.Entities;
using PokemonLite.Domain.IRepositories;

namespace PokemonLite.Application.Services;

public class AbilityService(
    IMapper mapper, 
    IGenericRepository<BaseAbility> repository, 
    IUnitOfWork unitOfWork)
    : GenericService<BaseAbility, CreateAbilityDTO, AbilityDTO>(mapper, repository, unitOfWork), IAbilityService
{
    public new async Task<AbilityDTO> CreateAsync(CreateAbilityDTO createAbilityDto)
    {
        BaseAbility? baseAbility = createAbilityDto.AbilityType switch
        {
            AbilityType.Active => mapper.Map<ActiveAbility>(createAbilityDto),
            AbilityType.Passive => mapper.Map<PassiveAbility>(createAbilityDto),
            AbilityType.Status => mapper.Map<StatusAbility>(createAbilityDto),
            _ => null
        };
        if (baseAbility == null)
            throw new ArgumentException("Invalid ability type provided.");
        var addedEntity = await repository.AddAsync(baseAbility);
        var addedDto = mapper.Map<AbilityDTO>(addedEntity);
        await unitOfWork.SaveChangesAsync();
        return addedDto;
    }
}