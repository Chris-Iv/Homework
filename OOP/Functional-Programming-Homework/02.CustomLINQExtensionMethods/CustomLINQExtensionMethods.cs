using System;
using System.Collections.Generic;

namespace _02.CustomLINQExtensionMethods
{
    public static class CustomLINQExtensionMethods
    {
        static void Main()
        {
            IEnumerable<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6 };

            Console.WriteLine(string.Join(", ", numbers.WhereNot<int>(a => a == 4)));

            Console.WriteLine(string.Join(", ", numbers.Repeat<int>(4)));

            IEnumerable<string> stringItems = new List<string>() { "alo", "balo", "pica", "mivka", "kon" };
            IEnumerable<string> suffixes = new List<string>() { "alo", "ka" };

            Console.WriteLine(string.Join(", ", stringItems.WhereEndsWith(suffixes)));
        }

        public static IEnumerable<T> WhereNot<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
        {
            foreach (var item in collection)
            {
                if (!predicate(item))
                {
                    yield return item;
                }
            }
        }

        public static IEnumerable<T> Repeat<T>(this IEnumerable<T> collection, int count)
        {
            for (int i = 0; i < count; i++)
            {
                foreach (var item in collection)
                {
                    yield return item;
                }
            }
        }

        public static IEnumerable<string> WhereEndsWith(this IEnumerable<string> collection, IEnumerable<string> suffixes)
        {
            foreach (var item in collection)
            {
                foreach (var suffix in suffixes)
                {
                    if (item.Trim().EndsWith(suffix))
                    {
                        yield return item.Trim();
                    }
                }
            }
        }
    }
}