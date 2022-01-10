using BAL.Models;
// ReSharper disable StringLiteralTypo

namespace BAL.Services;

public static class Fighter
{
    private static readonly List<string>? Log = new();

    public static List<string> GetLog(Character player, Monster monster)
    {
        for (;;)
        {
            if (CheckHealthPoints(player, monster))
                break;
            Attack(player, monster);
            if (CheckHealthPoints(player, monster))
                break;
            Attack(monster, player);
        }

        return Log!;
    }


    private static void Attack(Character character, Monster monster)
    {
        for (var i = 0; i < character.AttackPerRound; i++)
        {
            var random = Random.Shared.Next(20) + 1;
            var modifiers = character.AttackModifier;
            Log!.Add($"{character.Name} выкинул {random}(+{modifiers}) на атаку\r\n");

            if (random == 20)
                Log.Add("Критический урон!\r\n");

            if (random + modifiers <= monster.ArmourClass) continue;

            Log.Add($"больше {monster.ArmourClass}\r\n");
            Log.Add("Попал\r\n");

            var damageRandom = 0;
            for (var j = 0; j < character.DamageDiceCount; ++j)
                damageRandom += Random.Shared.Next(character.DamageDiceEdges) + 1;

            var damageModifiers = character.DamageModifier;
            Log!.Add($"выкинул {damageRandom}(+{damageModifiers}) на дамаг\r\n");
            monster.HitPoints -= (damageRandom + damageModifiers) * (random == 20 ? 2 : 1);
            
            var temp = monster.HitPoints > 0 ? monster.HitPoints : 0;
            Log.Add(
                $"{monster.Name} теряет {(damageRandom + damageModifiers) * (random == 20 ? 2 : 1)} хп, осталось {temp}\r\n");
        }
    }

    private static void Attack(Monster monster, Character character)
    {
        for (var i = 0; i < monster.AttackPerRound; i++)
        {
            var random = Random.Shared.Next(20) + 1;
            var modifiers = monster.AttackModifier;
            Log!.Add($"{monster.Name} выкинул {random}(+{modifiers}) на атаку");
            if (random == 20)
                Log.Add("Критический урон!");

            if (random + modifiers <= character.ArmourClass) continue;

            Log.Add($"больше {character.ArmourClass}");
            Log.Add("Попал");

            var damageRandom = 0;
            for (var j = 0; j < monster.DamageDiceCount; ++j)
                damageRandom += Random.Shared.Next(monster.DamageDiceEdges) + 1;

            var damageModifiers = monster.DamageModifier;
            Log.Add($"выкинул {damageRandom}(+{damageModifiers}) на дамаг");

            character.HitPoints -= (damageRandom + damageModifiers) * (random == 20 ? 2 : 1);
            
            var temp = character.HitPoints > 0 ? character.HitPoints : 0;
            Log.Add(
                $"{character.Name} теряет {(damageRandom + damageModifiers) * (random == 20 ? 2 : 1)} хп, осталось {temp}");
        }
    }

    private static bool CheckHealthPoints(Character player, Monster monster)
    {
        if (player.HitPoints <= 0)
        {
            Log!.Add($"{monster.Name} выиграл\r\n");
            return true;
        }

        if (monster.HitPoints <= 0)
        {
            Log!.Add($"{player.Name} выиграл\r\n");
            return true;
        }

        return false;
    }
}