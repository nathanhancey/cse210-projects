using System;

class Reference
{
    public static List<Word> CreateWords(string text)
    {
        string[] words = text.Split(new char[] { ' ' });
        List<Word> wordInstances = new List<Word>();
        foreach (string word in words)
        {
            wordInstances.Add(new Word(word));
        }
        return wordInstances;
    }
    public static void PrintWords(List<Word> words)
    {
        foreach (var word in words)
        {
            Console.Write(word + " ");
        }
        Console.WriteLine();
    }
}

