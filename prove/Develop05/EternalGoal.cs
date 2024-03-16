using System;

class EternalGoal : Goal
{
    public EternalGoal(string name, string description) : base(name, description)
    {

    }

    public override void CompleteGoal(ref int totalPoints)
    {
        Console.WriteLine(Name + ": " + Description);
        Console.WriteLine($"Do you want to complete the goal: {Name}? (1 for yes, 2 for no)");
        int completionInput = Convert.ToInt32(Console.ReadLine());

        if (completionInput == 1)
        {
            totalPoints += 50;
            Console.WriteLine("Entry logged. +50pts!");
        }
        else if (completionInput == 2)
        {
            Console.WriteLine($"Goal entry canceled.");
        }
        else
        {
            Console.WriteLine("Invalid input.");
        }
    }
}