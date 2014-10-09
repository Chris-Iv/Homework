using System;

class RandomizeTheNumbers
{
    static void Main()
    {
        Console.WriteLine("Enter the value of n:");
        int n = int.Parse(Console.ReadLine());
        int[] array = new int[n];
        for (int i = 0; i < n; i++)
        {
            array[i] = i + 1;
        }
        Random rnd = new Random();
        for (int i = 0; i < n; i++)
        {
            int rndNum = rnd.Next(0, n);
            int temp = array[rndNum];
            array[rndNum] = array[0];
            array[0] = temp;
        }
        Console.WriteLine(String.Join(" ", array));
    }
}