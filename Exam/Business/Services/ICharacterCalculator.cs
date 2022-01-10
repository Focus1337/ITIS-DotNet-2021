namespace Business.Services;

public interface ICharacterCalculator
{
    public CalculatedCharacterModel CalculateCharacter(CharacterModel character);
}