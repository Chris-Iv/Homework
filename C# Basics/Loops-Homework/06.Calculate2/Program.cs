using System;

class Calculate2
{
    static void Main()
    {
        Console.WriteLine("Enter value of n:");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter value of k:");
        int k = int.Parse(Console.ReadLine());
        double nFact = 1;
        double kFact = 1;
        double sum = 1;
        if (1 < k && k < n && n < 100)
        {
            for (int i = 1; i <= n; i++)
            {
                nFact = nFact * i;
                if (i <= k)
                {
                    kFact = kFact * i;
                }
                sum = nFact / kFact;
            }
            Console.WriteLine("Sum = "+ sum);
        }
        else
        {
            Console.WriteLine("Invalid entry!");
        }
    }
}