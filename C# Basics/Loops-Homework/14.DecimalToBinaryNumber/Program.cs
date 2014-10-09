using System;

class DecimalToBinary
{
    static void Main()
    {
        Console.WriteLine("Enter an integer:");
        long entry = long.Parse(Console.ReadLine());
        string result = string.Empty;
        while (entry > 0)
        {
            long rest = entry % 2;
            entry /= 2;
            result = rest.ToString() + result;
        }
        Console.WriteLine(result);
    }
}