using DndTaskUi.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DndTaskUi.Pages;

public class Result : PageModel
{
    public CalculatedCharacterModel Character { get; set; } = null!;

    private static readonly HttpClient client = new();

    private record CharacterModel(
        string Name,
        int AttackModifier,
        int AttackPerRound,
        int DamageDicesCount,
        int DamageDiceType,
        int WeaponModifier,
        int AttackModifierAddition,
        int DamageModifierAddition);


    public record CalculatedCharacterModel(
        string Name,
        int AttackModifier,
        int AttackPerRound,
        int DamageDicesCount,
        int DamageDiceType,
        int WeaponModifier,
        int MinAcToAlwaysHit,
        int DamagePerRoundLeft,
        int DamagePerRoundRight);

    public async Task OnGetAsync()
    {
        var id = Request.Query["id"];
        var attack = int.Parse(Request.Query["attack"]);
        var weapon = int.Parse(Request.Query["weapon"]);

        var responseMessage = await client.GetAsync($"https://localhost:7049/GetCharacterById?id={id}");
        var content = responseMessage.Content;

#if (DEBUG == true)
        Console.WriteLine(await content.ReadAsStringAsync());
#endif

        var character = (await content.ReadFromJsonAsync<Character>())!;

        var characterModel = new CharacterModel(
            Name: character.Name,
            AttackModifier: character.AttackModifier,
            AttackPerRound: character.AttackPerRound,
            DamageDicesCount: character.DamageDicesCount,
            DamageDiceType: character.DamageDiceType,
            WeaponModifier: character.WeaponModifier,
            AttackModifierAddition: attack,
            DamageModifierAddition: weapon);

        responseMessage = await client.PostAsync($"https://localhost:7198/CalculateCharacterProperties",
            JsonContent.Create(characterModel));
        content = responseMessage.Content;

#if (DEBUG == true)
        Console.WriteLine(await content.ReadAsStringAsync());
#endif

        Character = (await content.ReadFromJsonAsync<CalculatedCharacterModel>())!;
    }
}