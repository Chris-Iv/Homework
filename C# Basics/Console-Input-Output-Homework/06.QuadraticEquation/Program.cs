using System;

class QuadraticEquation
{
    static void Main()
    {
        Console.WriteLine("Enter value of a:");
        double a = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter value of b:");
        double b = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter value of c:");
        double c = double.Parse(Console.ReadLine());
        double d = (b * b) - (4 * a * c);
        if (d > 0)
        {
            double x1 = (-b - Math.Sqrt(d)) / (2 * a);
            double x2 = (-b + Math.Sqrt(d)) / (2 * a);
            Console.WriteLine("x1 = {0} x2 = {1}", x1, x2);
        }
        else if (d < 0)
        {
            Console.WriteLine("The determinant is less than zero => there is no solution");
        }
        else
        {
            double x = -b / (2 * a);
            Console.WriteLine("The determinant is zero => x1,2 = " + x);
        }
    }
}