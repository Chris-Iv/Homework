using System;

class SumOf3Integers
{
    static void Main()
    {
        Console.WriteLine("Enter first integer:");
        int a = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter second integer:");
        int b = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter third integer:");
        int c = int.Parse(Console.ReadLine());
        int sum = a + b + c;
        Console.WriteLine("Their sum is: " + sum);
    }
}