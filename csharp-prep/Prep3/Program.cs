using System;

class Program
{
    static void Main(string[] args)
    {
        /*
        Console.WriteLine("Hello Prep3 World!");

        // while loop
        int count = 0;
        while (count < 5)
        {
            System.Console.WriteLine($"count = {count+1}");
        }


        // do-while loop
        int morecount = 0;
        do {
            System.Console.WriteLine($"moreCount = {morecount++}");
        } while (morecount < 5);


        // for loop
        for(var i=0; i<5; ++i) {
            System.Console.WriteLine($"i = {i}");
        }
        */

        Random randomGenerator = new Random();
        
        int random = randomGenerator.Next(1, 101);

        int guess;
        do {
            // Ask for user quess.
            System.Console.Write("Guess a number:");
            guess = int.Parse(Console.ReadLine());

            // Check quess relative to random number.
            if (guess > random) {
                System.Console.WriteLine("Too High");
            }

            else if(guess < random) {
                System.Console.WriteLine("Too Low");
            }

            else{
                System.Console.WriteLine("Correct");
            }
        } while (random != guess);
    }
}