using System;

namespace _01.School
{
    class Teacher : Person
    {
        public Discipline[] Disciplines { get; set; }
        public string Details { get; set; }

        public Teacher(string name, Discipline[] disciplines, string details = "")
            : base(name)
        {
            this.Disciplines = disciplines;
            this.Details = details;
        }
    }
}
