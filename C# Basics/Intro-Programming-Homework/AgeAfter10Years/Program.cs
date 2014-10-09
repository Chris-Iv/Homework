using System;
class AgeAfter10Years
{
    static void Main()
    {
        Console.WriteLine("Enter year of birth:");
        string year = Console.ReadLine();
        int birthYear = int.Parse(year);
        int currentYear = DateTime.Now.Year;
        int age = currentYear - birthYear;
        int futureAge = age + 10;
        Console.WriteLine("Your age is:" + age);
        Console.WriteLine("After 10 years your age will be:" + futureAge);
    }
}