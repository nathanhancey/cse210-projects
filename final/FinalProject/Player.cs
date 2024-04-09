using System;
using System.Collections.Generic;

class Player : Character
{
    private List<Action> actions = new List<Action>();
    private List<Item> items = new List<Item>();

    private string playerclass = "";
    private int maxhealth = 0;
    private int intellegence = 0;
    private int strength = 0;
    private int survival = 0;
    private int dexterity = 0;

    public void CreateCharacter()
    {
        Console.WriteLine("Choose your character class:");
        Console.WriteLine("1. Wizard: Magical attacks that always hit. Very intellegent, somewhat dexterous");
        Console.WriteLine("2. Knight: Heavy armor and heavy attacks. Very strong, some survival skills.");
        Console.WriteLine("3. Ranger: Has poison arrows and deadly bear trap. Lots of survival skills and somewhat strong.");
        Console.WriteLine("4. Rogue: Always strikes first. Very dexterous, and somewhat intellegent.");

        int choice;
        while (true)
        {
            Console.Write("Enter your choice (1-4): ");
            if (int.TryParse(Console.ReadLine(), out choice) && choice >= 1 && choice <= 4)
                break;
            else
                Console.WriteLine("Invalid choice. Please enter a number between 1 and 4.");
        }

        switch (choice)
        {
            case 1: // Wizard
                SetHealth(80);
                Action wizardAction = new Action();
                wizardAction.GetAction("Cast Magic Missile");
                actions.Add(wizardAction);
                playerclass = "Wizard";
                AddItem("Healing Potion");
                AddItem("Fairy Bottle");
                dexterity = 2;
                intellegence = 4;
                maxhealth = 80;
                break;
            case 2: // Knight
                SetHealth(120);
                Action knightAction = new Action();
                knightAction.GetAction("Swing Sword");
                actions.Add(knightAction);
                playerclass = "Knight";
                AddItem("Healing Potion");
                survival = 2;
                strength = 4;
                maxhealth = 120;
                break;
            case 3: // Ranger
                SetHealth(100);
                Action rangerAction = new Action();
                rangerAction.GetAction("Shoot Arrow");
                actions.Add(rangerAction);
                playerclass = "Ranger";
                AddItem("Bear Trap");
                AddItem("Poison Arrow");
                strength = 2;
                survival = 4;
                maxhealth = 100;
                break;
            case 4: // Rogue
                SetHealth(90);
                Action rogueAction = new Action();
                rogueAction.GetAction("Stab Knife");
                actions.Add(rogueAction);
                playerclass = "Rogue";
                AddItem("Healing Potion");
                intellegence = 2;
                dexterity = 4;
                maxhealth = 90;
                break;
        }
    }

    public void PrintCharacterDetails()
    {
        Console.WriteLine($"Character Health: {GetHealth()}");
        Console.WriteLine("Character Actions:");
        foreach (var action in actions)
        {
            Console.WriteLine($"- {action.GetName()}");
        }
    }

    public (int totalDamage, int tick) PlayerTurn()
    {
        while (true)
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Use Action");
            Console.WriteLine("2. Use Item");

            int choice;
            while (true)
            {
                Console.Write("Enter your choice: ");
                if (int.TryParse(Console.ReadLine(), out choice) && choice >= 1 && choice <= 3)
                    break;
                else
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 2.");
            }

            switch (choice)
            {
                case 1:
                    (int totalDamage, int tick) actionResult = ChooseAction();
                    return actionResult;
                case 2:
                    actionResult = ChooseItem();
                    return actionResult;
            }
        }
    }

    private (int totalDamage, int tick) ChooseAction()
    {
        if (actions.Count == 0)
        {
            Console.WriteLine("No actions available.");
            return (0, 0);
        }

        Console.WriteLine("Choose an action:");
        for (int i = 0; i < actions.Count; i++)
        {
            Action currentAction = actions[i];
            Console.Write($"{i + 1}. ");
            currentAction.PrintAction();
            Console.WriteLine();
        }

        int choice;
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out choice) && choice >= 1 && choice <= actions.Count)
                break;
            else
                Console.WriteLine("Invalid choice. Please enter a valid number.");
        }

        Action chosenAction = actions[choice - 1];
        return chosenAction.CalculateDamage();
    }

    private (int totalDamage, int tick) ChooseItem()
    {
        List<Item> availableItems = items.Where(item => item.GetCharges() > 0).ToList();

        if (availableItems.Count == 0)
        {
            Console.WriteLine("No items available.");
            return (0, 0);
        }

        Console.WriteLine("Choose an item:");
        for (int i = 0; i < availableItems.Count; i++)
        {
            Item currentItem = availableItems[i];
            Console.Write($"{i + 1}. ");
            currentItem.PrintItem();
            Console.WriteLine();
        }

        int choice;
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out choice) && choice >= 1 && choice <= availableItems.Count)
                break;
            else
                Console.WriteLine("Invalid choice. Please enter a valid number.");
        }

        Item chosenItem = availableItems[choice - 1];
        return chosenItem.UseItem();
    }

    public string GetClass()
    {
        return playerclass;
    }

    public int GetMaxHealth()
    {
        return maxhealth;
    }

    public void AddItem(string itemName)
    {
        Item Item = new Item();
        Item.GetItem(itemName);
        items.Add(Item);
    }

    public int AbilityCheck(string ability)
    {
        Random random = new Random();
        if (ability == "intellegence")
        {
            return random.Next(1, 10) + intellegence;
        }
        else if (ability == "strength")
        {
            return random.Next(1, 10) + strength;
        }
        else if (ability == "survival")
        {
            return random.Next(1, 10) + survival;
        }
        else if (ability == "dexterity")
        {
            return random.Next(1, 10) + dexterity;
        }
  
        return 0;
    }
}
