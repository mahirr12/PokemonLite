using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PokemonLite.Contract.IServices;
using PokemonLite.Domain.Entities;
using PokemonLite.Domain.IRepositories;

namespace PokemonLite.Application.Services;

public class GenericService<T, CreateTDto, TDto>(
    IMapper mapper, 
    IGenericRepository<T> repository,
    IUnitOfWork unitOfWork)
    : IGenericService<T, CreateTDto, TDto>
    where T : BaseEntity, new()
    where CreateTDto : class
    where TDto : class
{
    public async Task<TDto?> GetByIdAsync(Guid id)
    {
        var data = await repository.GetByIdAsync(id);
        var dto = mapper.Map<TDto>(data);
        return dto;
    }

    public async Task<IEnumerable<TDto>> GetAllAsync()
    {
        var datas = await repository.GetAll().ToListAsync();
        var dtos = mapper.Map<IEnumerable<TDto>>(datas);
        return dtos;
    }

    public async Task<TDto> CreateAsync(CreateTDto dto)
    {
        var entity = mapper.Map<T>(dto);
        var addedEntity = await repository.AddAsync(entity);
        var addedDto = mapper.Map<TDto>(addedEntity);
        await unitOfWork.SaveChangesAsync();
        return addedDto;
    }

    public async Task<TDto> UpdateAsync(CreateTDto dto)
    {
        var entity = mapper.Map<T>(dto);
        var updatedEntity = repository.Update(entity);
        var updatedDto = mapper.Map<TDto>(updatedEntity);
        await unitOfWork.SaveChangesAsync();
        return updatedDto;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var result = await repository.DeleteAsync(id);
        if (!result) return false;
        await unitOfWork.SaveChangesAsync();
        return true;
    }
}