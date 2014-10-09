using System;

class BonusScore
{
    static void Main()
    {
        Console.WriteLine("Enter a score from 1 to 9:");
        int score = int.Parse(Console.ReadLine());
        switch (score)
        {
            case 1:
            case 2:
            case 3:
                score *= 10;
                Console.WriteLine(score);
                break;
            case 4:
            case 5:
            case 6:
                score *= 100;
                Console.WriteLine(score);
                break;
            case 7:
            case 8:
            case 9:
                score *= 1000;
                Console.WriteLine(score);
                break;
            default:
                Console.WriteLine("Invalid entry!");
                break;
        }
    }
}