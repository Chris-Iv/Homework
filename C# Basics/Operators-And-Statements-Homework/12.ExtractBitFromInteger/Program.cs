using System;
class ExtractBitFromInteger
{
    static void Main()
    {
        Console.WriteLine("Enter an integer:");
        int number = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter number of bit:");
        int p = int.Parse(Console.ReadLine());
        Console.WriteLine("The number in binary code is:");
        Console.WriteLine(Convert.ToString(number, 2).PadLeft(16, '0'));
        int newNumber = number >> p;
        int bit = newNumber & 1;
        Console.WriteLine("The value of the bit in {0} position is:", p);
        Console.WriteLine(Convert.ToString(bit, 2));
    }
}