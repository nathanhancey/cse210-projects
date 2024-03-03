using System;

public class BreathingActivity : Activity
{
    public void StartBreathing()
    {
        int duration = GetDuration();

        Console.WriteLine("This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.");

        while (duration >= 1)
        {
            Console.WriteLine("Breathe in...");
            Timer(4);

            Console.WriteLine("Breathe out...");
            Timer(4);

            duration -= 8;
        }

        GoodbyeMessage();
    }
}
