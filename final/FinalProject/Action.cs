using System;
using System.IO;

class Action
{
    protected string name = "";
    protected int damage = 0;
    protected int hits = 0;
    protected int accuracy = 0;
    protected int tick = 0;

    virtual public void GetAction(string actionName)
    {
        string filePath = @"GameData\PlayerActions.txt";
        string[] lines = File.ReadAllLines(filePath);

        foreach (string line in lines)
        {
            string[] parts = line.Split(',');
            if (parts.Length == 5 && parts[0].Trim().Equals(actionName, StringComparison.OrdinalIgnoreCase))
            {
                name = parts[0].Trim();
                damage = int.Parse(parts[1].Trim());
                hits = int.Parse(parts[2].Trim());
                accuracy = int.Parse(parts[3].Trim());
                tick = int.Parse(parts[4].Trim());
                return;
            }
        }

        throw new ArgumentException("Action not found in the file.", nameof(actionName));
    }

    virtual public void PrintAction()
    {
        if (tick == 0)
        {
            Console.Write($"{name}: {accuracy}% 1-{damage}x{hits} dmg.");
        }
        else
        {
            Console.Write($"{name}: {accuracy}% 1-{damage}x{hits} dmg + {tick} poison.");
        }
    }

    virtual public (int totalDamage, int tick) CalculateDamage()
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
            Console.WriteLine($"0> You used {name} and missed. <0");
        }
        else
        {
            Console.Write($"0> You landed {successfulHits} hits for ");
            foreach (int roll in damageRolls)
            {
                Console.Write($"{roll}, ");
            }
            Console.WriteLine($"for a total of {totalDamage}. <0");
        }

        return (totalDamage, tick);
    }

    public string GetName()
    {
        return name;
    }
}
