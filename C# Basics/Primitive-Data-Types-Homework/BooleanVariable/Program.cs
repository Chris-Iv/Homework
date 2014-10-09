using System;
class BooleanVariable
{
    static void Main()
    {
        bool isFemale = false;
        string myGender = "I am a";
        string gender1 = "male";
        string gender2 = "female";
        if (isFemale)
        {
            Console.WriteLine(myGender + " " + gender2);
        }
        else
        {
            Console.WriteLine(myGender + " " + gender1);
        }
    }
}