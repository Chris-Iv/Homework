using System;
class BitwiseExtractBit3
{
    static void Main()
    {
        Console.WriteLine("Enter an integer:");
        int number = int.Parse(Console.ReadLine());
        Console.WriteLine("Binary representation of the number:");
        Console.WriteLine(Convert.ToString(number, 2).PadLeft(16, '0'));
        int newNumber = number >> 3;
        int bit3 = newNumber & 1;
        Console.WriteLine("The value of bit #3 is:");
        Console.WriteLine(Convert.ToString(bit3, 2));
    }
}