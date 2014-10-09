using System;

class NumbersInIntervalDividableByGivenNumber
{
    static void Main()
    {
        Console.WriteLine("Enter start number:");
        int a = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter end number:");
        int b = int.Parse(Console.ReadLine());
        int p = 0;
        for (int i = a; i <= b; i++)
        {
            int divider = i % 5;
            if (divider == 0)
            {
                p = p + 1;
            }
        }
        Console.WriteLine("P numbers: "+ p);
    }
}