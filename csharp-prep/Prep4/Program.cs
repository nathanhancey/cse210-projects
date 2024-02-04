using System;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        string add = "true";

        while (add.ToLower() == "true")
        {
            Console.Write("Enter a number: ");
            int num_input = int.Parse(Console.ReadLine());

            if (num_input == 0)
            {
                add = "False";
            }
            else
            {
                numbers.Add(num_input);
            }
        }

        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }
        int average = sum / numbers.Count;
        int largest_number = numbers.Max();

        System.Console.WriteLine($"The sum is {sum}.");
        System.Console.WriteLine($"The average is {average}.");
        System.Console.WriteLine($"The largest number is {largest_number}.");
    }
}