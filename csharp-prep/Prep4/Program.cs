using System;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();

        Console.WriteLine("Enter a list of numbers, type 0 when finished");
        int numberInList = 1;

        while (numberInList != 0)
        {
            Console.WriteLine("Enter number: ");
            numberInList = int.Parse(Console.ReadLine());
            if (numberInList == 0)
            {
                Console.WriteLine("\n");
                break;
            }
            numbers.Add(numberInList);
        }

        numbers.Sort();

        int sum = 0;
        float average;
        int smallestPositive = int.MaxValue;
        int largestNumber = 0;

        foreach (int number in numbers)
        {
            if (number > 0 && number < smallestPositive)
            {
                smallestPositive = number;
            }

            if (number > largestNumber)
            {
                largestNumber = number;
            }

            sum += number;
        }

        average = (float)sum / (float)numbers.Count;

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {largestNumber}");
        Console.WriteLine($"The smallest positive number is: {smallestPositive}");
        Console.WriteLine("The sorted list is: ");

        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }

    }
}