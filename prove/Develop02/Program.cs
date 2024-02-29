using System;

class Program
{
    public static Journal journal = new Journal("Imported data");

    static void Main()
    {
        int userInput;
        Console.WriteLine("Journal Program");
        do
        {
            Console.WriteLine("Please input an integer from 1-5 in order to perform your desired action.");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");

            if (!int.TryParse(Console.ReadLine(), out userInput))
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
                continue;
            }

            if (userInput == 1)
            {
                journal.Write();
            }
            else if (userInput == 2)
            {
                journal.Display();
            }
            else if (userInput == 3)
            {
                journal.LoadFromFile();
            }
            else if (userInput == 4)
            {
                journal.SaveToFile();
            }
            else if (userInput == 5)
            {
                // Do nothing
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 5.");
            }

        } while (userInput != 5);
    }
}