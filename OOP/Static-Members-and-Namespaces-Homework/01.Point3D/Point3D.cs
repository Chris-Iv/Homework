using System;

namespace _01.Point3D
{
    public class Point3D
    {
        private double x;
        private double y;
        private double z;

        public static readonly Point3D StartingPoint = new Point3D(0, 0, 0);

        public double X
        {
            get { return this.x; }
            set { this.x = value; }
        }

        public double Y
        {
            get { return this.y; }
            set { this.y = value; }
        }

        public double Z
        {
            get { return this.z; }
            set { this.z = value; }
        }

        public Point3D(double x, double y, double z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public override string ToString()
        {
            return String.Format("Point3D(X={0}, Y={1}, Z={2})", this.X, this.Y, this.Z);
        }
    }
}
