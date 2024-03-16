class ListGoal : Goal
{
    private int GoalEntries;
    private int CurrentEntries;
    public new bool Completed { get; private set; }

    public ListGoal(string name, string description, int goalEntries) : base(name, description)
    {
        GoalEntries = goalEntries;
        CurrentEntries = 0;
        Completed = false;
    }

    public override void CompleteGoal(ref int totalPoints)
    {
        PrintGoalInfo();
        Console.WriteLine($"You have completed {CurrentEntries} out of {GoalEntries} entries for this goal.");
        Console.WriteLine($"Do you want to complete an entry for the goal: {Name}? (1 for yes, 2 for no)");
        int completionInput;
        if (!int.TryParse(Console.ReadLine(), out completionInput))
        {
            Console.WriteLine("Invalid input.");
            return;
        }

        if (completionInput == 1)
        {
            CurrentEntries += 1;
            totalPoints += 50;
            Console.WriteLine("Entry logged. +50pts!");

            if (CurrentEntries == GoalEntries)
            {
                Completed = true;
                totalPoints += 200;
                Console.WriteLine("Entire Goal Complete! +200pts!");
            }
            else
            {
                Console.WriteLine($"You have completed {CurrentEntries} out of {GoalEntries} entries for this goal.");
            }
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
