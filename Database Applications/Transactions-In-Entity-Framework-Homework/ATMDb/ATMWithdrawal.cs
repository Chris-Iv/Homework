namespace ATMDb
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Data.Entity;

    public class ATMWithdrawal
    {
        public static void Main(string[] args)
        {
            var context = new ATMEntities();

            var account = context.CardAccounts.FirstOrDefault();
            var pin = account.CardPIN;
            var cardNumber = account.CardNumber;
            var requestedAmount = 1000;
                     
            WithdrawMoney(account, pin, cardNumber, requestedAmount);
            context.SaveChanges();
        }

        public static void WithdrawMoney(CardAccount account, string pin, string cardNumber, decimal requestedAmount)
        {
            var context = new ATMEntities();
            var transaction = context.Database.BeginTransaction();

            if (!CardNumberAndPinAreValid(account, pin, cardNumber))
            {
                transaction.Rollback();
                throw new InvalidOperationException("Card PIN and number are invalid!");
            }

            if (!CardAmountIsEnough(account, requestedAmount))
            {
                transaction.Rollback();
                throw new InvalidOperationException("Not enough amount!");
            }

            account.CardCash -= requestedAmount;
            LogTransaction(cardNumber, requestedAmount);
            transaction.Commit();
            Console.WriteLine("Withdrawal complete.");
        }

        public static void LogTransaction(string cardNumber, decimal amount)
        {
            var context = new ATMEntities();
            context.TransactionHistories.Add(new TransactionHistory()
                {
                    CardNumber = cardNumber,
                    TransactionDate = DateTime.Now,
                    Amount = amount
                });
            context.SaveChanges();
        }

        public static bool CardNumberAndPinAreValid(CardAccount account, string pin, string number)
        {
            var cardPin = account.CardPIN;
            var cardNumber = account.CardNumber;
            if (pin == cardPin && number == cardNumber)
	        {
                return true;
	        }

            return false;
        }

        public static bool CardAmountIsEnough(CardAccount account, decimal requestedAmount)
        {
            var cardAmount = account.CardCash;
            if (cardAmount < requestedAmount)
            {
                return false;
            }

            return true;
        }
    }
}
