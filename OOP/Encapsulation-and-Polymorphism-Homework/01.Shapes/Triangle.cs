using System;

namespace _01.Shapes
{
    public class Triangle : BasicShape
    {
        public Triangle(double width, double height)
            : base(width, height)
        {
        }

        public override double CalculateArea()
        {
            double area = this.Width * this.Height * 0.5;
            return area;
        }

        public override double CalculatePerimiter()
        {
            double c = Math.Sqrt((this.Width * this.Width) + (this.Height * this.Height));
            double perimeter = this.Width + this.Height + c;
            return perimeter;
        }
    }
}
