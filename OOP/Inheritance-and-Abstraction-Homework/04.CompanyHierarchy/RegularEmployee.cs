using System;

namespace _04.CompanyHierarchy
{
    public class RegularEmployee : Employee, IRegularEmployee
    {
        public RegularEmployee(string id, string firstName, string lastName, int salary, Department department)
            : base(id, firstName, lastName, salary, department)
        {
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
