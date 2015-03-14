namespace StudentSystem.ConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Data.Entity;
    using StudentSystem.Data;
    using StudentSystem.Data.Migrations;
    using StudentSystem.Models;

    public class Program
    {
        static void Main(string[] args)
        {
            StudentSystemDbContext db = new StudentSystemDbContext();

            var student = new Student()
            {
                Name = "Ivan Ivanov",
                BirthDay = new DateTime(1992, 06, 01),
                RegistrationDate = DateTime.Now
            };
            db.Students.Add(student);
            Console.WriteLine(db.Students.FirstOrDefault().Name);
        }
        public static void ListAllStudentsAndHomeworks()
        {
            var db = new StudentSystemDbContext();

            var students = db.Students.ToList();
            foreach (var student in students)
            {
                Console.WriteLine(student.Name);
                Console.WriteLine("Homeworks:");

                var homeworks = student.Homeworks.ToList();
                foreach (var homework in homeworks)
                {
                    Console.WriteLine(homework.Content);
                }
            }
        }
            
        public static void ListAllCoursesAndResources()
        {
            var db = new StudentSystemDbContext();

            var courses = db.Courses.ToList();
            foreach (var course in courses)
            {
                Console.WriteLine(course.Name);
                Console.WriteLine("Resources:");

                var resources = course.Resources.ToList();
                foreach (var resource in resources)
                {
                    Console.WriteLine(resource.Name);
                }
            }
        }

        public static Course AddCourseWithResources(string courseName, DateTime startDate, decimal price, 
            string resourceName, ResourceType type, string link)
        {
            var db = new StudentSystemDbContext();

            var NewResource = new Resource()
            {
                Name = resourceName,
                ResourceType = type,
                Link = link
            };

            var newCourse = new Course()
            {
                Name = courseName,
                StartDate = startDate,
                Price = price,
            };

            newCourse.Resources.Add(NewResource);

            db.Courses.Add(newCourse);
            db.Resources.Add(NewResource);
            return newCourse;
        }

        public static Student AddStudent(string name, DateTime birthday, DateTime registrationDate)
        {
            var db = new StudentSystemDbContext();

            var newStudent = new Student()
            {
                Name = name,
                BirthDay = birthday,
                RegistrationDate = registrationDate
            };

            db.Students.Add(newStudent);
            return newStudent;
        }

        public static Resource AddResource(string name, ResourceType type, string link)
        {
            var db = new StudentSystemDbContext();

            var newResource = new Resource()
            {
                Name = name,
                ResourceType = type,
                Link = link
            };

            db.Resources.Add(newResource);
            return newResource;
        }
    }
}