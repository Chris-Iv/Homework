using System;
class DivideBy7And5
{
    static void Main()
    {
        Console.WriteLine("Enter a number:");
        int number = int.Parse(Console.ReadLine());
        int a = 7;
        int b = 5;
        int c = a * b;
        if (number % c == 0)
        {
            Console.WriteLine("The number can be devided by 7 and 5");
        }
        else
        {
            Console.WriteLine("The number cannot be devided by 7 and 5");
        }
    }
}