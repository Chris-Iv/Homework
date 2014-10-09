using System;

class NumberComparer
{
    static void Main()
    {
        Console.WriteLine("Enter first number:");
        int a = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter second number:");
        int b = int.Parse(Console.ReadLine());
        int greater = Math.Max(a, b);
        Console.WriteLine("The greater number is: " + greater);
    }
}