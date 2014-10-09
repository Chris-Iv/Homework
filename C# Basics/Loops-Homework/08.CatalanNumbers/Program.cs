using System;
using System.Numerics;

class CatalanNumbers
{
    static void Main()
    {
        Console.WriteLine("Enter value of n:");
        int n = int.Parse(Console.ReadLine());
        BigInteger nFact = 1;
        BigInteger n2Fact = 1;
        BigInteger n1Fact = 1;
        BigInteger result = 1;
        if (1 < n && n < 100)
        {
            for (int i = 1; i <= n; i++)
            {
                nFact = nFact * i;
                n1Fact = n1Fact * (i + 1);
            }
            for (int q = 1; q <= 2 * n; q++)
            {
                n2Fact = n2Fact * q;
            }
            result = n2Fact / (n1Fact * nFact);
            Console.WriteLine("Result: "+ result);
        }
        else
        {
            Console.WriteLine("Invalid entry!");
        }
    }
}