using System;

namespace _04.CompanyHierarchy
{
    public class Project : IProject
    {
        public string ProjectName { get; set; }
        public string ProjectStartDate { get; set; }
        public string Details { get; set; }
        public ProjectState State { get; set; }

        public Project(string projectName, string projectStartDate, string details, ProjectState state)
        {
            this.ProjectName = projectName;
            this.ProjectStartDate = projectStartDate;
            this.Details = details;
            this.State = state;
        }

        public void CloseProject()
        {
            this.State = ProjectState.Closed;
        }

        public override string ToString()
        {
            return string.Format(
            "Project: {0}, started: {1:dd.MM.yyyy}, State: {2}, Details: {3}",
            this.ProjectName,
            this.ProjectStartDate,
            this.State,
            this.Details);
        }
    }
}
