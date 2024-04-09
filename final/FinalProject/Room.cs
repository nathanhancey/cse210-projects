using System;
using System.ComponentModel;
using System.IO;

class Room
{
    private int level;
    private Player player;
    private Random random = new Random();

    public string EnterRoom(int room, Player playerParameter)
    {

        string outcome = "";
        player = playerParameter;

        if (room <= 5)
        {
            level = 1;
        }
        else if (room <= 11 && room > 6)
        {
            level = 2;
        }
       
        Console.WriteLine("--------------------------------------------------------------------------------------------");

        Console.WriteLine("You open the door into another section of the dungeon.");

        if (random.Next(2) == 0)
        {
            outcome = PerformAbilityCheck();
        }
        else
        {
            outcome = EncounterMonster();
        }

        if (random.Next(10) < 7)
        {
            FindLoot();
        }

        return outcome;
    }

    private string PerformAbilityCheck()
    {
        string filePath = $"GameData\\AbilityChecks_{level}.txt";
        string[] abilityChecks = File.ReadAllLines(filePath);

        Random random = new Random();
        int randomIndex = random.Next(0, abilityChecks.Length);
        string[] chosenParts = abilityChecks[randomIndex].Split(',');

        if (chosenParts.Length >= 3)
        {
            string ability = chosenParts[0].Trim();
            string flavorText = chosenParts[1].Trim();
            string reward = chosenParts[2].Trim();

            Console.WriteLine(flavorText);
            Console.WriteLine($"Investigating this will take some {ability}.");
            Console.WriteLine("Do you want to attempt this?");
            Console.WriteLine("1. Yes");
            Console.WriteLine("2. No");

            int choice;
            while (true)
            {
                Console.Write("Enter your choice (1 or 2): ");
                if (int.TryParse(Console.ReadLine(), out choice) && (choice == 1 || choice == 2))
                    break;
                else
                    Console.WriteLine("Invalid choice. Please enter 1 or 2.");
            }

            if (choice == 2)
            {
                Console.WriteLine("You walk away from the challenge.");
                return "";
            }

            int difficulty = level * 2 + 2;
            int checkResult = player.AbilityCheck(ability);

            if (checkResult >= difficulty)
            {
                player.AddItem(reward);
                Console.WriteLine($"You succeeded and found {reward}.");
            }
            else
            {
                int playerHealth = player.GetHealth();
                int damage = random.Next(1, 7) * level;
                playerHealth -= damage;
                player.SetHealth(playerHealth);
                Console.WriteLine($"You failed the ability check and took {damage} damage.");
                
                if (playerHealth <= 0)
                {
                    Console.WriteLine("You died from the failed ability check.");
                    return "defeat";
                }
            }
        }
        else
        {
            Console.WriteLine("Invalid format for ability check data.");
        }
        
        return "";
    }

    private string EncounterMonster()
    {
        string filePath = $"GameData\\Monsters_{level}.txt";
        string[] monsterLines = File.ReadAllLines(filePath);

        Random random = new Random();
        int randomIndex = random.Next(0, monsterLines.Length);
        string[] chosenParts = monsterLines[randomIndex].Split(',');
        string chosenMonster = chosenParts[0].Trim();
        string flavorText = chosenParts[1].Trim();

        Console.WriteLine($"{flavorText}");

        Fight fight = new Fight();
        fight.SetPlayer(player);
        fight.GetMob(chosenMonster);

        return fight.StartFight();
    }

    private void FindLoot()
    {
        string filePath = $"GameData\\Loot_{level}.txt";
        string[] lootLines = File.ReadAllLines(filePath);

        Random random = new Random();
        int randomIndex = random.Next(0, lootLines.Length);
        string acquiredItem = lootLines[randomIndex].Trim();

        player.AddItem(acquiredItem);

        Console.WriteLine($"You see a chest at the end of the room. You have acquired: {acquiredItem}");
    }
}
