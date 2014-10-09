using System;

namespace _01.Point3D
{
    class Program
    {
        static void Main(string[] args)
        {
            Point3D firstPoint = new Point3D(5, 3, 2);
            Point3D secondPoint = new Point3D(6, 10, 7);

            Console.WriteLine(Point3D.StartingPoint);
            Console.WriteLine(firstPoint);
            Console.WriteLine(secondPoint);
            Console.WriteLine(DistanceCalculator.CalculateDistance(firstPoint, secondPoint));
        }
    }
}
