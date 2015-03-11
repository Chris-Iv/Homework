using System;
using System.Data.Entity;
using System.Linq;
using System.Collections.Generic;

namespace SoftUniDbContext
{
    public class EFActions
    {
        static void Main(string[] args)
        {
            SoftUniEntities db = new SoftUniEntities();

            var employeesCount = db.Employees.Count();
            //Console.WriteLine(employeesCount);

            var employeesWithProjectsWithStartDateFrom2002 = FindEmployeesWithProjectsWithStartDate(2002);
            foreach (var emlployee in employeesWithProjectsWithStartDateFrom2002)
            {
                //Console.WriteLine(emlployee.FirstName + " " + emlployee.LastName);
            }

            var employeesWithProjectsWithStartDateFrom2002NativeQuery = FindEmployeesWithProjectsWithQuery(2002);
            foreach (var emlployeeName in employeesWithProjectsWithStartDateFrom2002NativeQuery)
            {
                //Console.WriteLine(emlployeeName);
            }

            var employeeByDepartmentAndManager = FindEmployeeByDepartmentAndManager("Sales", "Stephen", "Jiang");
            foreach (var employee in employeeByDepartmentAndManager)
            {
                //Console.WriteLine(employee.FirstName + " " + employee.LastName);
            }
            

            var concurrencyDb = new SoftUniEntities();
            //var guy = db.Employees.FirstOrDefault(e => e.FirstName == "Roberto");
            //var guy2 = concurrencyDb.Employees.FirstOrDefault(e => e.FirstName == "Roberto");
            //guy.FirstName = "Gosho";
            //guy2.FirstName = "Pesho";
            //db.SaveChanges();
            //concurrencyDb.SaveChanges();

            var employeesForProject = db.Employees.Where(e => e.EmployeeID == 4 && e.EmployeeID == 45).ToList();
            //Project newProject = AddProject("Test project", new DateTime(2014, 11, 25), new DateTime(2015, 05, 25), employeesForProject);
            //if (null != newProject)
            //{
            //    Console.WriteLine("Project {0} successfully added", newProject.Name);
            //}
        }

        public static List<Employee> FindEmployeesWithProjectsWithStartDate(int startYear)
        {
            SoftUniEntities db = new SoftUniEntities();
            var employees = db.Employees
                .Where(e => e.Projects
                .Any(p => p.StartDate.Year == startYear))
                .OrderBy(e => e.FirstName)
                .ToList();

            return employees;
        }

        public static List<string> FindEmployeesWithProjectsWithQuery(int startYear)
        {
            SoftUniEntities db = new SoftUniEntities();
            var query = "SELECT [e].[FirstName]" +
                        "FROM Employees [e]" +
                        "JOIN EmployeesProjects [ep]" +
                        "ON [ep].[EmployeeID] = [e].[EmployeeID]" +
                        "JOIN Projects [p]" +
                        "ON [p].[ProjectID] = [ep].[ProjectID]" +
                        "WHERE YEAR([p].[StartDate]) = '{0}'" +
                        "GROUP BY [e].[FirstName]" +
                        "ORDER BY [e].[FirstName]";

            var employeesNames = db.Database.SqlQuery<string>(String.Format(query, startYear)).ToList();

            return employeesNames;
        }

        public static IQueryable<Employee> FindEmployeeByDepartmentAndManager(string departmentName, string managerFirstName, string managerLastName)
        {
            SoftUniEntities db = new SoftUniEntities();

            var manager = db.Employees
                .FirstOrDefault(e => e.FirstName == managerFirstName && e.LastName == managerLastName);

            var employees = db.Employees
                .Where(e => e.Department.Name == departmentName &&
                e.ManagerID == manager.EmployeeID);

            return employees;
        }

        public static Project AddProject(string projectName, DateTime startDate, DateTime endDate, ICollection<Employee> employees)
        {
            SoftUniEntities db = new SoftUniEntities();
            DbContextTransaction newProjectTransaction = db.Database.BeginTransaction();

            Project newProject = new Project();
            try
            {
                newProject.Name = projectName;
                newProject.StartDate = startDate;
                newProject.EndDate = endDate;
                newProject.Employees = employees;

                newProject = db.Projects.Add(newProject);
                db.SaveChanges();
                newProjectTransaction.Commit();
            }
            catch (Exception ex)
            {
                newProjectTransaction.Rollback();
            }

            return newProject;
        }
    }
}
