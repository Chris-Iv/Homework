using System;
using System.Collections.Generic;
using System.Text;

namespace _01.StringBuilderExtensions
{
    class StringBuilderExtensions
    {
        static void Main()
        {
            StringBuilder text = new StringBuilder("Substring method works!");

            Console.WriteLine(text.Substring(5, 7));

            Console.WriteLine(text.RemoveText("method"));

            StringBuilder chat = new StringBuilder();
            chat.AppendAll(new List<string>() { "Hi", ", ", "how ", "are ", "you" })
            .AppendAll(new List<string>() { "\nI ", "am ", "fine" });

            Console.WriteLine(chat);
        }
    }
}
