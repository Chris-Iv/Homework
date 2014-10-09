using System;
class PrimeNumberCheck
{
    static void Main()
    {
        Console.WriteLine("Enter an integer:");
        int number = int.Parse(Console.ReadLine());
        if (number % 2 == 0 || number % 3 == 0 || number % 5 == 0 || number % 7 == 0)
        {
            Console.WriteLine("The number isn't prime");
        }
        else
        {
            Console.WriteLine("The number is prime");
        }
    }
}