class Goal
{
    public string Name { get; }
    public string Description { get; }
    public bool Completed { get; private set; }

    public Goal(string name, string description)
    {
        Name = name;
        Description = description;
        Completed = false;
    }

    public string DisplayName()
    {
        return $"{Name} ({(Completed ? "Completed" : "Not Completed")})";
    }

    public void PrintGoalInfo()
    {
        Console.WriteLine("Goal Information:");
        Console.WriteLine($"{Name}: {Description}");
        Console.WriteLine("Completed: " + (Completed ? "Yes" : "No"));
    }

    public virtual void CompleteGoal(ref int totalPoints)
    {
        Console.WriteLine(Name + ": " + Description);
        Console.WriteLine($"Do you want to complete the goal: {Name}? (1 for yes, 2 for no)");
        int completionInput = Convert.ToInt32(Console.ReadLine());

        if (completionInput == 1)
        {
            Completed = true;
            totalPoints += 100;
            Console.WriteLine("Goal completed! +100pts!");
        }
        else if (completionInput == 2)
        {
            Console.WriteLine($"Goal {Name} remains incomplete.");
        }
        else
        {
            Console.WriteLine("Invalid input. Goal not completed.");
        }
    }

}
