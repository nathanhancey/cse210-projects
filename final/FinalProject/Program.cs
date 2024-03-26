using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter the name of the action: ");
        string actionName = Console.ReadLine();

        Playeraction action = new Playeraction();
        action.GetAction(actionName);
        action.PrintAction();
    }
}
