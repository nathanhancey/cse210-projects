using System;
using System.Collections.Generic;

class Player : Character
{
    private List<Action> actions = new List<Action>();
    private List<Item> items = new List<Item>();

    public void CreateCharacter()
    {
        Console.WriteLine("Choose your character class:");
        Console.WriteLine("1. Wizard");
        Console.WriteLine("2. Knight");
        Console.WriteLine("3. Ranger");
        Console.WriteLine("4. Rogue");

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
                break;
            case 2: // Knight
                SetHealth(120);
                Action knightAction = new Action();
                knightAction.GetAction("Swing Sword");
                actions.Add(knightAction);
                break;
            case 3: // Ranger
                SetHealth(100);
                Action rangerAction = new Action();
                rangerAction.GetAction("Shoot Arrow");
                actions.Add(rangerAction);
                break;
            case 4: // Rogue
                SetHealth(90);
                Action rogueAction = new Action();
                rogueAction.GetAction("Stab Knife");
                actions.Add(rogueAction);
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

    public void PlayerTurn()
    {
        while (true)
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Use Action");
            Console.WriteLine("2. Use Item");
            Console.WriteLine("3. Go back");

            int choice;
            while (true)
            {
                Console.Write("Enter your choice: ");
                if (int.TryParse(Console.ReadLine(), out choice) && choice >= 1 && choice <= 3)
                    break;
                else
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 3.");
            }

            switch (choice)
            {
                case 1: // Use Action
                    ChooseAction();
                    break;
                case 2: // Use Item
                    ChooseItem();
                    break;
                case 3: // Go back
                    return;
            }
        }
    }

    private void ChooseAction()
    {
        if (actions.Count == 0)
        {
            Console.WriteLine("No actions available.");
            return;
        }

        Console.WriteLine("Choose an action:");
        for (int i = 0; i < actions.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {actions[i].GetName()}");
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
        int damage = chosenAction.CalculateDamage();
        Console.WriteLine($"Dealt {damage} damage to the enemy.");
    }

    private void ChooseItem()
    {
        if (items.Count == 0)
        {
            Console.WriteLine("No items available.");
            return;
        }

        Console.WriteLine("Choose an item:");
        for (int i = 0; i < items.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {items[i].GetName()}");
        }

        int choice;
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out choice) && choice >= 1 && choice <= items.Count)
                break;
            else
                Console.WriteLine("Invalid choice. Please enter a valid number.");
        }

        Item chosenItem = items[choice - 1];
        chosenItem.UseItem();
    }
}
