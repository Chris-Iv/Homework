using System;

namespace BankOfKurtovoKonare
{
    public class Mortgage : Account
    {

        public Mortgage(Customer customer, decimal balance, decimal interest)
            : base(customer, balance, interest)
        {
        }

        public override decimal CalculateInterest(int months)
        {
            months -= 6;
            decimal result = this.Balance * (1 + this.Interest * months);
            return result;
        }
    }
}
