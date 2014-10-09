using System;
class FourDigitNumber
{
    static void Main()
    {
        Console.WriteLine("Enter an four-digit number");
        int number = int.Parse(Console.ReadLine());
        int a = (number / 1000) % 10;
        int b = (number / 100) % 10;
        int c = (number / 10) % 10;
        int d = number % 10;
        Console.WriteLine("The entered number is: {0}{1}{2}{3}", a, b, c, d);
        int sum = a + b + c + d;
        Console.WriteLine("The sum of the digits is: {0}", sum);
        Console.WriteLine("The number in reversed order is: {0}{1}{2}{3}", d, c, b, a);
        Console.WriteLine("The number with the last digit in front is: {0}{1}{2}{3}", d, a, b, c);
        Console.WriteLine("The number with exchanged digits is: {0}{1}{2}{3}", a, c, b, d);
    }
}