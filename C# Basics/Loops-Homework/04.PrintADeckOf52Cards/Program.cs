using System;

class PrintADeckOf52Cards
{
    static void Main()
    {
        char a = '♠';
        char b = '♥';
        char c = '♦';
        char d = '♣';
        for (int i = 2; i < 15; i++)
        {
            if (i > 1 && i < 11)
            {
                Console.WriteLine(" " + a + i + " " + b + i + " " + c + i + " " + d + i);
            }
            else 
            {
                switch (i)
                {
                    case 11: Console.WriteLine(" " + a + "J" + " " + b + "J" + " " + c + "J" + " " + d + "J");
                        break;
                    case 12: Console.WriteLine(" " + a + "Q" + " " + b + "Q" + " " + c + "Q" + " " + d + "Q");
                        break;
                    case 13: Console.WriteLine(" " + a + "K" + " " + b + "K" + " " + c + "K" + " " + d + "K");
                        break;
                    case 14: Console.WriteLine(" " + a + "A" + " " + b + "A" + " " + c + "A" + " " + d + "A");
                        break;
                }
            }
        }
    }
}