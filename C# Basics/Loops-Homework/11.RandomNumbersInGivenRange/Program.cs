using System;

class RandomNumbersInGivenRange
{
    static void Main()
    {
        Console.WriteLine("Enter value of n:");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter min value:");
        int min = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter max value:");
        int max = int.Parse(Console.ReadLine());
        if (min <= max)
        {
            Random rnd = new Random();
            for (int i = 0; i < n; i++)
            {
                int next = rnd.Next(min, max + 1);
                Console.Write(next + " ");
            }
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine("Min cannot be larger than max!");
        }
    }
}