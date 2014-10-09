using System;

class SumOf5Numbers
{
    static void Main()
    {
        Console.WriteLine("Enter 5 numbers:");
        string entry = Console.ReadLine();
        string[] numbers = entry.Split(' ');
        double number1 = double.Parse(numbers[0]);
        double number2 = double.Parse(numbers[1]);
        double number3 = double.Parse(numbers[2]);
        double number4 = double.Parse(numbers[3]);
        double number5 = double.Parse(numbers[4]);
        double sum = number1 + number2 + number3 + number4 + number5;
        Console.WriteLine("The sum of the 5 numbers is: "+ sum);
    }
}