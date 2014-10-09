using System;

class TheBiggestOf5Numbers
{
    static void Main()
    {
        Console.WriteLine("Enter first number:");
        double a = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter second number:");
        double b = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter third number:");
        double c = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter fourth number:");
        double d = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter fifth number:");
        double e = double.Parse(Console.ReadLine());
        Console.WriteLine("The biggest number is:");
        if (a > b && a > c && a > d && a > e)
        {
            Console.WriteLine(a);
        }
        else if (b > a && b > c && b > d && b > e)
        {
            Console.WriteLine(b);
        }
        else if (c > a && c > b && c > d && c > e)
        {
            Console.WriteLine(c);
        }
        else if (d > a && d > b && d > c && d > e)
        {
            Console.WriteLine(d);
        }
        else
        {
            Console.WriteLine(e);
        }
    }
}