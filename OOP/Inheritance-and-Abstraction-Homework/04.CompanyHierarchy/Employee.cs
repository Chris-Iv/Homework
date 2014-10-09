using System;

namespace _04.CompanyHierarchy
{
    public abstract class Employee : Person, IEmployee
    {
        public int Salary { get; set; }
        public Department Department { get; set; }

        public Employee(string id, string firstName, string lastName, int salary, Department department)
            : base(id, firstName, lastName)
        {
            this.Salary = salary;
            this.Department = department;
        }

        public override string ToString()
        {
            string baseStr = base.ToString();
            return baseStr + string.Format("\nSalary: {0:N2}\nDepartment: {1}", this.Salary, this.Department);
        }
    }
}
