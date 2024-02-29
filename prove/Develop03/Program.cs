using System;

class Program
{
    static void Main(string[] args)
    {
        List<Word> wordInstances = Reference.CreateWords(Scripture.scripture);
        int wordsHidden = 0;
        Random rng = new Random();

        Console.WriteLine("Press Enter to hide 3 words:");
        Console.WriteLine("James 1:5 -");
        Reference.PrintWords(wordInstances);
        while (wordsHidden < wordInstances.Count)
        {
            Console.ReadLine();
            Console.Clear();
            for (int i = 0; i < 3 && wordsHidden < wordInstances.Count; i++)
            {
                int randomIndex;
                do
                {
                    randomIndex = rng.Next(wordInstances.Count);
                } while (wordInstances[randomIndex].hidden);
                wordInstances[randomIndex].Hide();
                wordsHidden++;
            }
            Console.WriteLine("James 1:5 -");
            Reference.PrintWords(wordInstances);
        }
    }
}