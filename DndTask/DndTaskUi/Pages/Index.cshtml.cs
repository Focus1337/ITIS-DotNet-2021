using DndTaskUi.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DndTaskUi.Pages;

public class IndexModel : PageModel
{
    public List<Character> Characters { get; set; } = null!;

    private static readonly HttpClient client = new();

    public async Task OnGetAsync()
    {
        var responseMessage = await client.GetAsync("https://localhost:7049/GetAllCharacters");
        var content = responseMessage.Content;
#if (DEBUG == true)
        Console.WriteLine(await content.ReadAsStringAsync());
#endif
        Characters = (await content.ReadFromJsonAsync<List<Character>>())!;
    }
}