namespace PokemonLite.Domain.Entities;

public class PassiveAbility
    : BaseAbility
{
    public int Duration { get; set; }  // Duration in turns

    public int[] OwnEffectiveness { get; set; } =new int[3]; // own effectiveness on (0: hp, 1: attack, 2: defense)
        

    public int[] OpponentEffectiveness { get; set; } = new int[3]; // opponent effectiveness on (0: hp, 1: attack, 2: defense)
        
}