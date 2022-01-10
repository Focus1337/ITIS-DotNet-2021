using BAL.Models;
using BAL.Services;
using Microsoft.AspNetCore.Mvc;

namespace BAL.Controllers;

[ApiController]
[Route("[action]")]
public class FightController
{
    public record FightInput(Character Player, Monster Monster);
    private record FightResult(string Log);
    [HttpPost]
    public IActionResult Fight(FightInput input)
    {
        var (character, monster) = input;
        return new JsonResult(new FightResult(FightsDealer.GetFightLog(character, monster)));
    }
}