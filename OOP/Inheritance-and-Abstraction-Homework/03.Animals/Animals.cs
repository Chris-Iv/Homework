using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Animals
{
    class Animals
    {
        static void Main()
        {
            Dog rex = new Dog("Rex", 3, "male");
            Dog max = new Dog("Max", 1, "male");
            Dog sara = new Dog("Sara", 6, "female");

            Frog frog = new Frog("Frog", 7, "male");
            Frog jaba = new Frog("Jaba", 4, "female");
            Frog kermit = new Frog("Kermit", 10, "male");

            Cat kitty = new Kitten("Kitty", 2);
            Cat snowball = new Tomcat("Snowball", 5);

            List<Animal> animals = new List<Animal>()
            {
                rex,
                max,
                sara,
                frog,
                jaba,
                kermit,
                kitty,
                snowball
            };

            var groupedAnimals =
                from animal in animals
                group animal by animal.GetType().Name into g
                select new { GroupName = g.Key, AverageAge = g.ToList().Average(an => an.Age) };

            foreach (var animal in groupedAnimals)
            {
            Console.WriteLine("{0}s - average age: {1:N2}", animal.GroupName, animal.AverageAge);
            }

            rex.ProduceSound();
            kermit.ProduceSound();
            snowball.ProduceSound();
        }
    }
}
