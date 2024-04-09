using System;
using System.ComponentModel.Design;

class Fight
{
    private Mob mob;
    private Player player;
    private int playertick = 0;
    private int mobtick = 0;

    public void GetMob(string mobName)
    {
        mob = new Mob();
        mob.GetMob(mobName);
    }

    public void SetPlayer(Player player)
    {
        this.player = player;
    }

    private void MobRound()
    {
        if (mob == null)
        {
            Console.WriteLine("No mob selected for the fight.");
            return;
        }

        Console.WriteLine("<><><><><><><><><><><><><><><><><><><><><><><><><><<><><><><><><><><><><><><><><><><><><><><><><><><><>");

        (int damageDealt, int tick) = mob.MobAction();
        int newPlayerHealth = player.GetHealth() - damageDealt;
        player.SetHealth(newPlayerHealth);

        if (tick > 0)
        {
            Console.WriteLine($"{mob.GetName()} dealt {tick} points of poison damage.");
            playertick += tick;
        }

        Console.WriteLine($"You have {player.GetHealth()} HP left.");

        if (mobtick > 0)
        {
            Console.WriteLine($"{mob.GetName()} took {mobtick} points poison of damage.");
            int newMobHealth = mob.GetHealth() - mobtick;
            mob.SetHealth(newMobHealth);
            Console.WriteLine($"The {mob.GetName()} has {mob.GetHealth()} HP left.");
        }

        Console.WriteLine("<><><><><><><><><><><><><><><><><><><><><><><><><><<><><><><><><><><><><><><><><><><><><><><><><><><><>");
    }

    private void PlayerRound()
    {
        for (int i = 0; i < 2; i++)
        {
            printInfo();
            // Check if the mob is still alive
            if (mob.GetHealth() <= 0)
            {
                return; // Exit if the mob is dead
            }

            // PlayerTurn logic remains the same
            (int damageDealt, int tick) = player.PlayerTurn();
            if (damageDealt >= 0)
            {
                int newMobHealth = mob.GetHealth() - damageDealt;
                mob.SetHealth(newMobHealth);

                Console.WriteLine($"The {mob.GetName()} has {mob.GetHealth()} HP left.");

                if (tick > 0)
                {
                    Console.WriteLine($"You dealt {tick} points of poison damage to the {mob.GetName()}.");
                    mobtick += tick;
                }
            }
            else
            {
                int newPlayerHealth = player.GetHealth() - damageDealt;

                // Check if healing exceeds max health
                int maxPlayerHealth = player.GetMaxHealth();
                if (newPlayerHealth > maxPlayerHealth)
                {
                    Console.WriteLine($"You healed to maximum health.");
                    newPlayerHealth = maxPlayerHealth;
                }
                else
                {
                    Console.WriteLine($"You healed {Math.Abs(damageDealt)} points.");
                }

                player.SetHealth(newPlayerHealth);
                Console.WriteLine($"You have {player.GetHealth()} HP left.");

                if (tick < 0)
                {
                    Console.WriteLine($"You are healing {Math.Abs(tick)} per round.");
                    playertick += tick;
                }
            }
        }

        if (playertick > 0)
        {
            Console.WriteLine($"You took {playertick} points of poison damage from the {mob.GetName()}.");
            int newPlayerHealth = player.GetHealth() - playertick;
            player.SetHealth(newPlayerHealth);
            Console.WriteLine($"You have {player.GetHealth()} HP left.");
        }

        if (playertick < 0)
        {
            int newPlayerHealth = player.GetHealth() - playertick;
            int maxPlayerHealth = player.GetMaxHealth();
            int healedAmount = 0;

            if (newPlayerHealth > maxPlayerHealth)
            {
                healedAmount = player.GetHealth() - maxPlayerHealth;
                newPlayerHealth = maxPlayerHealth;
            }
            else
            {
                healedAmount = -playertick;
            }

            player.SetHealth(newPlayerHealth);

            Console.WriteLine($"You healed {Math.Abs(healedAmount)} points of health.");
            Console.WriteLine($"You have {player.GetHealth()} HP left.");
        }
    }

    public string StartFight()
    {

        string outcome = "";

        if (mob == null || player == null)
        {
            Console.WriteLine("No mob or player selected for the fight.");
            return outcome;
        }

        Console.WriteLine($"The {mob.GetName()} approaches, ready to fight.");

        // Determine who goes first
        bool playerIsRogue = player.GetClass().Equals("Rogue", StringComparison.OrdinalIgnoreCase);
        bool playerGoesFirst = playerIsRogue || new Random().Next(2) == 0; // 50/50 chance for other classes

        // Handle main fight logic
        while (mob.GetHealth() > 0 && player.GetHealth() > 0)
        {
            if (playerGoesFirst)
            {
                PlayerRound();
                if (mob.GetHealth() <= 0)
                {
                    Console.WriteLine($"The {mob.GetName()} defeated!");
                    return outcome;
                }

                MobRound();
                if (player.GetHealth() <= 0)
                {
                    Console.WriteLine($"The player fell.");
                    outcome = "defeat";
                    return outcome;
                }
            }
            else
            {
                MobRound();
                if (player.GetHealth() <= 0)
                {
                    Console.WriteLine($"The player fell.");
                    outcome = "defeat";
                    return outcome;
                }

                PlayerRound();
                if (mob.GetHealth() <= 0)
                {
                    Console.WriteLine($"The {mob.GetName()} defeated!");
                    return outcome;
                }
            }
        }

        return outcome;
    }

    private void printInfo()
    {
        Console.WriteLine("**********************************************************************************************************************");

        Console.WriteLine($"Player: {player.GetHealth()} HP, {playertick} HP per round");
        Console.WriteLine($"{mob.GetName()}: {mob.GetHealth()} HP, {mobtick} HP per round");

        Console.WriteLine("**********************************************************************************************************************");
    }
}
