using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome, what's your name?");
        string name = Console.ReadLine();
        Console.WriteLine($"Hello {name}, please provide your percentage grade:");
        int grade = int.Parse(Console.ReadLine());
        string letterGrade;
        bool passed;

        if (grade >= 90)
        {
            letterGrade = "A";
            passed = true;
        }
        else if (grade >= 80)
        {
            letterGrade = "B";
            passed = true;
        }
        else if (grade >= 70)
        {
            letterGrade = "C";
            passed = true;
        }
        else if (grade >= 60)
        {
            letterGrade = "D";
            passed = false;
        }
        else
        {
            letterGrade = "F";
            passed = false;
        }

        if (grade % 10 >= 7)
        {
            if (letterGrade != "A" && letterGrade != "F")
            {
                letterGrade += "+";
            }
        }
        else if (grade % 10 < 3)
        {
            if (letterGrade != "F")
            {
                letterGrade += "-";
            }
        }

        if (passed)
        {
            Console.WriteLine($"Congratulations {name}! Your letter grade is {letterGrade}, you passed!");
        }
        else
        {
            Console.WriteLine($"Unluckily you didn't pass. Your letter grade is {letterGrade}, try harder again!");
        }

    }
}