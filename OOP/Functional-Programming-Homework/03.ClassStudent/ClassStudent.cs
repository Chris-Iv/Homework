using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.ClassStudent
{
    class ClassStudent

    {
        static void Main()
        {
            var students = new List<Student>{
                new Student("Pesho", "Petrov", 18, 112814, "0292345716", "pesho@abv.bg", new List<int>{5, 5, 4, 6}, "3"),
                new Student("Gosho", "Georgiev", 27, 135938, "0893445226", "gosho@abv.bg", new List<int>{3, 6, 5, 4}, "2"),
                new Student("Miro", "Mirkov", 20, 147614, "0882345472", "miro@abv.bg", new List<int>{2, 2, 6, 5}, "1"),
                new Student("Ivo", "Ivchev", 25, 127578, "+359355616", "ivo@abv.bg", new List<int>{2, 4, 5, 5}, "3"),
                new Student("Ivan", "Ivanov", 21, 178414, "0872322616", "ivan@abv.bg", new List<int>{3, 2, 6, 4}, "2"),
                new Student("Ceco", "Cecov", 28, 115140, "+3592555786", "ceco@abv.bg", new List<int>{6, 4, 2, 2}, "2")
            };

            var studentsByGroup = students.Where(s => s.GroupNumber == "2")
                .OrderBy(s => s.FirstName)
                .Select(s => string.Format("{0} {1} - {2}", s.FirstName, s.LastName, s.GroupNumber));
            foreach (var student in studentsByGroup)
            {
                Console.WriteLine(student);
            }
            Console.WriteLine();

            var studentsByName = students.Where(s => string.Compare(s.FirstName, s.LastName) < 0)
                .Select(s => string.Format("{0} {1}", s.FirstName, s.LastName));
            foreach (var student in studentsByName)
            {
                Console.WriteLine(student);
            }
            Console.WriteLine();

            var studentsByAge = students.Where(s => s.Age >= 18 && s.Age <= 24)
                .Select(s => string.Format("{0} {1}", s.FirstName, s.LastName));
            foreach (var student in studentsByAge)
            {
                Console.WriteLine(student);
            }
            Console.WriteLine();

            var studentsSort = students.OrderByDescending(s => s.FirstName)
                .ThenByDescending(s => s.LastName)
                .Select(s => string.Format("{0} {1}", s.FirstName, s.LastName));
            foreach (var student in studentsSort)
            {
                Console.WriteLine(student);
            }
            Console.WriteLine();

            var studentsQuerySort =
                from s in students
                orderby s.FirstName + s.LastName descending
                select string.Format("{0} {1}", s.FirstName, s.LastName);
            foreach (var student in studentsQuerySort)
            {
                Console.WriteLine(student);
            }
            Console.WriteLine();

            var studentsByEmail =
                from s in students
                where s.Email.EndsWith("@abv.bg")
                select string.Format("{0} {1}", s.FirstName, s.LastName);
            foreach (var student in studentsByEmail)
            {
                Console.WriteLine(student);
            }
            Console.WriteLine();

            var studentsByPhone = 
                from s in students
                where s.Phone.StartsWith("02") || s.Phone.StartsWith("+3592") || s.Phone.StartsWith("+359 2")
                select string.Format("{0} {1}", s.FirstName, s.LastName);
            foreach (var student in studentsByPhone)
            {
                Console.WriteLine(student);
            }
            Console.WriteLine();

            var studentsExcellent =
                from s in students
                where s.Marks.IndexOf(6) >= 0
                select new { FullName = s.FirstName + " " + s.LastName, Marks = s.Marks };
            foreach (var student in studentsExcellent)
            {
                Console.WriteLine(student.FullName);
            }
            Console.WriteLine();

            var studentsWeak = students.Where(s => s.Marks.Aggregate(0, (counter, mark) => counter + (mark == 2 ? 1 : 0)) == 2)
                .Select(s => s.FirstName + " " + s.LastName);
            foreach (var student in studentsWeak)
            {
                Console.WriteLine(student);
            }
            Console.WriteLine();

            var studentsEnroled = students.Where(s => s.FacultyNumber % 100 == 14)
                .Select(s => s.Marks);
            foreach (var marks in studentsEnroled)
            {
                foreach (var mark in marks)
                {
                    Console.Write(mark);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
