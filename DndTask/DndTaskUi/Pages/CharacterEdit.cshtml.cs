using DndTaskUi.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DndTaskUi.Pages;

public class CharacterEdit : PageModel
{
    private static readonly HttpClient client = new();

    public async Task OnPostAddAsync(string name, int attackModifier, int attackPerRound,
        int damageDicesCount, int damageDiceType, int weaponModifier)
    {
        var character = new Character
        {
            Name = name,
            AttackModifier = attackModifier,
            AttackPerRound = attackPerRound,
            DamageDicesCount = damageDicesCount,
            DamageDiceType = damageDiceType,
            WeaponModifier = weaponModifier
        };

        var responseMessage = await client.PostAsJsonAsync("https://localhost:7049/AddCharacter", character);
        responseMessage.EnsureSuccessStatusCode();
    }

    public async Task OnPostRemoveAsync(int id)
    {
        var responseMessage = await client.PostAsync($"https://localhost:7049/RemoveCharacter?id={id}", null);
        responseMessage.EnsureSuccessStatusCode();
    }
}