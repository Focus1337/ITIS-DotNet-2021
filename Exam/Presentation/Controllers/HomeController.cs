using Microsoft.AspNetCore.Mvc;
using Presentation.Models;

namespace Presentation.Controllers;

public class HomeController : Controller
{
    private static readonly HttpClient _client = new();
    
    private record StartFight(Character Player, Monster Monster);
    public record Result(string Log, Character Character);

    public record FightModel(CalculatedCharacter Character, string Log);//, Character DamagedCharacter);

    public async Task<IActionResult> IndexAsync()
    {
        var responseMessage = await _client.GetAsync("https://localhost:7156/GetAllCharacters");
        var content = responseMessage.Content;
        ViewBag.Characters = (await content.ReadFromJsonAsync<List<Character>>())!;
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> AddCharacter(Character? character)
    {
        await _client.PostAsync("https://localhost:7156/AddCharacter",
            JsonContent.Create(character));
 
        return NoContent();
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
            JsonContent.Create(new StartFight(character!, monster!)));

        var fightResult = await responseMessage.Content.ReadFromJsonAsync<Result>();
        return View(new FightModel(calculated!, fightResult!.Log));
    }
}