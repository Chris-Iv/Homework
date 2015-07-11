using System;
using System.Collections.Generic;

namespace SortWords
{
    public class SortWords
    {
        public static void Main()
        {
            List<string> words = new List<string>();
            string[] wordsArr = Console.ReadLine().Split(' ');

            for (int i = 0; i < wordsArr.Length; i++)
            {
                words.Add(wordsArr[i]);
            }

            words.Sort();
            Console.WriteLine(string.Join(" ", words));
        }
    }
}
