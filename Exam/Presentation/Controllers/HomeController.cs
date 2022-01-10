using System.Diagnostics;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models;

namespace Presentation.Controllers;

public class HomeController : Controller
{
    private readonly HttpClient _client;
    public HomeController()
    {
        var clientHandler = new HttpClientHandler();
        clientHandler.ServerCertificateCustomValidationCallback = (message, certificate2, arg3, arg4) => true;
        _client = new HttpClient(clientHandler);
    }

    public async Task<IActionResult> IndexAsync()
    {
        var responseMessage = await _client.GetAsync("https://localhost:7156/GetAllCharacters");
        var content = responseMessage.Content;
#if (DEBUG == true)
        Console.WriteLine(await content.ReadAsStringAsync());
#endif
        ViewBag.Characters = (await content.ReadFromJsonAsync<List<Character>>())!;
        
        responseMessage = await _client.GetAsync("https://localhost:7156/GetRandomMonster");
        content = responseMessage.Content;
#if (DEBUG == true)
        Console.WriteLine(await content.ReadAsStringAsync());
#endif
        
        ViewBag.RandomMonster = (await content.ReadFromJsonAsync<Monster?>())!;

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Fight(int characterId, int monsterId)
    {
        ViewBag.Status = $"{characterId}, {monsterId}";
        
        return View("Fight");
    }

    public IActionResult Privacy() => View();

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() => 
        View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
}