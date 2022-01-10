using Microsoft.AspNetCore.Mvc;
using Presentation.Models;

namespace Presentation.Controllers;

// public class HomeController : Controller
// {
//     private readonly HttpClient _client;
//     public HomeController()
//     {
//         var clientHandler = new HttpClientHandler();
//         clientHandler.ServerCertificateCustomValidationCallback = (message, certificate2, arg3, arg4) => true;
//         _client = new HttpClient(clientHandler);
//     }
//
//     public async Task<IActionResult> IndexAsync()
//     {
//         var responseMessage = await _client.GetAsync("https://localhost:7156/GetAllCharacters");
//         var content = responseMessage.Content;
// #if (DEBUG == true)
//         Console.WriteLine(await content.ReadAsStringAsync());
// #endif
//         ViewBag.Characters = (await content.ReadFromJsonAsync<List<Character>>())!;
//         
//         responseMessage = await _client.GetAsync("https://localhost:7156/GetRandomMonster");
//         content = responseMessage.Content;
// #if (DEBUG == true)
//         Console.WriteLine(await content.ReadAsStringAsync());
// #endif
//         
//         ViewBag.RandomMonster = (await content.ReadFromJsonAsync<Monster?>())!;
//
//         return View();
//     }
//
//     [HttpPost]
//     public async Task<IActionResult> Fight(int characterId, int monsterId)
//     {
//         ViewBag.Status = $"{characterId}, {monsterId}";
//         
//         return View("Fight");
//     }
// }


public class HomeController : Controller
{
    private static readonly HttpClient _client = new();

    private record FightStartingModel(Character Character, Monster Monster);

    private record FightResult(string Log);

    public record FightModel(CalculatedCharacter Character, string Log);
    
    // public IActionResult Index() =>
    //     View();

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
        
        // Log
        responseMessage = await _client.PostAsync("https://localhost:7191/Fight",
            JsonContent.Create(new FightStartingModel(character!, monster!)));
        var log = (await responseMessage.Content.ReadFromJsonAsync<FightResult>())!.Log;
        
        return View(new FightModel(calculated!, log));
    }

    // public async Task<IActionResult> Fight(Character player)
    // {
    //     var responseMessage = await _client.GetAsync("https://localhost:7156/GetRandomMonster");
    //     var monster = await responseMessage.Content.ReadFromJsonAsync<Character>();
    //     var w =
    //         await _client.PostAsync("https://localhost:7191/CalculateCharacter", JsonContent.Create(player));
    //     var calculated = await w.Content.ReadFromJsonAsync<CalculatedCharacter>();
    //
    //     var e = await _client.PostAsync("https://localhost:7191/Fight",
    //         JsonContent.Create(new FightStartingModel(player, monster!)));
    //     var log = (await e.Content.ReadFromJsonAsync<FightResult>())!.Log;
    //     return View(new FightModel(calculated!, log));
    // }
}