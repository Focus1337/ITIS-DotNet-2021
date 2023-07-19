namespace DndTaskUi.Models;

public class Character
{ 
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int AttackModifier { get; set; }
    public int AttackPerRound { get; set; }
    public int DamageDicesCount { get; set; }
    public int DamageDiceType { get; set; }
    public int WeaponModifier { get; set; }
}