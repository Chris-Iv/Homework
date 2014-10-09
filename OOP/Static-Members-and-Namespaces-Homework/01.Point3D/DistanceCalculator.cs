using System;

namespace _01.Point3D
{
    public static class DistanceCalculator
    {
        public static double CalculateDistance(Point3D firstPoint, Point3D secondPoint)
        {
            double distance = 0;

            distance = Math.Sqrt((secondPoint.X - firstPoint.X) * (secondPoint.X - firstPoint.X) 
                + (secondPoint.Y - firstPoint.Y) * (secondPoint.Y - firstPoint.Y) 
                + (secondPoint.Z - firstPoint.Z) * (secondPoint.Z - firstPoint.Z));

            return distance;
        }
    }
}
