using System;

namespace BankOfKurtovoKonare
{
    public abstract class Account : IAccount
    {
        public Customer Customer { get; set; }
        public decimal Balance { get; set; }
        public decimal Interest { get; set; }

        public Account(Customer customer, decimal balance, decimal interest)
        {
            this.Customer = customer;
            this.Balance = balance;
            this.Interest = Interest;
        }

        public void Deposit(decimal money)
        {
            this.Balance += money;
        }

        public abstract decimal CalculateInterest(int months);
    }
}
