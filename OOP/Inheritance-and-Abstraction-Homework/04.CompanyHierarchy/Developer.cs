using System;

namespace _04.CompanyHierarchy
{
    public class Developer : RegularEmployee, IDeveloper
    {
        public Project[] Projects { get; set; }

        public Developer(string id, string firstName, string lastName, int salary, Department department, Project[] projects)
            : base(id, firstName, lastName, salary, department)
        {
            this.Projects = projects;
        }

        public override string ToString()
        {
            string baseStr = base.ToString();
            return baseStr + string.Format("\nProjects: \n{0}", this.Projects);
        }
    }
}
