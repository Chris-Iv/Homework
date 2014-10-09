using System;
class BankAccountData
{
    static void Main()
    {
        string firstName = "Petko";
        string middleName = "Dimitrov";
        string lastName = "Ivanov";
        int balance = 50000;
        string bankName = "First Bulgarian Bank";
        string IBAN = "BG80BNBG96611020345678";
        string creditCardNumber1 = "378282246310005";
        string creditCardNumber2 = "371449635398431";
        string creditCardNumber3 = "378734493671000";
        string holderName = firstName + " " + middleName + " " + lastName;
        Console.WriteLine("{0}\nAccount Holder: {1}\nIBAN: {2}\nBalance: {3}\nCredit card number 1: {4}\nCredit card number 2: {5}\nCredit card number 3: {6}", bankName, holderName, IBAN, balance, creditCardNumber1, creditCardNumber2, creditCardNumber3);
    }
}