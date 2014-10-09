using System;

namespace _01.School
{
    class Discipline
    {
        public string Name { get; set; }
        public int Lectures { get; set; }
        public Student[] Students { get; set; }
        public string Details { get; set; }

        public Discipline(string name, int lectures, Student[] students, string details = "")
        {
            this.Name = name;
            this.Lectures = lectures;
            this.Students = students;
            this.Details = details;
        }
    }
}
