using System;

namespace _01.InterestCalculator
{
    public delegate decimal CalculateInterest(decimal sum, decimal interest, int years);

    public class InterestCalculator
    {
        public decimal sum { get; set; }
        public decimal interest { get; set; }
        public int years { get; set; }
        public CalculateInterest calc { get; set; }

        public InterestCalculator(decimal sum, decimal interest, int years, CalculateInterest calc)
        {
            this.sum = sum;
            this.interest = interest;
            this.years = years;
            this.calc = calc;
        }

        public override string ToString()
        {
            return string.Format("{0:F4}", this.calc(this.sum, this.interest, this.years));
        }
    }
}