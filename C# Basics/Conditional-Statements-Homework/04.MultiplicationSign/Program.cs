using System;

class MultiplicationSign
{
    static void Main()
    {
        Console.WriteLine("Enter value of a:");
        double a = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter value of b:");
        double b = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter value of c:");
        double c = double.Parse(Console.ReadLine());
        Console.WriteLine("Result:");
        if (a == 0 || b == 0 || c == 0)
        {
            Console.WriteLine(0);
        }
        else if (a > 0)
        {
            if (b > 0 && c > 0)
            {
                Console.WriteLine("+");
            }
            else if (b < 0 && c < 0)
            {
                Console.WriteLine("+");
            }
            else
            {
                Console.WriteLine("-");
            }
        }
        else if (a < 0)
        {
            if (b > 0 && c > 0)
            {
                Console.WriteLine("-");
            }
            else if (b < 0 && c < 0)
            {
                Console.WriteLine("-");
            }
            else
            {
                Console.WriteLine("+");
            }
        }
    }
}