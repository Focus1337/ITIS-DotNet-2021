using DndTaskDb.Models;
using DndTaskDb.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DndTaskDb.Controllers;

[ApiController]
[Route("[action]")]
public class MonsterController : ControllerBase
{
    private readonly MonsterRepository _repository;

    public MonsterController(MonsterRepository repository) =>
        _repository = repository;

    [HttpGet]
    public async Task<IActionResult> GetAllMonsters() =>
        new JsonResult(await _repository.GetAllMonsters());

    [HttpGet]
    public async Task<IActionResult> GetMonsterById([FromQuery] int id) =>
        new JsonResult(await _repository.GetMonsterAsync(id));

    [HttpPost]
    public async Task<IActionResult> AddMonster(Monster newMonster)
    {
        var monster = await _repository.GetMonsterAsync(newMonster.Name);
        if (monster != null)
            return BadRequest($"Monster {newMonster.Name} already exists");
        monster = new Monster
        {
            Name = newMonster.Name,
            AttackModifier = newMonster.AttackModifier,
            AttackPerRound = newMonster.AttackPerRound,
            DamageDicesCount = newMonster.DamageDicesCount,
            DamageDiceType = newMonster.DamageDiceType,
            WeaponModifier = newMonster.WeaponModifier
        };

        await _repository.AddMonsterAsync(monster);
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> RemoveMonster(int id)
    {
        var monster = await _repository.GetMonsterAsync(id);
        if (monster is null)
            return BadRequest($"Monster with id={id} isn't exists");

        await _repository.RemoveMonsterAsync(monster);
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> UpdateMonster([FromBody] Monster updatedMonster)
    {
        var monster = await _repository.GetMonsterAsync(updatedMonster.Id);
        if (monster is null)
            return BadRequest($"Monster with id={updatedMonster.Id} isn't exists");

        monster.Name = updatedMonster.Name;
        monster.AttackModifier = updatedMonster.AttackModifier;
        monster.AttackPerRound = updatedMonster.AttackPerRound;
        monster.DamageDicesCount = updatedMonster.DamageDicesCount;
        monster.DamageDiceType = updatedMonster.DamageDiceType;
        monster.WeaponModifier = updatedMonster.WeaponModifier;

        await _repository.UpdateMonsterAsync(monster);
        return Ok();
    }
}