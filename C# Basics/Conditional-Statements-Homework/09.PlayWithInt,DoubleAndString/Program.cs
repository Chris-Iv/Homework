using System;

class PlayWithIntDoubleAndString
{
    static void Main()
    {
        Console.WriteLine("Please choose a type:");
        Console.WriteLine("1 --> int");
        Console.WriteLine("2 --> double");
        Console.WriteLine("3 --> string");
        int entry = int.Parse(Console.ReadLine());
        if (entry == 1)
        {
            Console.WriteLine("Please enter an integer:");
            int a = int.Parse(Console.ReadLine());
            a = a + 1;
            Console.WriteLine("Result: " + a);
        }
        else if (entry == 2)
        {
            Console.WriteLine("Please enter a double:");
            double b = double.Parse(Console.ReadLine());
            b = b + 1;
            Console.WriteLine("Result: " + b);
        }
        else
        {
            Console.WriteLine("Please enter a string:");
            string c = Console.ReadLine();
            Console.WriteLine("Result:");
            Console.WriteLine(c + "*");
        }
    }
}