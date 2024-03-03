using System;
using System.Threading;
using System.Threading.Tasks;

public class ListingActivity : Activity
{
    private readonly string[] prompts = {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public void StartListing()
    {
        int duration = GetDuration();

        Console.WriteLine("This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");

        Random random = new Random();
        int index = random.Next(prompts.Length);
        string prompt = prompts[index];
        Console.WriteLine($"Prompt: {prompt}");

        Console.WriteLine($"You have {duration} seconds to list.");

        Timer(3);

        Console.WriteLine($"Start listing...");

        int itemCount = 0;

        Task timerTask = Task.Run(() => Timer(duration));

        while (!timerTask.IsCompleted)
        {
            Console.WriteLine($"(Press enter to submit entry or to exit when timer is finished)");
            string input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
                break;
            itemCount++;
        }

        Console.WriteLine($"You thought of {itemCount} entries.");

        GoodbyeMessage();
    }
}
