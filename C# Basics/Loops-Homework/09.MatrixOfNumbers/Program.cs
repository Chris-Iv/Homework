using System;

class MatrixOfNumbers
{
    static void Main()
    {
        Console.WriteLine("Enter a positive integer:");
        int n = int.Parse(Console.ReadLine());
        if (1 <= n && n <= 20)
        {
            for (int i = 1; i <= n; i++)
            {
                for (int q = i; q <= (2 * n - 1); q++)
                {
                    if (q < n + i)
                    {
                        Console.Write(q + " ");
                    }
                }
                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine("Invalid entry!");
        }
    }
}