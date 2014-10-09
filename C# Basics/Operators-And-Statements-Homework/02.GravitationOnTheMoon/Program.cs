using System;
class GravitationOnTheMoon
{
    static void Main()
    {
        Console.WriteLine("Enter human weight:");
        double earthWeight = double.Parse(Console.ReadLine());
        double moonWeight = earthWeight * 0.17;
        Console.WriteLine("Human weight on the moon = {0}", moonWeight);
    }
}