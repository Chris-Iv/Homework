using System;

namespace _02.FractionCalculator
{
    public struct Fraction
    {
        private long numerator;
        private long denominator;

        public Fraction(long numerator, long denominator) : this()
        {
            this.Numerator = numerator;
            this.Denominator = denominator;
        }

        public long Numerator
        {
            get { return this.numerator; }
            set { this.numerator = value; }
        }

        public long Denominator
        {
            get { return this.denominator; }
            set
            {
                if (value == 0) { throw new ArgumentOutOfRangeException("Cannot divide by zero!"); }
                this.denominator = value;
            }
        }

        public static Fraction operator +(Fraction f1, Fraction f2)
        {
            long numerator = f1.numerator * f2.denominator + f2.numerator * f1.denominator;
            long denominator = f1.denominator * f2.denominator;
            return new Fraction(numerator, denominator);
        }

        public static Fraction operator -(Fraction f1, Fraction f2)
        {
            long numerator = f1.numerator * f2.denominator - f2.numerator * f1.denominator;
            long denominator = f1.denominator * f2.denominator;
            return new Fraction(numerator, denominator);
        }

        public override string ToString()
        {
            return ((decimal)numerator / denominator).ToString();
        }
    }
}
