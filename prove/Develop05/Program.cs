using System;

class Program
{
    static int totalPoints = 0;

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("BlahBlahBlah");

            Console.Write("Blah?");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Goal myGoal = Goal.CreateGoal();
                    myGoal.PrintGoalInfo();
                    break;
                case "2":
                    Goal.GoalCompletion(ref TotalPoints);
                    break;
                case "3":
                    // Save/Load
                    break;
                case "4":
                    Console.WriteLine("Exiting program...");
                    return;
                default:
                    Console.WriteLine("Invalid input. Please enter a number corresponding to an option.");
                    break;
            }
        }
    }
}