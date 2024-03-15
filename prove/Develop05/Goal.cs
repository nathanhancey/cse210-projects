using System;

class Goal
{
    public int Points { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool Completed { get; private set; }

    public Goal(int points, string name, string description)
    {
        Points = points;
        Name = name;
        Description = description;
        Completed = false; // By default, the goal is not completed
    }

    public void SetGoalInformation()
    {
        Console.WriteLine("Enter the name of the goal:");
        Name = Console.ReadLine();

        Console.WriteLine("Enter the description of the goal:");
        Description = Console.ReadLine();

        Console.WriteLine("Enter the points for the goal:");
        Points = Convert.ToInt32(Console.ReadLine());
    }

    public void PrintGoalInfo()
    {
        Console.WriteLine("Goal Information:");
        Console.WriteLine(Name + ": " + Description);
        Console.WriteLine("Completed: " + (Completed ? "Yes" : "No"));
    }

    public void CompleteGoal()
    {
        if (Completed)
        {
            Console.WriteLine("Goal is already completed!");
            return;
        }

        Console.WriteLine("Was the goal completed? (1 for yes, 0 for no)");
        int completionInput = Convert.ToInt32(Console.ReadLine());

        if (completionInput == 1)
        {
            Completed = true;
            Console.WriteLine("Goal completed!");
        }
        else
        {
            Console.WriteLine("Goal not completed.");
        }
    }
}
