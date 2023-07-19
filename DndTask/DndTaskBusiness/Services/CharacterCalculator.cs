namespace DndTaskBusiness.Services;

public class CharacterCalculator : ICharacterCalculator
{
    public CalculatedCharacterModel CalculateCharacter(CharacterModel character)
    {
        var attack = character.AttackModifier + character.AttackModifierAddition;
        var weapon = character.WeaponModifier + character.DamageModifierAddition;
        return new CalculatedCharacterModel(
            Name: character.Name,
            AttackModifier: attack,
            AttackPerRound: character.AttackPerRound,
            DamageDicesCount: character.DamageDicesCount,
            DamageDiceType: character.DamageDiceType,
            WeaponModifier: weapon,
            MinAcToAlwaysHit: character.DamageDicesCount + attack + weapon,
            DamagePerRoundLeft: character.AttackPerRound * (weapon + character.DamageDicesCount),
            DamagePerRoundRight:
            character.AttackPerRound * (weapon + character.DamageDicesCount * character.DamageDiceType));
    }
}