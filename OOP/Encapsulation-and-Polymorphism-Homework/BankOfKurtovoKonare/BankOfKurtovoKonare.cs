using System;

namespace BankOfKurtovoKonare
{
    class BankOfKurtovoKonare
    {
        static void Main()
        {
            Deposit deposit = new Deposit(Customer.Individual, 500m, 5.5m);
            Console.WriteLine(deposit.Balance);

            deposit.Deposit(2000m);
            Console.WriteLine(deposit.Balance);

            deposit.Withdraw(300m);
            Console.WriteLine(deposit.Balance);

            
            Console.WriteLine(deposit.CalculateInterest(24));
        }
    }
}
