using System;

class BinaryToDecimalNumber
{
    static void Main()
    {
        Console.WriteLine("Enter a binary number:");
        string entry = Console.ReadLine();
        long result = 0;
        for (int i = 0; i < entry.Length; i++)
        {
            if (entry[i] == '0')
            {
                result *= 2;
            }
            else
            {
                result = (result * 2) + 1;
            }
        }
        Console.WriteLine(result);
    }
}