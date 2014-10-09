using System;
class Trapezoids
{
    static void Main()
    {
        Console.WriteLine("Enter value of a:");
        double a = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter value of b:");
        double b = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter value of h:");
        double h = double.Parse(Console.ReadLine());
        double area = ((a + b) / 2) * h;
        Console.WriteLine("The area of the trapezoid is: {0}", area);
    }
}