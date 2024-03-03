using System;
using System.Threading.Tasks;

public class ReflectionActivity : Activity
{
    private readonly string[] prompts = {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private readonly string[] questions = {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public void StartReflection()
    {
        int duration = GetDuration();

        Console.WriteLine("This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.");

        Random random = new Random();
        int promptIndex = random.Next(prompts.Length);
        string prompt = prompts[promptIndex];
        Console.WriteLine($"Prompt: {prompt}");

        Console.WriteLine($"You have {duration} seconds to answer questions.");

        Timer(duration); // Start the timer

        int questionIndex = 0;

        // Loop until the timer is up
        while (Timer(1))
        {
            Console.WriteLine($"Question: {questions[questionIndex]}");

            // Run the spinner
            Spinner();

            // Pause for a few seconds before continuing to the next question
            Thread.Sleep(3000);

            // Move to the next question
            questionIndex = (questionIndex + 1) % questions.Length;
        }

        Console.WriteLine("Finishing reflection activity.");
    }
}

