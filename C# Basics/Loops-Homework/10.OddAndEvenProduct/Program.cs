using System;

class OddAndEvenProduct
{
    static void Main()
    {
        Console.WriteLine("Enter some integers separated by a space:");
        string n = Console.ReadLine();
        string[] numbers = n.Split(' ');
        int even = 1;
        int odd = 1;
        for (int i = 0; i < numbers.Length; i++)
        {
            int number = int.Parse(numbers[i]);
            if (i % 2 == 0)
            {
                even *= number;
            }
            else
            {
                odd *= number;
            }
        }
        if (even == odd)
        {
            Console.WriteLine("Yes");
            Console.WriteLine("Product: "+ even);
        }
        else
        {
            Console.WriteLine("No");
            Console.WriteLine("Even product: "+ even);
            Console.WriteLine("Odd product: "+ odd);
        }
    }
}