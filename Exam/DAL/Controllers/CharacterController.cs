using DAL.Models;
using DAL.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DAL.Controllers;

[ApiController]
[Route("[action]")]
public class CharacterController : ControllerBase
{
    private readonly CharacterRepository _repository;

    public CharacterController(CharacterRepository repository) =>
        _repository = repository;

    // [HttpGet]
    // public IActionResult GetAllCharacterNamesAndId() =>
    //     new JsonResult(_repository.GetAllCharacterNamesAndId());

    [HttpGet]
    public async Task<IActionResult> GetAllCharacters() =>
        new JsonResult(await _repository.GetAllCharacters());

    [HttpGet]
    public async Task<IActionResult> GetCharacterById([FromQuery] int id) =>
        new JsonResult(await _repository.GetCharacterAsync(id));

    [HttpPost]
    public async Task<IActionResult> AddCharacter(Character newCharacter)//([FromBody] Character newCharacter)
    {
        var character = await _repository.GetCharacterAsync(newCharacter.Name);

        if (character != null)
            return BadRequest($"Character {newCharacter.Name} already exists");

        character = new Character
        {
            Name = newCharacter.Name,
            AttackModifier = newCharacter.AttackModifier,
            AttackPerRound = newCharacter.AttackPerRound,
            // DamageDicesCount = newCharacter.DamageDicesCount,
            // DamageDiceType = newCharacter.DamageDiceType,
            // WeaponModifier = newCharacter.WeaponModifier
        };

        await _repository.AddCharacterAsync(character);
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> RemoveCharacter(int id)
    {
        var character = await _repository.GetCharacterAsync(id);

        if (character is null)
            return BadRequest($"Character with id={id} isn't exists");

        await _repository.RemoveCharacterAsync(character);

        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> UpdateCharacter([FromBody] Character updatedCharacter)
    {
        var character = await _repository.GetCharacterAsync(updatedCharacter.Id);

        if (character is null)
            return BadRequest($"Character with id={updatedCharacter.Id} isn't exists");

        character.Name = updatedCharacter.Name;
        character.AttackModifier = updatedCharacter.AttackModifier;
        character.AttackPerRound = updatedCharacter.AttackPerRound;
        // character.DamageDicesCount = updatedCharacter.DamageDicesCount;
        // character.DamageDiceType = updatedCharacter.DamageDiceType;
        // character.WeaponModifier = updatedCharacter.WeaponModifier;

        await _repository.UpdateCharacterAsync(character);
        return Ok();
    }
}