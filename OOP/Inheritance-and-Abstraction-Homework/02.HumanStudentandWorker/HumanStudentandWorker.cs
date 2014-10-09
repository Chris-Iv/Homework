using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.HumanStudentandWorker
{
    class HumanStudentandWorker
    {
        static void Main()
        {
            var students = new List<Student>()
            {
                new Student("Petar", "Petrov", "2736ds"),
                new Student("Georgi", "Georgiev", "58sa874"),
                new Student("Ivan", "Ivanov", "assdh7"),
                new Student("Hristo", "Hristov", "s4e16ds"),
                new Student("Miro", "Mirkov", "s7g1k02"),
                new Student("Mihail", "Mihailov", "ahsge7"),
                new Student("Mincho", "Minchev", "2746sgd"),
                new Student("Encho", "Enchev", "shj47"),
                new Student("Milko", "Milchev", "27364"),
                new Student("Slavi", "Slavchev", "shtvs"),
            };

            var workers = new List<Worker>()
            {
                new Worker("Petar", "Petrov", 400, 8),
                new Worker("Georgi", "Georgiev", 390, 7),
                new Worker("Ivan", "Ivanov", 520, 9),
                new Worker("Hristo", "Hristov", 385, 5),
                new Worker("Miro", "Mirkov", 570, 6),
                new Worker("Mihail", "Mihailov", 615, 10),
                new Worker("Mincho", "Minchev", 880, 11),
                new Worker("Encho", "Enchev", 950, 12),
                new Worker("Milko", "Milchev", 790, 11),
                new Worker("Slavi", "Slavchev", 495, 6),
            };

            var sortStudents = students.OrderBy(s => s.FacultyNumber)
                .Select(s => new { FirstName = s.FirstName, LastName = s.LastName, FacultyNumber = s.FacultyNumber });

            foreach (var student in sortStudents)
            {
                Console.WriteLine(student);
            }
            Console.WriteLine();

            var sortWorkers = workers.OrderByDescending(s => s.MoneyPerHour())
                .Select(s => new { FirstName = s.FirstName, LastName = s.LastName, MoneyPerHour = s.MoneyPerHour() });

            foreach (var worker in sortWorkers)
            {
                Console.WriteLine(worker);
            }
            Console.WriteLine();

            List<Human> humans = new List<Human>();
            humans.AddRange(students);
            humans.AddRange(workers);

            var sortHumans = humans.OrderBy(s => s.FirstName)
                .ThenBy(s => s.LastName)
                .Select(s => new { FirstName = s.FirstName, LastName = s.LastName });

            foreach (var human in sortHumans)
            {
                Console.WriteLine(human);
            }
        }
    }
}
