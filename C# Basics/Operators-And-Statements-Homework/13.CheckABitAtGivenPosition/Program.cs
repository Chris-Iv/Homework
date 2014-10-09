using System;
class CheckABitAtGivenPosition
{
    static void Main()
    {
        Console.WriteLine("Enter a number:");
        int number = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter a bit position:");
        int p = int.Parse(Console.ReadLine());
        Console.WriteLine("The number in binary code is:");
        Console.WriteLine(Convert.ToString(number, 2).PadLeft(16, '0'));
        int newNumber = number >> p;
        int bit = newNumber & 1;
        if (bit == 1)
        {
            Console.WriteLine("True");
        }
        else
        {
            Console.WriteLine("False");
        }
    }
}