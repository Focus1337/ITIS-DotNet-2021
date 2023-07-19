using System.ComponentModel.DataAnnotations;

namespace DndTaskDb.Models;

public class Character
{
    [Required] public int Id { get; set; }

    [Required] public string Name { get; set; } = null!;

    [Required] public int AttackModifier { get; set; }

    [Required] public int AttackPerRound { get; set; }

    [Required] public int DamageDicesCount { get; set; }

    [Required] public int DamageDiceType { get; set; }

    [Required] public int WeaponModifier { get; set; }
}