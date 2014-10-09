using System;
class NullValuesArithmetic
{
    static void Main()
    {
        int? a = null;
        double? b = null;
        Console.WriteLine("Value of a = " + a);
        Console.WriteLine("Value of b = " + b);
        a = a + 5;
        b = b + null;
        Console.WriteLine("New value of a = " + a);
        Console.WriteLine("New value of b = " + b);
    }
}