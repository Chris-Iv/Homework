using System;

namespace _04.CompanyHierarchy
{
    public class Manager : Employee, IManager
    {
        public Employee[] Employees { get; set; }

        public Manager(string id, string firstName, string lastName, int salary, Department department, Employee[] employees)
            : base(id, firstName, lastName, salary, department)
        {
            this.Employees = employees;
        }

        public override string ToString()
        {
            string baseStr = base.ToString();
            string employeesStr = string.Empty;
            foreach (var emp in this.Employees)
            {
                employeesStr += emp.Id + ", " + emp.FirstName + " " + emp.LastName;
            }
            return baseStr + string.Format("\nManaged employees: {0}", employeesStr);
        }
    }
}
