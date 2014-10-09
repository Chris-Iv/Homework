using System;

class Calculate3
{
    static void Main()
    {
        Console.Write("N = ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("K = ");
        int k = int.Parse(Console.ReadLine());
        double nFact = 1;
        double kFact = 1;
        double nKFact = 1;
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
            }
            for (int q = 1; q <= (n - k); q++)
            {
                nKFact = nKFact * q;
            }
            sum = nFact / (kFact * nKFact);
            Console.WriteLine("Result: "+ sum);
        }
        else
        {
            Console.WriteLine("Invalid entry!");
        }
    }
}