using System;

class SumOfnNumbers
{
    static void Main()
    {
        Console.WriteLine("Enter value of n:");
        int n = int.Parse(Console.ReadLine());
        double sum = 0;
        for (double i = 0; i < n; i++)
        {
            Console.WriteLine("Enter value of x:");
            sum = sum + double.Parse(Console.ReadLine());
        }
        Console.WriteLine("The sum is: "+ sum);
    }
}