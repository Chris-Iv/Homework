using System;
class ThirdDigitIs7
{
    static void Main()
    {
        Console.WriteLine("Enter an integer");
        int number = int.Parse(Console.ReadLine());
        if ((number / 100) % 10 == 7)
        {
            Console.WriteLine("The third digit is 7");
        }
        else
        {
            Console.WriteLine("The third digit is not 7");
        }
    }
}