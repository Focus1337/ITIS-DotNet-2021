using Microsoft.AspNetCore.Mvc;
using Presentation.Models;

namespace Presentation.Controllers;

public class HomeController : Controller
{
    private static readonly HttpClient _client = new();

    // private record FightStartingModel(Character Character, Monster Monster);
    private record FightStartingModel(Character Player, Monster Monster);
    public record FightResult(string Log, Character Character);

    public record FightModel(CalculatedCharacter Character, string Log, Character DamagedCharacter);

    public async Task<IActionResult> IndexAsync()
    {
        var responseMessage = await _client.GetAsync("https://localhost:7156/GetAllCharacters");
        var content = responseMessage.Content;
        ViewBag.Characters = (await content.ReadFromJsonAsync<List<Character>>())!;
        return View();
    }

    public async Task<IActionResult> Fight(int characterId)
    {
        // Selected character
        var responseMessage = await _client.GetAsync($"https://localhost:7156/GetCharacterById?id={characterId}");
        var character = await responseMessage.Content.ReadFromJsonAsync<Character>();

        // Random monster
        responseMessage = await _client.GetAsync("https://localhost:7156/GetRandomMonster");
        var monster = await responseMessage.Content.ReadFromJsonAsync<Monster>();

        // Calculated character
        responseMessage =
            await _client.PostAsync("https://localhost:7191/CalculateCharacter", JsonContent.Create(character));
        var calculated = await responseMessage.Content.ReadFromJsonAsync<CalculatedCharacter>();

        ViewBag.Calculated = calculated!;

        // Log
        responseMessage = await _client.PostAsync("https://localhost:7191/Fight",
            JsonContent.Create(new FightStartingModel(character!, monster!)));

        // var log = (await responseMessage.Content.ReadFromJsonAsync<FightResult>())!.Log;
        // return View(new FightModel(calculated!, log));

        var fightResult = await responseMessage.Content.ReadFromJsonAsync<FightResult>();
       // return View();
        return View(new FightModel(calculated!, fightResult!.Log, fightResult.Character));
    }
}

public class LogResult
{
    //public string Log { get; set; } = null!;
    public List<string> Log { get; set; } = null!;
}