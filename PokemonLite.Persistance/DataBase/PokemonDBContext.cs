using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PokemonLite.Domain.Entities;
using PokemonLite.Persistance.Implementations;

namespace PokemonLite.Persistance.DataBase;

public class PokemonDBContext(DbContextOptions<PokemonDBContext> options) : IdentityDbContext<User>(options)
{
    //public DbSet<Gym> Gyms { get; set; }
    //public DbSet<Area> Areas { get; set; }
    public DbSet<ActiveAbility> ActiveAbilities { get; set; }
    public DbSet<AbilityLevel> AbilityLevels { get; set; }
    public DbSet<Battle> Battles { get; set; }
    public DbSet<BaseAbility> BaseAbilities { get; set; }
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

        modelBuilder.Entity<Trainer>()
            .HasOne<User>(nameof(Trainer.User))
            .WithOne(u => u.Trainer)
            .HasForeignKey<Trainer>(t => t.UserId);


        modelBuilder.Entity<AbilityLevel>()
            .HasKey(al => new { al.PokemonId, al.BaseAbilityId });

        modelBuilder.Entity<PokemonAssignAbility>()
            .HasKey(pa => new { pa.TrainerPokemonId, BaseAbilityId = pa.AbilityId });
        modelBuilder.Entity<SpecieEffectiveness>()
            .HasKey(se => new { se.AttackingSpecieId, se.DefendingSpecieId });

        modelBuilder.Entity<AbilityLevel>()
            .HasOne(al => al.BaseAbility)
            .WithMany(ba => ba.AbilityLevels)
            .HasForeignKey(al => al.BaseAbilityId);

        modelBuilder.Entity<Battle>()
            .HasOne(b => b.Creator)
            .WithMany(t => t.CreatedBattles)
            .HasForeignKey(b => b.CreatorId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Battle>()
            .HasOne(b => b.Joiner)
            .WithMany(t => t.JoinedBattles)
            .HasForeignKey(b => b.JoinerId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<BattleTrainerPokemon>()
            .HasKey(btp => new { btp.BattleId, btp.TrainerPokemonId });

        modelBuilder.Entity<BattleTrainerPokemon>()
            .HasOne(btp => btp.Battle)
            .WithMany(b => b.Pokemons)
            .HasForeignKey(btp => btp.BattleId);

        modelBuilder.Entity<BattleTrainerPokemon>()
            .HasOne(btp => btp.TrainerPokemon)
            .WithMany(tp => tp.Battles)
            .HasForeignKey(btp => btp.TrainerPokemonId);

        // abilities üçün tpt yanaşması
        modelBuilder.Entity<BaseAbility>().ToTable("BaseAbilities");
        modelBuilder.Entity<ActiveAbility>().ToTable("ActiveAbilities");
        modelBuilder.Entity<PassiveAbility>().ToTable("PassiveAbilities");
        modelBuilder.Entity<StatusAbility>().ToTable("StatusAbilities");

        // modelBuilder.Entity<Area>().HasOne(a => a.Champion)
        //     .WithMany()
        //     .HasForeignKey(a => a.ChampionId)
        //     .OnDelete(DeleteBehavior.SetNull);
    }
}