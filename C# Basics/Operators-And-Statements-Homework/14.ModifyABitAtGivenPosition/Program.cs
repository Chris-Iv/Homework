using System;
class ModifyABitAtGivenPosition
{
    static void Main()
    {
        Console.WriteLine("Enter an integer:");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter a bit position:");
        int p = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter bit value(0 or 1):");
        int v = int.Parse(Console.ReadLine());
        Console.WriteLine("The binary representation of the number is:");
        Console.WriteLine(Convert.ToString(n, 2).PadLeft(16, '0'));
        int mask = v << p;
        int result = n | mask;
        if (v == 0)
        {
            mask = ~(1 << p);
            result = n & mask;
        }
        Console.WriteLine("Binary result:");
        Console.WriteLine(Convert.ToString(result, 2).PadLeft(16, '0'));
        Console.WriteLine("Result: {0}", result);
    }
}