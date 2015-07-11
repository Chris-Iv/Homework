using System;
using System.Collections.Generic;
using System.Linq;

namespace LongestSubsequence
{
    class LongestSubsequence
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            int number = input[0];
            int counter = 1;

            int tempNum = input[0];
            int tempCount = 1;

            for (int i = 1; i < input.Count; i++)
            {
                if (tempNum.CompareTo(input[i]) == 0)
                {
                    tempCount++;
                    if (tempCount > counter)
                    {
                        counter = tempCount;
                        number = tempNum;
                    }
                }
                else
                {
                    tempNum = input[i];
                    tempCount = 1;
                }
            }

            List<int> subsequence = Enumerable.Repeat(number, counter).ToList();
            Console.WriteLine(string.Join(" ", subsequence));
        }
    }
}
