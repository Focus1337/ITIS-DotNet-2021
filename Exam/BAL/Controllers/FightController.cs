using BAL.Models;
using BAL.Services;
using Microsoft.AspNetCore.Mvc;

namespace BAL.Controllers;

[ApiController]
[Route("[action]")]
public class FightController
{
    public record FightInput(Character Player, Monster Monster);

    public record FightResult(string Log, Monster Character);

    [HttpPost]
    public IActionResult Fight(FightInput input)
    {
        var (player, monster) = input;
        return new JsonResult(Fighter.GetFightLog(player, monster));
    }
}