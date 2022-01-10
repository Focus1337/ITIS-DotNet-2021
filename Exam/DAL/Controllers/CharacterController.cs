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

    [HttpGet]
    public async Task<IActionResult> GetAllCharacters() =>
        new JsonResult(await _repository.GetAllCharacters());

    [HttpGet]
    public async Task<IActionResult> GetCharacterById([FromQuery] int id) =>
        new JsonResult(await _repository.GetCharacterAsync(id));

    [HttpPost]
    public async Task<IActionResult> AddCharacter(Character newCharacter)
    {
        var character = await _repository.GetCharacterAsync(newCharacter.Name);

        if (character != null)
            return BadRequest($"Character {newCharacter.Name} already exists");

        character = new Character
        {
            Name = newCharacter.Name,
            HitPoints = newCharacter.HitPoints,
            AttackModifier = newCharacter.AttackModifier,
            DamageModifier = newCharacter.DamageModifier,
            DamageDiceCount = newCharacter.DamageDiceCount,
            DamageDiceEdges = newCharacter.DamageDiceEdges,
            ArmourClass = newCharacter.ArmourClass,
            AttackPerRound = newCharacter.AttackPerRound
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
        character.HitPoints = updatedCharacter.HitPoints;
        character.AttackModifier = updatedCharacter.AttackModifier;
        character.DamageModifier = updatedCharacter.DamageModifier;
        character.DamageDiceCount = updatedCharacter.DamageDiceCount;
        character.DamageDiceEdges = updatedCharacter.DamageDiceEdges;
        character.ArmourClass = updatedCharacter.ArmourClass;
        character.AttackPerRound = updatedCharacter.AttackPerRound;

        await _repository.UpdateCharacterAsync(character);
        return Ok();
    }
}