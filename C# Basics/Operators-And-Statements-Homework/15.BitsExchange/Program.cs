using System;
class BitsExchange
{
    static void Main()
    {
        Console.WriteLine("Enter an unsigned integer:");
        uint number = uint.Parse(Console.ReadLine());
        Console.WriteLine("Number in binary code:");
        Console.WriteLine(Convert.ToString(number, 2).PadLeft(32, '0'));
        uint mask = 7;
        uint bits = ((mask << 3) & number) >> 3;
        uint otherBits = ((mask << 24) & number) >> 24;
        number = ~(mask << 24) & number;
        number = ~(mask << 3) & number;
        number = (bits << 24) | number;
        number = (otherBits << 3) | number;
        Console.WriteLine("The binary result is:");
        Console.WriteLine(Convert.ToString(number, 2).PadLeft(32, '0'));
        Console.WriteLine("Result:");
        Console.WriteLine(number);
    }
}