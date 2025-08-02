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
    //public DbSet<Area> Areas { get; set; }
    public DbSet<BaseAbility> BaseAbilities { get; set; }
    //public DbSet<Gym> Gyms { get; set; }
    public DbSet<PassiveAbility> PassiveAbilities { get; set; }
    public DbSet<Pokemon> Pokemons { get; set; }
    public DbSet<PokemonAssignAbility> PokemonAssignAbilities { get; set; }
    public DbSet<Specie> Species { get; set; }
    public DbSet<SpecieEffectiveness> SpecieEffectivenesses { get; set; }
    public DbSet<StatusAbility> StatusAbilities { get; set; }
    public DbSet<Trainer> Trainers { get; set; }
    public DbSet<TrainerPokemon> TrainerPokemons { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<AbilityLevels>()
            .HasKey(al => new { al.PokemonId, al.BaseAbilityId });
        
        modelBuilder.Entity<PokemonAssignAbility>()
            .HasKey((pa=>new { pa.TrainerPokemonId, pa.BaseAbilityId }));
        modelBuilder.Entity<SpecieEffectiveness>()
            .HasKey(se => new { se.AttackingSpecieId, se.DefendingSpecieId });

        modelBuilder.Entity<AbilityLevels>()
            .HasOne(al => al.BaseAbility)
            .WithMany(ba => ba.AbilityLevels)
            .HasForeignKey(al => al.BaseAbilityId);

        // modelBuilder.Entity<Area>().HasOne(a => a.Champion)
        //     .WithMany()
        //     .HasForeignKey(a => a.ChampionId)
        //     .OnDelete(DeleteBehavior.SetNull);
    }
}