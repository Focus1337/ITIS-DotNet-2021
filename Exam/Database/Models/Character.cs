namespace Database.Models;

public class Character
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int HitPoints { get; set; }
    public int AttackModifier { get; set; }

    public int DamageModifier { get; set; }

    public int Weapon { get; set; }

    public int DamageDiceCount { get; set; }

    public int DamageDiceEdges { get; set; }

    public int ArmourClass { get; set; }
    public int AttackPerRound { get; set; }
}