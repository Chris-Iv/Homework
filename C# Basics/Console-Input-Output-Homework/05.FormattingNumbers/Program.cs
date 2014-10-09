using System;

class FormattingNumbers
{
    static void Main()
    {
        Console.WriteLine("Enter an integer:");
        int a = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter a floating-point number:");
        float b = float.Parse(Console.ReadLine());
        Console.WriteLine("Enter a floating-point number:");
        float c = float.Parse(Console.ReadLine());
        Console.Write("| ");
        Console.Write(Convert.ToString(a, 16).PadRight(10, ' '));
        Console.Write(" | ");
        Console.Write(Convert.ToString(a, 2).PadLeft(10, '0'));
        Console.Write(" | ");
        Console.Write("{0:F2}", (Convert.ToString(b).PadLeft(10, ' ')));
        Console.Write(" | ");
        Console.Write("{0:F3}", (Convert.ToString(c).PadRight(10, ' ')));
        Console.WriteLine(" |");
    }
}