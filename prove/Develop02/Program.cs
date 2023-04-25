using System;

class Program
{
    static void Main(string[] args)
    {
        Journal dailyJournal = new Journal();
        int menuOption;
        bool exitMenu = false;

        Console.WriteLine("Hello, what is your name: ");
        string name = Console.ReadLine();
        dailyJournal._username = name;

        do
        {
            Console.WriteLine(dailyJournal.DisplayMenu());
            menuOption = int.Parse(Console.ReadLine());
            Console.WriteLine();
            dailyJournal.ActionMenu(menuOption);
            if (menuOption == 5)
            {
                exitMenu = true;
            }

        } while (exitMenu == false);


    }
}