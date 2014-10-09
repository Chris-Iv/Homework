using System;

namespace BankOfKurtovoKonare
{
    public class Loan : Account
    {
        public Loan(Customer customer, decimal balance, decimal interest)
            : base(customer, balance, interest)
        {
        }

        public override decimal CalculateInterest(int months)
        {
            if (this.Customer == Customer.Individual)
            {
                months -= 3;
            }
            else if (this.Customer == Customer.Company)
            {
                months -= 2;
            }

            decimal result = this.Balance * (1 + this.Interest * months);
            return result;
        }
    }
}
