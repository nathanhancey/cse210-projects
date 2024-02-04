using System;

class Prompt
{
    public static string PromptGet()
    {
        string[] personalPrompts = 
        {
            "Reflect on a moment from today that brought you joy.",
            "Describe a challenge you faced and how you overcame it.",
            "Write about a goal you have for the upcoming week.",
            "Share your thoughts on a book, movie, or song that resonated with you recently.",
            "Explore a fear or worry you've been experiencing and consider ways to address it.",
            "Discuss a meaningful conversation you had with someone today.",
            "Write about a small act of kindness you witnessed or participated in.",
            "Reflect on something you're grateful for in your life right now.",
            "Explore a dream or aspiration you have for your future.",
            "Write about a lesson you learned recently, big or small."
        };

        Random random = new Random();
        int randomIndex = random.Next(personalPrompts.Length);
        return personalPrompts[randomIndex];
    }
}