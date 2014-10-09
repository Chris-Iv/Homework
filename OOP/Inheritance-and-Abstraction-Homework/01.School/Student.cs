using System;

namespace _01.School
{
    class Student : Person
    {
        public string ClassNumber { get; set; }
        public string Details { get; set; }

        public Student(string name, string classNumber, string details = "")
            : base(name)
        {
            this.ClassNumber = classNumber;
            this.Details = details;
        }
    }
}