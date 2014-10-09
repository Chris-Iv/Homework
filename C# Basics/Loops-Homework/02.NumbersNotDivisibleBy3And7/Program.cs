using System;

class NumbersNotDivisibleBy3And7
{
    static void Main()
    {
        Console.WriteLine("Enter value of n:");
        int n = int.Parse(Console.ReadLine());
        int i = 1;
        while (i <= n)
        {
            if ((i % 3 == 0) && (i % 7 == 0))
            {
                Console.Write("{0} ", i);
            }
            i++;
        }
        Console.WriteLine();
    }
}