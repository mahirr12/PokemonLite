using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PokemonLite.Domain.Entities;

namespace PokemonLite.Persistance.DataBase;

public class PokemonDBContext : IdentityDbContext<User>
{
    public PokemonDBContext(DbContextOptions<PokemonDBContext> options) : base(options)
    {
    }


    public DbSet<ActiveAbility> ActiveAbilities { get; set; }
    public DbSet<Area> Areas { get; set; }
    public DbSet<Gym> Gyms { get; set; }
    public DbSet<PassiveAbility> PassiveAbilities { get; set; }
    public DbSet<Pokemon> Pokemons { get; set; }
    public DbSet<Specie> Species { get; set; }
    public DbSet<SpecieEffectiveness> SpecieEffectivenesses { get; set; }
    public DbSet<StatusAbility> StatusAbilities { get; set; }
    public DbSet<Trainer> Trainers { get; set; }
    public DbSet<TrainerPokemon> TrainerPokemons { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PokemonDBContext).Assembly);
    }
}