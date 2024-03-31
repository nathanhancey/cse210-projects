using System;

class Fight
{
    private Mob mob;
    private Player player;

    public void GetMob(string mobName)
    {
        mob = new Mob();
        mob.GetMob(mobName);
    }

    public void SetPlayer(Player player)
    {
        this.player = player;
    }

    private void MobTurn()
    {
        if (mob == null)
        {
            Console.WriteLine("No mob selected for the fight.");
            return;
        }

        int damageDealt = mob.MobAction();

        int newPlayerHealth = player.GetHealth() - damageDealt;
        player.SetHealth(newPlayerHealth);

        Console.WriteLine($"You have {player.GetHealth()} HP left.");
    }

    private void PlayerTurn()
    {
        // Finish Player logic
    }

    public void StartFight()
    {
        if (mob == null)
        {
            Console.WriteLine("No mob selected for the fight.");
            return;
        }

        Console.WriteLine($"The {mob.GetName()} aproaches looking to fight.");

        while (mob.GetHealth() > 0)
        {
            MobTurn();
            if (mob.GetHealth() <= 0)
            {
                Console.WriteLine($"{mob.GetName()} defeated!");
                break;
            }

            PlayerTurn();
            // Add checks to end the fight and finish player turn logic
        }
    }
}
