using DAL.Models;
using DAL.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DAL.Controllers;

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

    [HttpGet]
    public IActionResult GetRandomMonster([FromServices] ApplicationContext dataContext, [FromQuery] int id)
    {
        var random = Random.Shared.Next(dataContext.Monsters.Count());
        return new JsonResult((random > 0 ? dataContext.Monsters.Skip(random) : dataContext.Monsters).First());
    }

    [HttpPost]
    public async Task<IActionResult> AddMonster(Monster newMonster)
    {
        var monster = await _repository.GetMonsterAsync(newMonster.Name);
        if (monster != null)
            return BadRequest($"Monster {newMonster.Name} already exists");
        monster = new Monster
        {
            Name = newMonster.Name,
            HitPoints = newMonster.HitPoints,
            AttackModifier = newMonster.AttackModifier,
            DamageModifier = newMonster.DamageModifier,
            DamageDiceCount = newMonster.DamageDiceCount,
            DamageDiceEdges = newMonster.DamageDiceEdges,
            ArmourClass = newMonster.ArmourClass,
            AttackPerRound = newMonster.AttackPerRound
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
        monster.HitPoints = updatedMonster.HitPoints;
        monster.AttackModifier = updatedMonster.AttackModifier;
        monster.DamageModifier = updatedMonster.DamageModifier;
        monster.DamageDiceCount = updatedMonster.DamageDiceCount;
        monster.DamageDiceEdges = updatedMonster.DamageDiceEdges;
        monster.ArmourClass = updatedMonster.ArmourClass;
        monster.AttackPerRound = updatedMonster.AttackPerRound;

        await _repository.UpdateMonsterAsync(monster);
        return Ok();
    }
}