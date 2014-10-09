using System;

class FibonacciNumbers
{
    static void Main()
    {
        Console.WriteLine("Enter value of n:");
        int n = int.Parse(Console.ReadLine());
        int a = 0;
        int b = 1;
        if (n <= 1)
        {
            Console.WriteLine("0");
        }
        else
        {
            Console.Write(0 + ", " + 1 + ", ");
            for (int i = 0; i < n - 2; i++)
            {
                int fNum = a + b;
                Console.Write(fNum + ", ");
                a = b;
                b = fNum;
            }
        }
    }
}