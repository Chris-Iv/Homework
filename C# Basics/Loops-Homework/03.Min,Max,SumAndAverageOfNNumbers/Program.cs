using System;

class MinMaxSumAndAverageOfNNumbers
{
    static void Main()
    {
        Console.WriteLine("Enter n:");
        int n = int.Parse(Console.ReadLine());
        double sum = 0;
        int max = int.MinValue;
        int min = int.MaxValue;
        for (int i = 0; i < n; i++)
        {
            int numbers = int.Parse(Console.ReadLine());
            sum += numbers;
            if (max < numbers)
            {
                max = numbers;
            }
            if (min > numbers)
            {
                min = numbers;
            }
        }
        Console.WriteLine("Sum = "+ sum);
        Console.WriteLine("Max = "+ max);
        Console.WriteLine("Min = "+ min);
        Console.WriteLine("Average = {0:F2}", sum / n);
    }
}