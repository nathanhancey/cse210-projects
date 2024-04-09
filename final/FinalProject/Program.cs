using System;

class Program
{
    private static int roomNumber = 1;

    static void Main(string[] args)
    {
        // Create a player
        Player player = new Player();
        player.CreateCharacter();

        string outcome = "";

        // First level of the dungeon
        do
        {
            Room room = new Room();
            outcome = room.EnterRoom(roomNumber, player);
            roomNumber++;
            if (outcome == "defeat")
            {
                Console.WriteLine("You were defeated. Game Over.");
                return; // Exit the program
            }
        }
        while (roomNumber < 6);

        // Boss #1
        Console.WriteLine("A cold chill rushes over you as you enter the final room of the dungeon level. At the other end: stairs.");
        Console.WriteLine("In between you and the further levels of the dungeon is the master of the undead. The Necromancer.");
        Fight bossfight1 = new Fight();
        bossfight1.SetPlayer(player);
        bossfight1.GetMob("Necromancer");
        outcome = bossfight1.StartFight();
        if (outcome == "defeat")
        {
            Console.WriteLine("You were defeated by the Necromancer. Game Over.");
            return; // Exit the program
        }

        roomNumber++;

        // Second level of dungeon
        do
        {
            Room room = new Room();
            outcome = room.EnterRoom(roomNumber, player);
            roomNumber++;
            if (outcome == "defeat")
            {
                Console.WriteLine("You were defeated. Game Over.");
                return; // Exit the program
            }
        }
        while (roomNumber < 11);

        // Boss #2 (final boss)
        Console.WriteLine("The great iron banded door opens wide. Crystal lights illuminate the final room of the dungeon.");
        Console.WriteLine("Crystals begin floating together making the body of the Dungeon Guardian.");
        Fight bossfight2 = new Fight();
        bossfight2.SetPlayer(player);
        bossfight2.GetMob("Dungeon Guardian");
        outcome = bossfight2.StartFight();
        if (outcome == "defeat")
        {
            Console.WriteLine("You were defeated by the Dungeon Guardian. Game Over.");
            return; // Exit the program
        }

        Console.WriteLine("The sunlight is hard on your eyes, but nonetheless you emerge from the dungeon victorious.");
    }
}
