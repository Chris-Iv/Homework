using System;

namespace _04.CompanyHierarchy
{
    public interface IEmployee
    {
        int Salary { get; set; }

        Department Department { get; set; }
    }
}
