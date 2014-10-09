using System;
class PointInACircle
{
    static void Main()
    {
        double h = 1;
        double k = 1;
        double r = 1.5;
        Console.WriteLine("Enter value of x:");
        double x = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter value of y:");
        double y = double.Parse(Console.ReadLine());
        if (((x - h) * (x - h) + (y - k) * (y - k)) <= (r * r))
        {
            Console.WriteLine("The point is inside the circle");
        }
        else
        {
            Console.WriteLine("The point is outside the circle");
        }
    }
}