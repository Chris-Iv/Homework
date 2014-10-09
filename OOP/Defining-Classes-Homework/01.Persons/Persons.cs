using System;

namespace _01.Persons
{
    class Persons
    {
        static void Main(string[] args)
        {
            Person ivan = new Person("Ivan", 20, "ivan@mail.bg");
            Person gosho = new Person("Gosho", 30);

            Console.WriteLine(ivan);
            Console.WriteLine(gosho);
        }
    }
}