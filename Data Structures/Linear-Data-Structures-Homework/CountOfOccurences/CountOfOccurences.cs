using System;
using System.Collections.Generic;
using System.Text;

namespace CountOfOccurences
{
    class CountOfOccurences
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            Dictionary<int, int> occurences = new Dictionary<int, int>();

            foreach (var numStr in input)
            {
                int number = int.Parse(numStr);
                if (occurences.ContainsKey(number))
                {
                    occurences[number]++;
                }
                else
                {
                    occurences[number] = 1;
                }
            }

            StringBuilder output = new StringBuilder();
            foreach (var occurence in occurences)
            {
                output.Append(occurence.Key);
                output.Append(" -> ");
                output.Append(occurence.Value);
                output.Append(" times \n");
            }

            Console.WriteLine(output.ToString().Trim());
        }
    }
}
