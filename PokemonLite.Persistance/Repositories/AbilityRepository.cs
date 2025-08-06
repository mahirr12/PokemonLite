using PokemonLite.Domain.Entities;
using PokemonLite.Persistance.DataBase;

namespace PokemonLite.Persistance.Repositories;

public class AbilityRepository(PokemonDBContext context):GenericRepository<BaseAbility>(context)
{
    public void Test()
    {
        context.AddAsync(new ActiveAbility());

        var activeAbility = context.Set<BaseAbility>().OfType<ActiveAbility>().ToList();
    }
}