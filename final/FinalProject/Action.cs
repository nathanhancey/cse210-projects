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
        string filePath = "PlayerActions.txt";
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
        Console.WriteLine($"Action Name: {name}");
        Console.WriteLine($"Damage: {damage}");
        Console.WriteLine($"Hits: {hits}");
        Console.WriteLine($"Accuracy: {accuracy}");
        Console.WriteLine($"Tick: {tick}");
    }

    virtual public int CalculateDamage()
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
            Console.WriteLine($"You used {name} and missed.");
        }
        else
        {
            Console.Write($"You landed {successfulHits} hits for ");
            foreach (int roll in damageRolls)
            {
                Console.Write($"{roll}, ");
            }
            Console.WriteLine($"for a total of {totalDamage}.");
        }

        return totalDamage;
    }

    public string GetName()
    {
        return name;
    }
}
