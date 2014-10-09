using System;

class NumbersFrom1ToN
{
    static void Main()
    {
        Console.WriteLine("Enter value of n:");
        int n = int.Parse(Console.ReadLine());
        int i = 1;
        while (i <= n)
        {
            Console.Write("{0} ", i);
            i++;
        }
        Console.WriteLine();
    }
}