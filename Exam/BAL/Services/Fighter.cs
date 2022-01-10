using System.Text;
using BAL.Controllers;
using BAL.Models;
// ReSharper disable StringLiteralTypo

namespace BAL.Services;

// public static class Fighter
// {
//     private static readonly List<string>? Log = new();
//
//     public static List<string> GetLog(Character player, Monster monster)
//     {
//         for (;;)
//         {
//             if (CheckHealthPoints(player, monster))
//                 break;
//             Attack(player, monster);
//             if (CheckHealthPoints(player, monster))
//                 break;
//             Attack(monster, player);
//         }
//
//         return Log!; //.ToString()!;
//     }
//
//
//     private static void Attack(Character character, Monster monster)
//     {
//         for (var i = 0; i < character.AttackPerRound; i++)
//         {
//             var random = Random.Shared.Next(20) + 1;
//             var modifiers = character.AttackModifier;
//             Log!.Add($"{character.Name} выкинул {random}(+{modifiers}) на атаку\r\n");
//
//             if (random == 20)
//                 Log.Add("Критический урон!\r\n");
//
//             if (random + modifiers <= monster.ArmourClass) continue;
//
//             Log.Add($"больше {monster.ArmourClass}\r\n");
//             Log.Add("Попал\r\n");
//
//             var damageRandom = 0;
//             for (var j = 0; j < character.DamageDiceCount; ++j)
//                 damageRandom += Random.Shared.Next(character.DamageDiceEdges) + 1;
//
//             var damageModifiers = character.DamageModifier;
//             Log!.Add($"выкинул {damageRandom}(+{damageModifiers}) на дамаг\r\n");
//             monster.HitPoints -= (damageRandom + damageModifiers) * (random == 20 ? 2 : 1);
//             
//             var temp = monster.HitPoints > 0 ? monster.HitPoints : 0;
//             Log.Add(
//                 $"{monster.Name} теряет {(damageRandom + damageModifiers) * (random == 20 ? 2 : 1)} хп, осталось {temp}\r\n");
//         }
//     }
//
//     private static void Attack(Monster monster, Character character)
//     {
//         for (var i = 0; i < monster.AttackPerRound; i++)
//         {
//             var random = Random.Shared.Next(20) + 1;
//             var modifiers = monster.AttackModifier;
//             Log!.Add($"{monster.Name} выкинул {random}(+{modifiers}) на атаку\r\n");
//             if (random == 20)
//                 Log.Add("Критический урон!\r\n");
//
//             if (random + modifiers <= character.ArmourClass) continue;
//
//             Log.Add($"больше {character.ArmourClass}\r\n");
//             Log.Add("Попал\r\n");
//
//             var damageRandom = 0;
//             for (var j = 0; j < monster.DamageDiceCount; ++j)
//                 damageRandom += Random.Shared.Next(monster.DamageDiceEdges) + 1;
//
//             var damageModifiers = monster.DamageModifier;
//             Log.Add($"выкинул {damageRandom}(+{damageModifiers}) на дамаг\r\n");
//
//             character.HitPoints -= (damageRandom + damageModifiers) * (random == 20 ? 2 : 1);
//             
//             var temp = character.HitPoints > 0 ? character.HitPoints : 0;
//             Log.Add(
//                 $"{character.Name} теряет {(damageRandom + damageModifiers) * (random == 20 ? 2 : 1)} хп, осталось {temp}\r\n");
//         }
//     }
//
//     private static bool CheckHealthPoints(Character player, Monster monster)
//     {
//         if (player.HitPoints <= 0)
//         {
//             Log!.Add($"{monster.Name} выиграл\r\n");
//             return true;
//         }
//
//         if (monster.HitPoints <= 0)
//         {
//             Log!.Add($"{player.Name} выиграл\r\n");
//             return true;
//         }
//
//         return false;
//     }
// }

public static class Fighter
{
    public static FightController.FightResult GetFightLog(Character player, Monster monster)
    {
        var stringBuilder = new StringBuilder();
        for (;;)
        {
            if (CheckHps(player, monster, stringBuilder))
                break;
            if (Attack(player, monster, stringBuilder))
                break;
            if (CheckHps(player, monster, stringBuilder))
                break;
            if (Attack(monster, player, stringBuilder))
                break;
        }

        return new FightController.FightResult(stringBuilder.ToString(), monster);
    }


    private static bool Attack(Character character, Monster monster, StringBuilder stringBuilder)
    {
        for (var i = 0; i < character.AttackPerRound; i++)
        {
            var random = Random.Shared.Next(20) + 1;
            stringBuilder.Append($"{character.Name} атаковал на {random}(+{character.AttackModifier})\r\n");
            if (random == 20)
                stringBuilder.Append("Критический урон!\r\n");

            if (random + character.AttackModifier <= monster.ArmourClass) continue;

            stringBuilder.Append($"Armour Class больше {monster.ArmourClass}. Есть попадание.\r\n");
            var damageRandom = 0;

            for (var j = 0; j < character.DamageDiceCount; ++j)
                damageRandom += Random.Shared.Next(character.DamageDiceEdges) + 1;
            
            stringBuilder.Append($"{character.Name} выкинул кости на {damageRandom}(+{character.DamageModifier}) dmg\r\n");
            
            monster.HitPoints -= (damageRandom + character.DamageModifier) * (random == 20 ? 2 : 1);
            monster.HitPoints = Math.Max(0, monster.HitPoints);
            stringBuilder.Append(
                $"{monster.Name} теряет {(damageRandom + character.DamageModifier) * (random == 20 ? 2 : 1)} hp, осталось: {monster.HitPoints} hp\r\n");
            if (CheckHps(character, monster, stringBuilder))
                return true;
        }

        return false;
    }

    private static bool Attack(Monster monster, Character character, StringBuilder stringBuilder)
    {
        for (var i = 0; i < monster.AttackPerRound; i++)
        {
            var random = Random.Shared.Next(20) + 1;

            stringBuilder.Append($"{monster.Name} атаковал на {random}(+{monster.AttackModifier})\r\n");
            if (random == 20)
                stringBuilder.Append("Критический урон!\r\n");

            if (random + monster.AttackModifier <= character.ArmourClass) continue;

            stringBuilder.Append($"Armour Class больше {character.ArmourClass}. Есть попадание.\r\n");

            var damageRandom = 0;

            for (var j = 0; j < monster.DamageDiceCount; ++j)
                damageRandom += Random.Shared.Next(monster.DamageDiceEdges) + 1;

            stringBuilder.Append($"{monster.Name} выкинул кости на {damageRandom}(+{monster.DamageModifier}) dmg\r\n");
            character.HitPoints -= (damageRandom + monster.DamageModifier) * (random == 20 ? 2 : 1);
            character.HitPoints = Math.Max(0, character.HitPoints);

            stringBuilder.Append(
                $"{character.Name} теряет {(damageRandom + monster.DamageModifier) * (random == 20 ? 2 : 1)} hp, осталось: {character.HitPoints} hp\r\n");
            if (CheckHps(character, monster, stringBuilder))
                return true;
        }

        return false;
    }

    private static bool CheckHps(Character player, Monster monster, StringBuilder stringBuilder)
    {
        if (player.HitPoints <= 0)
        {
            stringBuilder.Append($"{monster.Name} выиграл!\r\n");
            return true;
        }

        if (monster.HitPoints <= 0)
        {
            stringBuilder.Append($"{player.Name} выиграл!\r\n");
            return true;
        }

        return false;
    }
}