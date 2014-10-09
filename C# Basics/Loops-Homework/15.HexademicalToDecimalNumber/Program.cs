using System;

class HexademicalToDecimalNumber
{
    static void Main()
    {
        Console.WriteLine("Enter a hex number:");
        string entry = Console.ReadLine();
        long result = 0;
        for (int i = 0; i < entry.Length; i++)
        {
            long number;
            long power = 1;
            switch (entry[i])
            {
                case 'A': number = 10;
                    break;
                case 'B': number = 11;
                    break;
                case 'C': number = 12;
                    break;
                case 'D': number = 13;
                    break;
                case 'E': number = 14;
                    break;
                case 'F': number = 15;
                    break;
                default: number = (long)entry[i] - 48;
                    break;
            }
            for (int q = entry.Length - 1; q > i; q--)
            {
                power *= 16;
            }
            result += number * power;
        }
        Console.WriteLine(result);
    }
}