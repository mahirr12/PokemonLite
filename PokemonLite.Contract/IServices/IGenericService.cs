using System.Linq.Expressions;
using PokemonLite.Domain.Entities;

namespace PokemonLite.Contract.IServices;

public interface IGenericService<T, CreateTDto, TDto>
    where T : BaseEntity, new()
    where CreateTDto : class
    where TDto : class
{
    Task<TDto?> GetByIdAsync(Guid id, params Expression<Func<T, object>>[] includeProperties);
    Task<IEnumerable<TDto>> GetAllAsync(params Expression<Func<T, object>>[] includeProperties);
    Task<TDto> CreateAsync(CreateTDto dto);
    Task<TDto> UpdateAsync(CreateTDto dto);
    Task<bool> DeleteAsync(Guid id);
}