using System;

class DecimalToHexademicalNumber
{
    static void Main()
    {
        Console.WriteLine("Enter a decimal number:");
        long entry = long.Parse(Console.ReadLine());
        string result = string.Empty;
        long rest;
        char number;
        while (entry > 0)
        {
            rest = entry % 16;
            switch (rest)
            {
                case 10: number = 'A';
                    break;
                case 11: number = 'B';
                    break;
                case 12: number = 'C';
                    break;
                case 13: number = 'D';
                    break;
                case 14: number = 'E';
                    break;
                case 15: number = 'F';
                    break;
                default: long temp = entry % 16 + 48;
                    number = (char)temp;
                    break;
            }
            result = number + result;
            entry /= 16;
        }
        Console.WriteLine(result);
    }
}