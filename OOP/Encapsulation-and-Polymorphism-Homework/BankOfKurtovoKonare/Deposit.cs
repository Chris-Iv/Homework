using System;

namespace BankOfKurtovoKonare
{
    public class Deposit : Account
    {
        public Deposit(Customer customer, decimal balance, decimal interest)
            : base(customer, balance, interest)
        {
        }

        public override decimal CalculateInterest(int months)
        {
            if (0 < this.Balance && this.Balance < 1000)
            {
                return 0; 
            }

            decimal result = this.Balance * (1 + this.Interest * months);
            return result;
        }

        public void Withdraw(decimal money)
        {
            this.Balance -= money;
        }
    }
}
