using System;
using System.IO;

class Playeraction
{
    private string name = "";
    private int damage = 0;
    private int hits = 0;
    private int accuracy = 0;
    private int tick = 0;

    // Method to get action details based on the given name
    public void GetAction(string actionName)
    {
        string filePath = "actions.txt"; // Path to the text file
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

    // Method to print action details
    public void PrintAction()
    {
        Console.WriteLine($"Action Name: {name}");
        Console.WriteLine($"Damage: {damage}");
        Console.WriteLine($"Hits: {hits}");
        Console.WriteLine($"Accuracy: {accuracy}");
        Console.WriteLine($"Tick: {tick}");
    }
}
