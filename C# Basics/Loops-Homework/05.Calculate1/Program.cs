using System;

class Calculate1
{
    static void Main()
    {
        Console.WriteLine("Enter value of n:");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter value of x:");
        int x = int.Parse(Console.ReadLine());
        double sum = 1;
        double fact = 1;
        double power = 1;
        for (int i = 1; i <= n; i++)
        {
            fact = fact * i;
            power = power * x;
            sum = sum + fact / power;
        }
        Console.WriteLine("S = {0:F5}", sum);
    }
}