using System;
using System.Collections.Generic;
using System.IO;

class Mob : Character
{
    private string name = "";
    private List<Mobaction> actions = new List<Mobaction>();
    private Random random = new Random();

    public void GetMob(string mobName)
    {
        string filePath = @"GameData\Mobs.txt";
        string[] lines = File.ReadAllLines(filePath);

        foreach (string line in lines)
        {
            string[] parts = line.Split(',');
            if (parts.Length >= 2 && parts[0].Trim().Equals(mobName))
            {
                name = parts[0].Trim();
                health = int.Parse(parts[1].Trim());
                for (int i = 2; i < parts.Length; i++)
                {
                    string actionName = parts[i].Trim();
                    GetAction(actionName);
                }
                return;
            }
        }
        throw new ArgumentException("Mob not found in the file.", nameof(mobName));
    }

    public void PrintMobInfo()
    {
        Console.WriteLine($"Mob Name: {name}");
        Console.WriteLine($"Health: {health}");
        Console.WriteLine("Actions:");
        foreach (var action in actions)
        {
            action.PrintAction();
        }
    }

    private void GetAction(string actionName)
    {
        Mobaction action = new Mobaction();
        action.GetAction(actionName);
        actions.Add(action);
    }

    public (int totalDamage, int tick) MobAction()
    {
        if (actions.Count == 0)
        {
            throw new InvalidOperationException("No actions available for this mob.");
        }

        Mobaction selectedAction = actions[random.Next(actions.Count)];
        (int totalDamage, int tick) actionResult = selectedAction.CalculateDamage();
        return actionResult;
    }

    public string GetName()
    {
        return name;
    }
}
