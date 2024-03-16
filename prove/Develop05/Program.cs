using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
class Program
{
    static int totalPoints = 0;
    static List<Goal> goals = new List<Goal>();

    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Goal Tracker!");
        while (true)
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Create a simple goal (A single goal with a description)");
            Console.WriteLine("2. Create an eternal goal (A goal that persists indefinitely)");
            Console.WriteLine("3. Create a list goal (A goal with multiple entries to complete)");
            Console.WriteLine("4. Complete a goal");
            Console.WriteLine("5. Display total points");
            Console.WriteLine("6. Save/Load goals");
            Console.WriteLine("7. Exit program");

            Console.Write("Enter your choice: ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    CreateSimpleGoal();
                    break;

                case "2":
                    CreateEternalGoal();
                    break;

                case "3":
                    CreateListGoal();
                    break;

                case "4":
                    CompleteGoal();
                    break;

                case "5":
                    Console.WriteLine("You have a total of: " + totalPoints + "pts!");
                    break;

                case "6":
                    SaveLoad();
                    break;

                case "7":
                    Console.WriteLine("Exiting program...");
                    return;

                default:
                    Console.WriteLine("Invalid input. Please enter a number corresponding to an option.");
                    break;
            }
        }
    }

    static void SaveLoad()
    {
        Console.WriteLine("Choose an option:");
        Console.WriteLine("1. Save goals to file");
        Console.WriteLine("2. Load goals from file");

        Console.Write("Enter your choice: ");
        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                SaveGoals();
                break;

            case "2":
                LoadGoals();
                break;

            default:
                Console.WriteLine("Invalid input. Please enter a valid option.");
                break;
        }
    }

    static void SaveGoals()
    {
        Console.Write("Enter file name to save goals: ");
        string fileName = Console.ReadLine();

        string json = JsonSerializer.Serialize(goals, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(fileName, json);

        Console.WriteLine($"Goals saved to {fileName}.");
    }

    static void LoadGoals()
    {
        Console.Write("Enter file name to load goals: ");
        string fileName = Console.ReadLine();

        if (File.Exists(fileName))
        {
            string json = File.ReadAllText(fileName);
            goals = JsonSerializer.Deserialize<List<Goal>>(json);
            Console.WriteLine($"Goals loaded from {fileName}.");
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }

    static void CreateSimpleGoal()
    {
        Console.WriteLine("Enter goal name:");
        string name = Console.ReadLine();

        Console.WriteLine("Enter goal description:");
        string description = Console.ReadLine();

        Goal myGoal = new Goal(name, description);
        goals.Add(myGoal);
        myGoal.PrintGoalInfo();
    }

    static void CreateEternalGoal()
    {
        Console.WriteLine("Enter goal name:");
        string name = Console.ReadLine();

        Console.WriteLine("Enter goal description:");
        string description = Console.ReadLine();

        EternalGoal myEternalGoal = new EternalGoal(name, description);
        goals.Add(myEternalGoal);
        myEternalGoal.PrintGoalInfo();
    }

    static void CreateListGoal()
    {
        Console.WriteLine("Enter goal name:");
        string name = Console.ReadLine();

        Console.WriteLine("Enter goal description:");
        string description = Console.ReadLine();

        Console.WriteLine("Enter the number of entries for the list goal:");
        int goalEntries = Convert.ToInt32(Console.ReadLine());

        ListGoal myListGoal = new ListGoal(name, description, goalEntries);
        goals.Add(myListGoal);
        myListGoal.PrintGoalInfo();
    }

    static void CompleteGoal()
    {
        if (goals.Count == 0 || goals.TrueForAll(g => g.Completed))
        {
            Console.WriteLine("No incomplete goals available to complete.");
            return;
        }

        DisplayGoals();
        Console.WriteLine("Enter the number of the goal you want to complete:");

        if (!int.TryParse(Console.ReadLine(), out int selectedGoalIndex))
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
            return;
        }

        selectedGoalIndex--;

        if (selectedGoalIndex >= 0 && selectedGoalIndex < goals.Count)
        {
            goals[selectedGoalIndex].CompleteGoal(ref totalPoints);
        }
        else
        {
            Console.WriteLine("Invalid goal number.");
        }
    }

    
    static void DisplayGoals()
    {
        Console.WriteLine("Available Goals:");
        int count = 0;
        for (int i = 0; i < goals.Count; i++)
        {
            if (!goals[i].Completed)
            {
                Console.WriteLine($"{++count}. {goals[i].DisplayName()}");
            }
        }
    }
}
