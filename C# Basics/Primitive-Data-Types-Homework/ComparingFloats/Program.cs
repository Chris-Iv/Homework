using System;
class ComparingFloats
{
    static void Main()
    {
        float firstA = 5.3f;
        float firstB = 6.01f;
        double secondA = 5.00000001;
        double secondB = 5.00000003;
        double thirdA = -0.0000007;
        double thirdB = 0.00000007;
        double fourthA = -4.999999;
        double fourthB = -4.999998;
        bool compare1 = (Math.Abs(firstA - firstB) < 0.000001);
        if (compare1)
        {
            Console.WriteLine("5.3 = 6.01 True");
        }
        else
        {
            Console.WriteLine("5.3 = 6.01 False");
        }
        bool compare2 = (Math.Abs(secondA - secondB) < 0.000001);
        if (compare2)
        {
            Console.WriteLine("5.00000001 = 5.00000003 True");
        }
        else
        {
            Console.WriteLine("5.00000001 = 5.0000000 False");
        }
        bool compare3 = (Math.Abs(thirdA - thirdB) < 0.000001);
        if (compare3)
        {
            Console.WriteLine("-0.0000007 = 0.00000007 True");
        }
        else
        {
            Console.WriteLine("-0.0000007 = 0.00000007 False");
        }
        bool compare4 = (Math.Abs(fourthA - fourthB) < 0.000001);
        if (compare4)
        {
            Console.WriteLine("-4.999999 = -4.999998 True");
        }
        else
        {
            Console.WriteLine("-4.999999 = -4.999998 False");
        }
    }
}