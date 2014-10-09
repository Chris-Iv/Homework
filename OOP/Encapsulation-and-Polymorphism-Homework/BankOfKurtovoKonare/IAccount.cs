using System;

namespace BankOfKurtovoKonare
{
    public interface IAccount
    {
        void Deposit(decimal money);

        decimal CalculateInterest(int months);
    }
}
