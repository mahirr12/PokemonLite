namespace PokemonLite.Domain.IRepositories;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync();
}