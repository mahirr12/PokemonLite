namespace PokemonLite.Domain.Entities;

public class ActiveAbility : BaseAbility
{
    public int Cooldown { get; set; } // Cooldown in turns

    public int[] Effectiveness { get; set; } = new int[3]; // Effectiveness on (0: hp, 1: attack, 2: defense)
}