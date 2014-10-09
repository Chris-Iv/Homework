using System;

namespace _04.CompanyHierarchy
{
    public interface IProject
    {
        string ProjectName { get; set; }

        string ProjectStartDate { get; set; }

        string Details { get; set; }

        ProjectState State { get; set; }

        void CloseProject();
    }
}
