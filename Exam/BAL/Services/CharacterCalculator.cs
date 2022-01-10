using BAL.Models;

namespace BAL.Services;


public static class CharacterCalculator
{
    public static CalculatedCharacter Calculate(Character character) =>
        new CalculatedCharacter
        {
            Name = character.Name,
            HitPoints = character.HitPoints,
            AttackModifier = character.AttackModifier,
            AttackPerRound = character.AttackPerRound,
            DamageDiceCount = character.DamageDiceCount,
            DamageDiceEdges = character.DamageDiceEdges,
            DamageModifier = character.DamageModifier,
            ArmourClass = character.ArmourClass,
            MinAcToAlwaysHit = character.AttackModifier + 1,
            MinDamagePerRound = (character.DamageDiceCount + character.DamageModifier) *
                                character.AttackPerRound,
            MaxDamagePerRound = (character.DamageDiceCount * character.DamageDiceEdges + character.DamageModifier) *
                                character.AttackPerRound
        };
}