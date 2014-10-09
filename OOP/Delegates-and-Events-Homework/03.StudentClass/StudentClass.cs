using System;

namespace _03.StudentClass
{
    class StudentClass
    {
        static void Main(string[] args)
        {
            var student = new Student("Pesho", 20);
            student.Name = "Gosho";
            student.Age = 30;
        }
    }
}
