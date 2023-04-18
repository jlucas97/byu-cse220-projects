using System;

class Program
{
    static void Main(string[] args)
    {
        static void DisplayWelcome()
        {
            Console.WriteLine("Welcome to the Program!");
        }

        static string PromptUserName(string userName)
        {
            return $"{userName}";
        }

        static int PromptUserNumber(int number)
        {
            return number;
        }

        static int SquareNumber(int number)
        {
            return number * number;
        }

        static string DisplayResult(string name, int number)
        {
            return $"{PromptUserName(name)}, the square of your number is {SquareNumber(PromptUserNumber(number))}";
        }

        DisplayWelcome();
        Console.WriteLine("Please enter your name:");
        string userName = PromptUserName(Console.ReadLine());
        Console.WriteLine("Please enter your favorite number:");
        int favNumber = PromptUserNumber(int.Parse(Console.ReadLine()));
        Console.WriteLine(DisplayResult(userName, favNumber));

    }
}