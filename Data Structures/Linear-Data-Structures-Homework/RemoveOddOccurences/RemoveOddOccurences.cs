using System;
using System.Collections.Generic;
using System.Linq;

namespace RemoveOddOccurences
{
    internal class RemoveOddOccurences
    {
        private static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            Dictionary<int, int> allOccurences = new Dictionary<int, int>();

            foreach (int number in numbers)
            {
                if (allOccurences.ContainsKey(number))
                {
                    allOccurences[number]++;
                }
                else
                {
                    allOccurences[number] = 1;
                }
            }

            List<int> oddOccurenes = new List<int>();
            foreach (var key in allOccurences.Keys)
            {
                if (allOccurences[key] % 2 != 0)
                {
                    oddOccurenes.Add(key);
                }
            }

            foreach (int oddOccurence in oddOccurenes)
            {
                allOccurences.Remove(oddOccurence);
            }

            List<int> occurences = new List<int>();
            foreach (var occurence in allOccurences)
            {
                int number = occurence.Key;
                int count = occurence.Value;

                for (int i = 0; i < count; i++)
                {
                    occurences.Add(number);
                }
            }

            Console.WriteLine(string.Join(" ", occurences));
        }
    }
}