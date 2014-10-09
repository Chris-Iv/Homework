using System;

namespace _02.HumanStudentandWorker
{
    class Student : Human
    {
        public string FacultyNumber { get; set; }

        public Student(string firstName, string lastName, string facultyNumber)
            : base(firstName, lastName)
        {
            this.FacultyNumber = facultyNumber;
        }
    }
}
