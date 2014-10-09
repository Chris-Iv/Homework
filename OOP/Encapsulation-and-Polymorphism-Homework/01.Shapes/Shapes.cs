using System;

namespace _01.Shapes
{
    class Shapes
    {
        static void Main()
        {
            Circle circle = new Circle(15);
            Triangle triangle = new Triangle(25, 10);
            Rectangle rectangle = new Rectangle(30, 15);

            IShape[] shapes = new IShape[3]
            {
                circle,
                triangle,
                rectangle
            };

            foreach (var shape in shapes)
            {
                Console.WriteLine(shape.CalculateArea());
            }
        }
    }
}
