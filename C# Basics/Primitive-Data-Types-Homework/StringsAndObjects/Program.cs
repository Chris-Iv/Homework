using System;
class StringsAndObjects
{
    static void Main()
    {
        string myString = "Hello";
        string newString = "World";
        object bothStrings = myString + " " + newString;
        Console.WriteLine(bothStrings);
    }
}