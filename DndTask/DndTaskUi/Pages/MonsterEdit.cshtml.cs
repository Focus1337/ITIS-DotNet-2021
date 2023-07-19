using DndTaskUi.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DndTaskUi.Pages;

public class MonsterEdit : PageModel
{
    private static readonly HttpClient client = new();

    public async Task OnPostAddAsync(string name, int attackModifier, int attackPerRound,
        int damageDicesCount, int damageDiceType, int weaponModifier)
    {
        var monster = new Monster()
        {
            Name = name,
            AttackModifier = attackModifier,
            AttackPerRound = attackPerRound,
            DamageDicesCount = damageDicesCount,
            DamageDiceType = damageDiceType,
            WeaponModifier = weaponModifier
        };

        var responseMessage = await client.PostAsJsonAsync("https://localhost:7049/AddMonster", monster);
        responseMessage.EnsureSuccessStatusCode();
    }

    public async Task OnPostRemoveAsync(int id)
    {
        var responseMessage = await client.PostAsync($"https://localhost:7049/RemoveMonster?id={id}", null);
        responseMessage.EnsureSuccessStatusCode();
    }
}