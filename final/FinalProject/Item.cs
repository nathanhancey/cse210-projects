using System;
using System.IO;
using System.Collections.Generic;

class Item
{
    private string name = "";
    private int damage = 0;
    private int hits = 0;
    private int accuracy = 0;
    private int tick = 0;
    private int charges = 0;

    public void GetItem(string itemName)
    {
        string filePath = @"GameData\Items.txt";
        string[] lines = File.ReadAllLines(filePath);

        foreach (string line in lines)
        {
            string[] parts = line.Split(',');
            if (parts.Length == 6 && parts[0].Trim().Equals(itemName, StringComparison.OrdinalIgnoreCase))
            {
                name = parts[0].Trim();
                damage = int.Parse(parts[1].Trim());
                hits = int.Parse(parts[2].Trim());
                accuracy = int.Parse(parts[3].Trim());
                tick = int.Parse(parts[4].Trim());
                charges = int.Parse(parts[5].Trim());
                return;
            }
        }

        throw new ArgumentException("Item not found in the file.", nameof(itemName));
    }

    public void PrintItem()
    {
        if (damage >= 0)
        {
            if (tick == 0)
            {
                Console.Write($"{charges}x {name}: {accuracy}% 1-{damage}x{hits} dmg.");
            }
            else
            {
                Console.Write($"{charges}x {name}: 1-{damage}x{hits} dmg + {tick} poison.");
            }
        }
        else
        {
            if (tick == 0)
            {
                Console.Write($"{charges}x {name}: {accuracy}% 1-{Math.Abs(damage)}x{hits} healing.");
            }
            else
            {
                Console.Write($"{charges}x {name}: {accuracy}% 1-{Math.Abs(damage)}x{hits} healing + {Math.Abs(tick)} healing over time.");
            }
        }
    }

    public (int totalDamage, int tick) UseItem()
    {
        if (charges <= 0)
        {
            Console.WriteLine($"You are out of charges for {name}.");
            return (0, 0);
        }

        Random random = new Random();
        int totalDamage = 0;
        List<int> damageRolls = new List<int>();

        int successfulHits = 0;
        for (int i = 0; i < hits; i++)
        {
            if (random.Next(1, 101) <= accuracy)
            {
                successfulHits++;

                int damageRoll;
                if (damage > 0)
                {
                    damageRoll = random.Next(1, damage + 1);// Damage roll
                }
                else if (damage < 0)
                {
                    damageRoll = random.Next(damage, 0); // Healing roll
                }
                else
                {
                    damageRoll = 0;// No roll
                }

                totalDamage += damageRoll;
                damageRolls.Add(damageRoll);
            }
        }

        if (damage >= 0)
        {
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
        }
        else
        {
            if (successfulHits == 0)
            {
                Console.WriteLine($"You used {name} and missed.");
            }
            else
            {
                Console.Write($"You healed {successfulHits} times for ");
                foreach (int roll in damageRolls)
                {
                    Console.Write($"{roll}, ");
                }
                Console.WriteLine($"for a total of {Math.Abs(totalDamage)}.");
            }
        }

        charges--;

        return (totalDamage, tick);
    }

    public string GetName()
    {
        return name;
    }

    public int GetCharges()
    {
        return charges;
    }
}
