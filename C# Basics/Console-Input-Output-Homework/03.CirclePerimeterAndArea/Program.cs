using System;

class CirclePerimeterAndArea
{
    static void Main()
    {
        Console.WriteLine("Enter circle radius:");
        double r = double.Parse(Console.ReadLine());
        double d = r * 2;
        double perimeter = d * Math.PI;
        double area = (r * r) * Math.PI;
        Console.WriteLine("Circle perimeter: {0:F2}", perimeter);
        Console.WriteLine("Circle area: {0:F2}", area);
    }
}