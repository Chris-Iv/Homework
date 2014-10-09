using System;

namespace _02.EnterNumbers
{
    class EnterNumbers
    {
        static void Main(string[] args)
        {
            int start = 1;
            int end = 100;
            int count = 0;

            while (count < 10)
            {
                try
                {
                    start = ReadNumber(start, end);
                    count++;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid number!");
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Number is out of range!");
                }
            }
        }

        static int ReadNumber(int start, int end)
        {
            int number = 0;
            Console.WriteLine("Enter a number in the range [{0}...{1}]", start, end);
            number = int.Parse(Console.ReadLine());
            if (!(number > start && number < end))
            {
                throw new ArgumentOutOfRangeException();
            }
            return number;
        }
    }
}