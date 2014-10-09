using System;
class PointInsideACircleAndOtsideOfARectangle
{
    static void Main()
    {
        Console.WriteLine("Enter cordinate x of the point:");
        double x = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter cordinate y of the point:");
        double y = double.Parse(Console.ReadLine());
        double r = 1.5;
        bool isInCircle = (x - 1) * (x - 1) + (y - 1) * (y - 1) <= (r * r);
        if (isInCircle && y > 1)
        {
            Console.WriteLine("The point is inside the circle and outside of the rectangle");
        }
        else
        {
            Console.WriteLine("The point isn't inside the circle and outside of the rectangle");
        }
    }
}