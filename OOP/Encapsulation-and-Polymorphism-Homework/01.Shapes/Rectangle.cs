using System;

namespace _01.Shapes
{
    public class Rectangle : BasicShape
    {
        public Rectangle(double widht, double height)
            : base(widht, height)
        {
        }

        public override double CalculateArea()
        {
            double area = this.Width * this.Height;
            return area;
        }

        public override double CalculatePerimiter()
        {
            double perimeter = 2 * (this.Width + this.Height);
            return perimeter;
        }
    }
}
