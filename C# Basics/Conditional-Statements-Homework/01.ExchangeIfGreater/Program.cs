using System;

class ExchangeIfGreater
{
    static void Main()
    {
        Console.WriteLine("Enter value of a:");
        int a = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter value of b:");
        int b = int.Parse(Console.ReadLine());
        if (a > b)
        {
            int c = a;
            a = b;
            b = c;
            Console.WriteLine("a = {0}, b = {1}", a, b);
        }
        else
        {
            Console.WriteLine("a = {0}, b = {1}", a, b);
        }
    }
}