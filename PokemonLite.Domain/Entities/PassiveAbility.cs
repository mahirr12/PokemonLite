namespace PokemonLite.Domain.Entities;

public class PassiveAbility(
    int duration,
    int ownHealthEffectiveness = 1,
    int ownAttackEffectiveness = 1,
    int ownDefenseEffectiveness = 1,
    int opponentHealthEffectiveness = 1,
    int opponentAttackEffectiveness = 1,
    int opponentDefenseEffectiveness = 1
)
    : BaseAbility
{
    public int Duration { get; set; } = duration; // Duration in turns

    public int[] OwnEffectiveness { get; } =
        [ownHealthEffectiveness, ownAttackEffectiveness, ownDefenseEffectiveness];

    public int[] OpponentEffectiveness { get; } =
        [opponentHealthEffectiveness, opponentAttackEffectiveness, opponentDefenseEffectiveness];
}