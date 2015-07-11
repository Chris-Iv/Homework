namespace SumAndAverage
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class SumAndAverage
    {
        public static void Main()
        {
            List<int> numbers = new List<int>();
            string input = Console.ReadLine();
            string[] numbersArr = input.Split(' ');

            for (int i = 0; i < numbersArr.Length; i++)
            {
                int num = int.Parse(numbersArr[i]);
                numbers.Add(num);
            }

            int sum = numbers.Sum();
            double average = numbers.Average();
            Console.WriteLine("Sum=" + sum + "; Average=" + average);
        }
    }
}