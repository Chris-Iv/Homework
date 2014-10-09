using System;
class Rectangles
{
    static void Main()
    {
        Console.WriteLine("Enter rectangle width");
        double width = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter rectangle height");
        double height = double.Parse(Console.ReadLine());
        double area = width * height;
        double perimeter = 2 * (area);
        Console.WriteLine("Rectangle area = {0}", area);
        Console.WriteLine("Rectange perimeter = {0}", perimeter);
    }
}