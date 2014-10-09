using System;

namespace _01.SquareRoot
{
    class SquareRoot
    {
        static void Main(string[] args)
        {
            try
            {
                int number = int.Parse(Console.ReadLine());
                if (number < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                double result = Math.Sqrt(number);
                Console.WriteLine(result);
            }
            catch (FormatException)
            {
                Console.Error.WriteLine("Invalid number!");
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.Error.WriteLine("Number should be positive!");
            }
            finally
            {
                Console.WriteLine("Good bye");
            }
        }
    }
}