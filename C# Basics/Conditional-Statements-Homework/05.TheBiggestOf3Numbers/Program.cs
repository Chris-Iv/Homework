using System;

class TheBiggestOf3Numbers
{
    static void Main()
    {
        Console.WriteLine("Enter first number:");
        double a = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter second number:");
        double b = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter third number:");
        double c = double.Parse(Console.ReadLine());
        Console.WriteLine("The biggest number is:");
        if (a > b && a > c)
        {
            Console.WriteLine(a);
        }
        else if (b > a && b > c)
        {
            Console.WriteLine(b);
        }
        else
        {
            Console.WriteLine(c);
        }
    }
}