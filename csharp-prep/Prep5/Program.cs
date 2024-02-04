using System;

class Program
{
    static void Main(string[] args)
    {
        Welcome();

        string UserName = AskName();
        int UserNumber = AskNumber();

        int SquaredNumber = SquareNumber(UserNumber);

        End(UserName, SquaredNumber);
    }

    static void Welcome()
    {
        Console.WriteLine("Welcome to Nathan's program!");
    }

    static string AskName()
    {
        Console.Write("What is Your name?: ");
        return Console.ReadLine();
    }

    static int AskNumber()
    {
        Console.Write("Give me a number: ");
        return int.Parse(Console.ReadLine());
    }

    static int SquareNumber(int number)
    {
        int square = number * number;
        return square;
    }

    static void End(string name, int square)
    {
        Console.WriteLine($"Goodbye {name}.");
        Console.WriteLine($"Your number squared is {square}.");
    }
}