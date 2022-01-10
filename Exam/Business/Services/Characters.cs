namespace Business.Services;

public record CharacterModel(
    string Name,
    int AttackModifier,
    int AttackPerRound,
    int DamageDicesCount,
    int DamageDiceType,
    int WeaponModifier,
    int AttackModifierAddition,
    int DamageModifierAddition);

public record CalculatedCharacterModel(
    string Name,
    int AttackModifier,
    int AttackPerRound,
    int DamageDicesCount,
    int DamageDiceType,
    int WeaponModifier,
    int MinAcToAlwaysHit,
    int DamagePerRoundLeft,
    int DamagePerRoundRight);