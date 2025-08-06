using PokemonLite.Domain.IRepositories;
using PokemonLite.Persistance.DataBase;

namespace PokemonLite.Persistance.Repositories;

public class UnitOfWork(PokemonDBContext context) : IUnitOfWork
{
    private readonly PokemonDBContext _context = context;

    public async Task<int> SaveChangesAsync()
        => await _context.SaveChangesAsync();
}