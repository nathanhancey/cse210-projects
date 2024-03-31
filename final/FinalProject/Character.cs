using System;

class Character
{
    protected int health = 0;

    public int GetHealth()
    {
        return health;
    }

    public void SetHealth(int newValue)
    {
        health = newValue;
    }
}