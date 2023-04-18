using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Guess the magic number");
        Random randomNum = new Random();
        int number = randomNum.Next(1, 100);

        string message;
        bool userGuessed = false;
        int guess;
        int tries = 0;

        do
        {
            Console.WriteLine("What is your guess?");
            guess = int.Parse(Console.ReadLine());
            tries++;

            if (guess < number)
            {
                message = "Higher";
            }
            else if (guess > number)
            {
                message = "Lower";
            }
            else
            {
                message = $"You guessed it! It took you {tries} tries";
                userGuessed = true;
            }

            Console.WriteLine(message);
            if (userGuessed)
            {
                Console.WriteLine("Would you like to play again?");
                string again = Console.ReadLine();
                if (again == "yes")
                {
                    userGuessed = false;
                    number = randomNum.Next(1, 100);
                    tries = 0;
                }
                else
                {
                    Console.WriteLine("Thanks for playing");
                }
            }
        } while (userGuessed == false);

    }
}