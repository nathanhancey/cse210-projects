using System;

class Program
{
    static void Main(string[] args)
    {
        BreathingActivity breathingActivity = new BreathingActivity();
        ListingActivity listingActivity = new ListingActivity();
        ReflectionActivity reflectionActivity = new ReflectionActivity();

        while (true)
        {
            Console.WriteLine("Choose an activity:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Listing Activity");
            Console.WriteLine("3. Reflection Activity");
            Console.WriteLine("4. Exit");

            Console.Write("Enter the number of the activity you want to do: ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    breathingActivity.StartBreathing();
                    break;
                case "2":
                    listingActivity.StartListing();
                    break;
                case "3":
                    reflectionActivity.StartReflection();
                    break;
                case "4":
                    Console.WriteLine("Exiting program...");
                    return;
                default:
                    Console.WriteLine("Invalid input. Please enter a number corresponding to the activity or '4' to exit.");
                    break;
            }
        }
    }
}
