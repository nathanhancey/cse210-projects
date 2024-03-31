using System;

class Program
{
    static void Main(string[] args)
    {
        Player player = new Player();
        player.CreateCharacter();
        player.PrintCharacterDetails();

        Mob mob = new Mob();

        // Prompt the user to input a mob name
        Console.WriteLine("Enter the name of the mob:");
        string mobName = Console.ReadLine();

        try
        {
            // Retrieve mob data
            mob.GetMob(mobName);

            // Print mob diagnostics
            mob.PrintMobInfo();
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
