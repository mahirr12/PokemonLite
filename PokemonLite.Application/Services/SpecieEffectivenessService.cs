using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PokemonLite.Contract.DTOs.SpecieEffectiveness;
using PokemonLite.Contract.IServices;
using PokemonLite.Domain.Entities;
using PokemonLite.Domain.IRepositories;

namespace PokemonLite.Application.Services;

public class SpecieEffectivenessService(
    IMapper mapper,
    ISpecieEffectivenessRepository repository,
    IUnitOfWork unitOfWork)
    : ISpecieEffectivenessService
{
    public async Task<SpecieEffectivenessDTO?> GetByIdAsync(Guid aId, Guid dId)
    {
        var data = await repository.GetByIdAsync(aId, dId);
        if (data == null)
            return null;
        var dto = mapper.Map<SpecieEffectivenessDTO>(data);
        return dto;
    }

    public async Task<IEnumerable<SpecieEffectivenessDTO>> GetAllAsync()
    {
        var datas = await repository.GetAll().ToListAsync();
        var dtos = mapper.Map<IEnumerable<SpecieEffectivenessDTO>>(datas);
        return dtos;
    }
    
    public async Task<IEnumerable<SpecieEffectivenessDTO>> GetAllBySpecieAsync(Guid specieId)
    {
        var datas = await repository.GetAllBySpecie(specieId).ToListAsync();
        var dtos = mapper.Map<IEnumerable<SpecieEffectivenessDTO>>(datas);
        return dtos;
    }

    public async Task<SpecieEffectivenessDTO> CreateAsync(CreateSpecieEffectivenessDTO dto)
    {
        var entity = mapper.Map<SpecieEffectiveness>(dto);
        var addedEntity = await repository.AddAsync(entity);
        var addedDto = mapper.Map<SpecieEffectivenessDTO>(addedEntity);
        await unitOfWork.SaveChangesAsync();
        return addedDto;
    }

    public async Task<SpecieEffectivenessDTO> UpdateAsync(CreateSpecieEffectivenessDTO dto)
    {
        var entity = mapper.Map<SpecieEffectiveness>(dto);
        var updatedEntity = repository.Update(entity);
        var updatedDto = mapper.Map<SpecieEffectivenessDTO>(updatedEntity);
        await unitOfWork.SaveChangesAsync();
        return updatedDto;
    }

    public async Task<bool> DeleteAsync(Guid aId, Guid dId)
    {
        var result = await repository.DeleteAsync(aId, dId);
        if (!result) return false;
        await unitOfWork.SaveChangesAsync();
        return true;
    }
}