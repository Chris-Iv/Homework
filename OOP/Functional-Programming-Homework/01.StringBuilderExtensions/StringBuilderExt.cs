using System;
using System.Collections.Generic;
using System.Text;

namespace _01.StringBuilderExtensions
{
    public static class StringBuilderExt
    {
        public static StringBuilder Substring(this StringBuilder strBuilder, int startIndex, int length)
        {
            string str = strBuilder.ToString();
            StringBuilder result = new StringBuilder();
            int range = (str.Length - 1) - startIndex;
            int end = startIndex + length;

            if (length > range)
            {
                throw new ArgumentOutOfRangeException("Out of range!");
            }

            for (int i = startIndex; i < end; i++)
            {
                result.Append(str[i]);
            }
            return result;
        }

        public static StringBuilder RemoveText(this StringBuilder strBuilder, string text)
        {
            strBuilder = strBuilder.Replace(text, "");
            return strBuilder;
        }

        public static StringBuilder AppendAll<T>(this StringBuilder strBuilder, IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                strBuilder.Append(item.ToString());
            }
            return strBuilder;
        }
    }
}
