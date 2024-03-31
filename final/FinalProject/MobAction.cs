using System;
using System.IO;

class Mobaction: Action
{
    private int fear = 0;

    override public void GetAction(string actionName)
    {
        string filePath = "MobActions.txt";
        string[] lines = File.ReadAllLines(filePath);

        foreach (string line in lines)
        {
            string[] parts = line.Split(',');
            if (parts.Length == 6 && parts[0].Trim().Equals(actionName, StringComparison.OrdinalIgnoreCase))
            {
                name = parts[0].Trim();
                damage = int.Parse(parts[1].Trim());
                hits = int.Parse(parts[2].Trim());
                accuracy = int.Parse(parts[3].Trim());
                tick = int.Parse(parts[4].Trim());
                fear = int.Parse(parts[5].Trim());
                return;
            }
        }

        throw new ArgumentException("Action not found in the file.", nameof(actionName));
    }


    override public void PrintAction()
    {
        Console.WriteLine($"Action Name: {name}");
        Console.WriteLine($"Damage: {damage}");
        Console.WriteLine($"Hits: {hits}");
        Console.WriteLine($"Accuracy: {accuracy}");
        Console.WriteLine($"Tick: {tick}");
        Console.WriteLine($"Fear: {fear}");
    }

    override public int CalculateDamage()
    {
        Random random = new Random();
        int totalDamage = 0;
        List<int> damageRolls = new List<int>();

        int successfulHits = 0;
        for (int i = 0; i < hits; i++)
        {
            if (random.Next(1, 101) <= accuracy)
            {
                successfulHits++;

                int damageRoll = random.Next(1, damage + 1);
                totalDamage += damageRoll;
                damageRolls.Add(damageRoll);
            }
        }

        if (successfulHits == 0)
        {
            Console.WriteLine($"The enemy uses {name} and misses.");
        }
        else
        {
            Console.Write($"The enemy landed {successfulHits} hits for ");
            foreach (int roll in damageRolls)
            {
                Console.Write($"{roll}, ");
            }
            Console.WriteLine($"for a total of {totalDamage}.");
        }

        return totalDamage;
    }
}
