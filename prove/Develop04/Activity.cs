using System;
using System.Reflection.Metadata;
public class Activity
{
    public int GetDuration()
    {
        Console.Write("Enter duration of activity (in seconds): ");
        return int.Parse(Console.ReadLine());
    }
    public void Spinner()
    {
        string[] spinnerAnimation = { "I", "/", "-", "\\" };

        for (int i = 0; i < spinnerAnimation.Length; i++)
        {
            Console.Write(spinnerAnimation[i]);
            Thread.Sleep(100);
        }
    }

    public static bool Timer(int durationInSeconds)
    {
        DateTime startTime = DateTime.Now;

        while (true)
        {
            TimeSpan elapsedTime = DateTime.Now - startTime;
            int remainingTime = durationInSeconds - (int)elapsedTime.TotalSeconds;

            if (remainingTime <= 0)
            {
                return true;
            }

            Console.WriteLine($"{remainingTime}");
            Thread.Sleep(1000);
        }
    }

    public void GoodbyeMessage()
    {
        Console.WriteLine("Thank you for participating in this mindfulness activity.");
    }
}
