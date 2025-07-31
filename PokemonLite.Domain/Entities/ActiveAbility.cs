namespace PokemonLite.Domain.Entities;

public class ActiveAbility(
    int cooldown,
    int healthEffectiveness = 0,
    int attackEffectiveness = 0,
    int defenseEffectiveness = 0
) : BaseAbility
{
    public int Cooldown { get; set; } = cooldown; // Cooldown in turns

    public int[] Effectiveness { get; } =
        [healthEffectiveness, attackEffectiveness, defenseEffectiveness];
}